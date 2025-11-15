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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Pantallas_PIA_MAD
{
    public partial class Form12 : Form
    {
        private CalculoNomina nominaService = new CalculoNomina();
        private GeneradorReciboPDF reciboPDFService = new GeneradorReciboPDF();
        public Form12()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Cargar la pantalla y contenido dentro de combobox
        private void Form12_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form12_FormClosed;
            ComboBoxEmpresaPuestoAUX.DataSource = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuestoAUX.DisplayMember = "nombre";
            ComboBoxEmpresaPuestoAUX.ValueMember = "id_empresa";
            ComboBoxDepartamentoPuestoAUX.SelectedIndex = -1;
            Vista_Nomina.DataSource = ReciboNominaDAO.ObtenerRecibosDetallados();

            refrescar();
        }
        private void refrescar()
        {
            Vista_Nomina.DataSource = ReciboNominaDAO.ObtenerRecibosDetallados();
        }
        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAU_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de los reportes
        private void Reportes__MEAU_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir__MEAU_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        //Boton para calcular nomina
        private void BTN_CalcularNominaAUX_Click(object sender, EventArgs e)
        {
            if (comboBox2AUX.SelectedItem == null)
            {
                MessageBox.Show("Seleccione empleado.");
                return;
            }

            try
            {
                int idEmpleado;
                if (comboBox2AUX.SelectedItem is Empleado empleadoSel)
                {
                    idEmpleado = empleadoSel.id_empleado;
                }
                else
                {
                    MessageBox.Show("Error de ComboBox. Vuelve a seleccionar el empleado.");
                    return;
                }

                DateTime fechaSeleccionada = FechaAUXNomina.Value;
                int anio = fechaSeleccionada.Year;
                int mes = fechaSeleccionada.Month;

                if (NominaDAO.VerificarNominaExistente(idEmpleado, anio, mes))
                {
                    MessageBox.Show("¡Error! Ya existe una nómina para este empleado en este mes.", "Nómina Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int.TryParse(TB_FaltasAUX.Text, out int faltas);     
                int.TryParse(TB_RetardosAUX.Text, out int retardos); 

                decimal.TryParse(TB_AguinaldoAUX.Text.Replace("$", "").Replace(",", ""), out decimal aguinaldo);
                decimal.TryParse(TB_BNPuntualidadAUX.Text.Replace("$", "").Replace(",", ""), out decimal bonoPuntualidad);
                decimal.TryParse(TB_BNAsistenciaAUX.Text.Replace("$", "").Replace(",", ""), out decimal bonoAsistencia);
                decimal.TryParse(TB_CuotaIMSSAUX.Text.Replace("$", "").Replace(",", ""), out decimal cuotaImss);
                decimal.TryParse(TB_CuotaSindicalAUX.Text.Replace("$", "").Replace(",", ""), out decimal cuotaSindical);

                int diasDelMes = DateTime.DaysInMonth(anio, mes);

                Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idEmpleado);
                if (empleado == null) { MessageBox.Show("No se encontró empleado."); return; }

                Recibo_Nomina reciboCalculado = nominaService.CalcularNomina(
                    empleado, diasDelMes, faltas, retardos, aguinaldo,
                    bonoPuntualidad, bonoAsistencia, cuotaImss, cuotaSindical
                );

                DateTime fechaDeNomina = new DateTime(anio, mes, 1);
                Nomina nomina = new Nomina { fecha = fechaDeNomina, estatus = "Calculada", id_empleado = idEmpleado };

                int idNominaNueva;
                int resultadoNomina = NominaDAO.InsertarNomina(nomina, out idNominaNueva);
                if (resultadoNomina <= 0 || idNominaNueva <= 0) { MessageBox.Show("Error al guardar nómina."); return; }

                reciboCalculado.id_nomina = idNominaNueva;
                reciboCalculado.fecha = fechaDeNomina;

                int resultadoRecibo = ReciboNominaDAO.InsertarReciboNomina(reciboCalculado);
                if (resultadoRecibo <= 0) { MessageBox.Show("Error al guardar recibo."); return; }

                refrescar();
                MessageBox.Show("Nómina calculada y guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult dialogResult = MessageBox.Show(
                    "¿Desea generar el recibo en PDF para este empleado?",
                    "Generar PDF",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
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

                            reciboPDFService.GenerarPDF(sfd.FileName, empleado, reciboCalculado, empresa);

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

        //Evento para que aparezca todo en el combobox de empresa
        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuestoAUX.SelectedValue is int idEmpresa)
            {
                ComboBoxDepartamentoPuestoAUX.DataSource = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
                ComboBoxDepartamentoPuestoAUX.DisplayMember = "nombre";
                ComboBoxDepartamentoPuestoAUX.ValueMember = "id_departamento";
                comboBox1AUX.SelectedIndex = -1;
                comboBox1AUX.DataSource = null;
                comboBox2AUX.DataSource = null;
            }
        }
        //Evento para que aparezca todo en el combobox de departamento
        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamentoPuestoAUX.SelectedValue is int idDepartamento)
            {
                comboBox1AUX.DataSource = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);
                comboBox1AUX.DisplayMember = "nombre";
                comboBox1AUX.ValueMember = "id_puesto";
                comboBox1AUX.SelectedIndex = -1;
                comboBox2AUX.DataSource = null;
            }
        }
        //Evento para que aparezca todo en el combobox de puesto
        private void comboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1AUX.SelectedValue is int idPuesto)
            {
                comboBox2AUX.DataSource = EmpleadoDAO.ObtenerEmpleadosPorPuesto(idPuesto);
                comboBox2AUX.DisplayMember = "nombres";
                comboBox2AUX.ValueMember = "id_empleado";
                comboBox2AUX.SelectedIndex = -1;
            }
        }
        //Boton exportar archivo CSV de la nomina de los empleados
        private void BTN_ExportarCSVAUX_Click(object sender, EventArgs e)
        {
            if (Vista_Nomina.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StringBuilder sb = new StringBuilder();
            List<string> headers = new List<string>();
            foreach (DataGridViewColumn column in Vista_Nomina.Columns)
            {
                headers.Add(column.HeaderText);
            }
            sb.AppendLine(string.Join(",", headers));
            foreach (DataGridViewRow row in Vista_Nomina.Rows)
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
                        celdas.Add($"\"{valor}\"");
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

        private void comboBox2AUX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2AUX.SelectedItem is Empleado empleadoSel)
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

                    DateTime fechaSeleccionada = FechaAUXNomina.Value;
                    int diasDelMes = DateTime.DaysInMonth(fechaSeleccionada.Year, fechaSeleccionada.Month);
                    decimal aguinaldoCalculado = (15.0m / 365.0m) * diasDelMes;
                    TB_CuotaIMSSAUX.Text = imssCalculado.ToString("C2");
                    TB_CuotaSindicalAUX.Text = sindicalCalculado.ToString("C2");
                    TB_BNPuntualidadAUX.Text = bonoPuntualidad.ToString("C2");
                    TB_BNAsistenciaAUX.Text = bonoAsistencia.ToString("C2");
                    TB_AguinaldoAUX.Text = aguinaldoCalculado.ToString("C2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular automáticos: " + ex.Message);
                }
            }
            else
            {
                TB_CuotaIMSSAUX.Text = "";
                TB_CuotaSindicalAUX.Text = "";
                TB_BNPuntualidadAUX.Text = "";
                TB_BNAsistenciaAUX.Text = "";
                TB_AguinaldoAUX.Text = "";
            }
        }
    }
}
