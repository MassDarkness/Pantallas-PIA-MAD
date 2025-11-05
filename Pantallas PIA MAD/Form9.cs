using Pantallas_PIA_MAD.DAO;
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

        private void button5_Click(object sender, EventArgs e)
        {

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
                comboBox2.DisplayMember = "nombres"; // o el nombre completo si lo tienes concatenado
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
