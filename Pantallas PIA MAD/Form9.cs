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

namespace Pantallas_PIA_MAD
{
    public partial class Form9 : Form
    {
        private CalculoNomina nominaService = new CalculoNomina();
        public Form9()
        {
            InitializeComponent();
        }
        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Metodo del boton de calcular la nomina
        private void button5_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDAR INPUTS ---
            if (comboBox2.SelectedValue == null) // ¡Tu ComboBox de empleado es comboBox2!
            {
                MessageBox.Show("Por favor, seleccione un empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(TB_DiasTrabajados.Text, out int diasTrabajados))
            {
                MessageBox.Show("Días trabajados debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. OBTENER DATOS DE LA UI ---
            try
            {
                // ¡¡CORRECCIÓN 3a: Arreglado el 'InvalidCastException'!!
                // NO podemos usar (int)comboBox2.SelectedValue
                var empleadoSel = (Empleado)comboBox2.SelectedItem;
                int idEmpleado = empleadoSel.id_empleado;

                Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idEmpleado);
                if (empleado == null)
                {
                    MessageBox.Show("No se pudo encontrar al empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal.TryParse(TB_Aguinaldo.Text, out decimal aguinaldo);
                decimal.TryParse(TB_BNPuntualidad.Text, out decimal bonoPuntualidad);
                decimal.TryParse(TB_BNAsistencia.Text, out decimal bonoAsistencia);
                decimal.TryParse(TB_CuotaIMSS.Text, out decimal cuotaImss);
                decimal.TryParse(TB_CuotaSindical.Text, out decimal cuotaSindical);

                Recibo_Nomina reciboCalculado = nominaService.CalcularNomina(
                    empleado, diasTrabajados, aguinaldo, bonoPuntualidad,
                    bonoAsistencia, cuotaImss, cuotaSindical
                );


                DateTime fechaSeleccionada = FechaADMINNomina.Value;
                DateTime fechaDeNomina = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, 1);
                Nomina nomina = new Nomina
                {
                    fecha = fechaDeNomina,
                    estatus = "Calculada",
                    id_empleado = idEmpleado
                };

                int idNominaNueva; 
                int resultadoNomina = NominaDAO.InsertarNomina(nomina, out idNominaNueva);

                if (resultadoNomina <= 0 || idNominaNueva <= 0)
                {
                    MessageBox.Show("Error: No se pudo registrar la nómina principal.");
                    return;
                }
                reciboCalculado.id_nomina = idNominaNueva;
                reciboCalculado.fecha = fechaDeNomina;

                int resultadoRecibo = ReciboNominaDAO.InsertarReciboNomina(reciboCalculado);
                if (resultadoRecibo <= 0)
                {
                    MessageBox.Show("Error: Se guardó la nómina, pero no el recibo detallado.");
                    return;
                }

                List<Recibo_Nomina> listaParaMostrar = new List<Recibo_Nomina>();
                listaParaMostrar.Add(reciboCalculado);
                VistaNOMINAAUX.DataSource = listaParaMostrar;

                try
                {
                    VistaNOMINAAUX.Columns["sueldo_bruto"].HeaderText = "Sueldo Bruto";
                    VistaNOMINAAUX.Columns["sueldo_neto"].HeaderText = "Sueldo Neto";
                    VistaNOMINAAUX.Columns["percepciones"].HeaderText = "Total Percepciones";
                    VistaNOMINAAUX.Columns["deducciones"].HeaderText = "Total Deducciones";
                    VistaNOMINAAUX.Columns["id_nomina"].HeaderText = "ID Nómina";

                    if (VistaNOMINAAUX.Columns.Contains("id_recibo"))
                    {
                        VistaNOMINAAUX.Columns["id_recibo"].Visible = false;
                    }

                    if (VistaNOMINAAUX.Columns.Contains("Nomina"))
                    {
                        VistaNOMINAAUX.Columns["Nomina"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al renombrar columnas: " + ex.Message);
                }


                MessageBox.Show("Nómina calculada y guardada en la Base de Datos con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al calcular: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }
        //Metodo para cerrar completamente el programa
        private void Form9_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form9_FormClosed;
            ComboBoxEmpresaPuesto.DataSource = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuesto.DisplayMember = "nombre";
            ComboBoxEmpresaPuesto.ValueMember = "id_empresa";
            ComboBoxDepartamentoPuesto.SelectedIndex = -1;
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
