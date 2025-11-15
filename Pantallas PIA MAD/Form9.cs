using iTextSharp.text;
using iTextSharp.text.pdf;
using Pantallas_PIA_MAD.DAO;
using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Pantallas_PIA_MAD
{
    public partial class Form9 : Form
    {
        private CalculoNomina nominaService = new CalculoNomina();
        private GeneradorReciboPDF reciboPDFService = new GeneradorReciboPDF();
        public Form9()
        {
            InitializeComponent();
        }
        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Boton para exportar en CSV los datos que esten en la vista
        private void button9_Click(object sender, EventArgs e)
        {
            if (VistaNOMINAAUX.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StringBuilder sb = new StringBuilder();

            List<string> headers = new List<string>();
            foreach (DataGridViewColumn column in VistaNOMINAAUX.Columns)
            {
                headers.Add(column.HeaderText);
            }
            sb.AppendLine(string.Join(",", headers));

            foreach (DataGridViewRow row in VistaNOMINAAUX.Rows)
            {
                if (!row.IsNewRow)
                {
                    List<string> celdas = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string valor;
                        if (cell.Value is DateTime)
                        {
                            valor = ((DateTime)cell.Value).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            valor = (cell.Value?.ToString() ?? "").Replace(",", ";");
                        }
                        celdas.Add(valor);
                    }
                    sb.AppendLine(string.Join(",", celdas));
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte de Nómina";
            sfd.FileName = $"Nomina_{DateTime.Now.ToString("yyyyMMdd")}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Reporte exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Boton para calcular la nomina del empleado
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null) { MessageBox.Show("Seleccione empleado."); return; }

            try
            {
                int idEmpleado;
                if (comboBox2.SelectedItem is Empleado) { idEmpleado = ((Empleado)comboBox2.SelectedItem).id_empleado; }
                else { idEmpleado = (int)comboBox2.SelectedValue; }
                DateTime fechaSeleccionada = FechaADMINNomina.Value;
                int anio = fechaSeleccionada.Year; int mes = fechaSeleccionada.Month;
                if (NominaDAO.VerificarNominaExistente(idEmpleado, anio, mes))
                {
                    MessageBox.Show("¡Error! Ya existe una nómina para este empleado en este mes.", "Nómina Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int.TryParse(TB_Faltas.Text, out int faltas);
                int.TryParse(TB_Retardos.Text, out int retardos);
                decimal.TryParse(TB_Aguinaldo.Text.Replace("$", "").Replace(",", ""), out decimal aguinaldo);
                decimal.TryParse(TB_BNPuntualidad.Text.Replace("$", "").Replace(",", ""), out decimal bonoPuntualidad);
                decimal.TryParse(TB_BNAsistencia.Text.Replace("$", "").Replace(",", ""), out decimal bonoAsistencia);
                decimal.TryParse(TB_CuotaIMSS.Text.Replace("$", "").Replace(",", ""), out decimal cuotaImss);
                decimal.TryParse(TB_CuotaSindical.Text.Replace("$", "").Replace(",", ""), out decimal cuotaSindical);
                int diasDelMes = DateTime.DaysInMonth(anio, mes);
                Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idEmpleado);
                if (empleado == null) { MessageBox.Show("No se encontró empleado."); return; }

                CalculoCompleto resultadoCalculo = nominaService.CalcularNomina(
                    empleado, diasDelMes, faltas, retardos, aguinaldo,
                    bonoPuntualidad, bonoAsistencia, cuotaImss, cuotaSindical
                );

                Recibo_Nomina reciboParaGuardar = resultadoCalculo.Recibo;
                CalculoDesglose desgloseParaPDF = resultadoCalculo.Desglose;

                DateTime fechaDeNomina = new DateTime(anio, mes, 1);
                Nomina nomina = new Nomina { fecha = fechaDeNomina, estatus = "Calculada", id_empleado = idEmpleado };

                int idNominaNueva;
                int resultadoNomina = NominaDAO.InsertarNomina(nomina, out idNominaNueva);
                if (resultadoNomina <= 0 || idNominaNueva <= 0) { MessageBox.Show("Error al guardar nómina."); return; }

                reciboParaGuardar.id_nomina = idNominaNueva;
                reciboParaGuardar.fecha = fechaDeNomina;

                int resultadoRecibo = ReciboNominaDAO.InsertarReciboNomina(reciboParaGuardar);
                if (resultadoRecibo <= 0) { MessageBox.Show("Error al guardar recibo."); return; }

                refrescar();
                MessageBox.Show("Nómina calculada y guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult dialogResult = MessageBox.Show(
                    "¿Desea generar el recibo en PDF para este empleado?", "Generar PDF",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                        sfd.Title = "Guardar Recibo de Nómina";
                        sfd.FileName = $"Recibo_{empleado.nombres.Replace(" ", "")}_{mes}-{anio}.pdf";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            RegistroEmpresa empresa = EmpresaDAP.ObtenerEmpresaPorId(empleado.id_empresa);
                            empleado.Puesto = PuestoDAO.ObtenerPuestoPorId(empleado.id_puesto ?? 0);
                            empleado.Departamento = DepartamentoDAO.ObtenerDepartamentoPorId(empleado.id_departamento ?? 0);
                            reciboPDFService.GenerarPDF(sfd.FileName, empleado, reciboParaGuardar, desgloseParaPDF, empresa);

                            MessageBox.Show("Recibo PDF generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exPdf)
                    {
                        MessageBox.Show("Error al generar el PDF: " + exPdf.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al calcular: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FaltasRetardos_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TB_Faltas.Text, out int faltas);
            int.TryParse(TB_Retardos.Text, out int retardos);
            int faltasTotales = faltas + (retardos / 3);

            if (faltasTotales > 0)
            {
                TB_BNPuntualidad.Text = (0m).ToString("C2");
                TB_BNAsistencia.Text = (0m).ToString("C2");
            }
            else
            {
                comboBox2_SelectedIndexChanged(null, null);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem is Empleado empleadoSel)
            {
                try
                {
                    Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(empleadoSel.id_empleado);
                    if (empleado == null) return;

                    decimal imssCalculado = nominaService.CalcularIMSS(empleado);

                    decimal salarioDiario = empleado.salario ?? 0;
                    decimal sindicalCalculado = salarioDiario * 0.02m;
                    decimal bonoPuntualidad = salarioDiario * 0.10m;
                    decimal bonoAsistencia = salarioDiario * 0.10m;

                    DateTime fechaSeleccionada = FechaADMINNomina.Value;
                    int diasDelMes = DateTime.DaysInMonth(fechaSeleccionada.Year, fechaSeleccionada.Month);
                    decimal aguinaldoCalculado = (15.0m / 365.0m) * diasDelMes;
                    TB_CuotaIMSS.Text = imssCalculado.ToString("C2");
                    TB_CuotaSindical.Text = sindicalCalculado.ToString("C2");
                    TB_BNPuntualidad.Text = bonoPuntualidad.ToString("C2");
                    TB_BNAsistencia.Text = bonoAsistencia.ToString("C2");
                    TB_Aguinaldo.Text = aguinaldoCalculado.ToString("C2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular automáticos: " + ex.Message);
                }
            }
            else
            {
                TB_CuotaIMSS.Text = "";
                TB_CuotaSindical.Text = "";
                TB_BNPuntualidad.Text = "";
                TB_BNAsistencia.Text = "";
                TB_Aguinaldo.Text = "";
            }
        }
        //Cargar la pantalla y el combobox de empresa
        private void Form9_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form9_FormClosed;
            ComboBoxEmpresaPuesto.DataSource = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuesto.DisplayMember = "nombre";
            ComboBoxEmpresaPuesto.ValueMember = "id_empresa";
            ComboBoxDepartamentoPuesto.SelectedIndex = -1;
            VistaNOMINAAUX.DataSource = ReciboNominaDAO.ObtenerRecibosNomina();

            refrescar();
        }

        private void refrescar()
        {
            VistaNOMINAAUX.DataSource = ReciboNominaDAO.ObtenerRecibosDetallados();
        }
        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuesto.SelectedValue is int idEmpresa)
            {
                ComboBoxDepartamentoPuesto.DataSource = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
                ComboBoxDepartamentoPuesto.DisplayMember = "nombre";
                ComboBoxDepartamentoPuesto.ValueMember = "id_departamento";
                comboBox1.SelectedIndex = -1;
            }
        }
        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamentoPuesto.SelectedValue is int idDepartamento)
            {
                comboBox1.DataSource = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "id_puesto";
                comboBox1.SelectedIndex = -1;
            }
        }
        private void comboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int idPuesto)
            {
                comboBox2.DataSource = EmpleadoDAO.ObtenerEmpleadosPorPuesto(idPuesto);
                comboBox2.DisplayMember = "nombres"; 
                comboBox2.ValueMember = "id_empleado";
                comboBox2.SelectedIndex = -1;
            }
        }

        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAD_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de usuarios
        private void Usuarios_MEAD_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de departamentos y puestos
        private void DepaPues__MEAD_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de los reportes
        private void Reporte_MEAD_Click(object sender, EventArgs e)
        {
            Form11 form10 = new Form11();
            form10.Show();
            this.Hide();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir_MEAD_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de empleados 
        private void Empleados_MEAD_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.Show();
            this.Hide();
        }
    }
}
