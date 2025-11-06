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
            if (comboBox2.SelectedValue == null) 
            {
                MessageBox.Show("Por favor, seleccione un empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asumo que tu TextBox de Días se llama 'txtDiasTrabajados'
            // ¡¡CAMBIA 'txtDiasTrabajados.Text' por el nombre real de tu TextBox!!
            if (!int.TryParse(TB_DiasTrabajados.Text, out int diasTrabajados))
            {
                MessageBox.Show("Días trabajados debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. OBTENER DATOS DE LA UI ---
            try
            {
                // Obtenemos el ID del empleado seleccionado
                int idEmpleado = (int)comboBox2.SelectedValue;

                // Obtenemos el objeto Empleado completo (usando el método NUEVO de la Parte 1)
                Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idEmpleado);
                if (empleado == null)
                {
                    MessageBox.Show("No se pudo encontrar al empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Leemos los TextBoxes (Usamos decimal.TryParse para no crashear)
                // ¡¡RECUERDA CAMBIAR ESTOS NOMBRES POR LOS TUYOS!!
                decimal.TryParse(TB_Aguinaldo.Text, out decimal aguinaldo);
                decimal.TryParse(TB_BNPuntualidad.Text, out decimal bonoPuntualidad);
                decimal.TryParse(TB_BNAsistencia.Text, out decimal bonoAsistencia);
                decimal.TryParse(TB_CuotaIMSS.Text, out decimal cuotaImss);
                decimal.TryParse(TB_CuotaSindical.Text, out decimal cuotaSindical);

                // --- 3. LLAMAR AL CEREBRO ---
                Recibo_Nomina reciboCalculado = nominaService.CalcularNomina(
                    empleado,
                    diasTrabajados,
                    aguinaldo,
                    bonoPuntualidad,
                    bonoAsistencia,
                    cuotaImss,
                    cuotaSindical
                );

                // --- 4. MOSTRAR RESULTADOS ---
                // (Tu DataGridView se llama 'dataGridView1' en tu código)

                // Limpiamos el DataGridView y lo preparamos
                VistaNOMINA.DataSource = null;
                VistaNOMINA.Columns.Clear();
                VistaNOMINA.Columns.Add("Concepto", "Concepto");
                VistaNOMINA.Columns.Add("Monto", "Monto");

                // Añadimos los resultados
                VistaNOMINA.Rows.Add("Sueldo Bruto (Base)", reciboCalculado.sueldo_bruto.ToString("C2"));
                VistaNOMINA.Rows.Add("Total Percepciones", reciboCalculado.percepciones.ToString("C2"));
                VistaNOMINA.Rows.Add("Total Deducciones", reciboCalculado.deducciones.ToString("C2"));
                VistaNOMINA.Rows.Add("--- SUELDO NETO ---", "---");
                VistaNOMINA.Rows.Add("Sueldo Neto a Pagar", reciboCalculado.sueldo_neto.ToString("C2"));

                // --- 5. GUARDAR EN LA BASE DE DATOS (Opcional, pero recomendado) ---

                // a. Crear la nómina
                Nomina nomina = new Nomina
                {
                    fecha = DateTime.Now.Date,
                    estatus = "Calculada",
                    id_empleado = idEmpleado
                };

                // b. Guardarla (tú ya tienes este DAO)
                // ¡¡Falta que tu SP 'sp_RegistrarNomina' DEVUELVA EL ID!!
                // int idNominaNueva = NominaDAO.InsertarNomina(nomina); 

                // c. Asignar ese ID al recibo
                // reciboCalculado.id_nomina = idNominaNueva;

                // d. Guardar el recibo (necesitarás un ReciboNominaDAO.InsertarRecibo)
                // ReciboNominaDAO.InsertarRecibo(reciboCalculado);

                MessageBox.Show("Nómina calculada y mostrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuesto.SelectedValue is int idEmpresa)
            {
                ComboBoxDepartamentoPuesto.DataSource = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
                ComboBoxDepartamentoPuesto.DisplayMember = "nombre";
                ComboBoxDepartamentoPuesto.ValueMember = "id_departamento";
            }
        }

        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamentoPuesto.SelectedValue is int idDepartamento)
            {
                comboBox1.DataSource = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "id_puesto";
            }
        }

        private void comboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int idPuesto)
            {
                comboBox2.DataSource = EmpleadoDAO.ObtenerEmpleadosPorPuesto(idPuesto);
                comboBox2.DisplayMember = "nombres"; 
                comboBox2.ValueMember = "id_empleado";
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
