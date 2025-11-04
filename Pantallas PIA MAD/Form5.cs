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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void BTN_GuardarEMP_Click(object sender, EventArgs e)
        {
            RegistroEmpresa Empresa = new RegistroEmpresa();
            Empresa.nombre = TB_Nombre.Text;
            Empresa.razon_social = TB_RazonSocial.Text;
            Empresa.RFC=TB_RFC.Text;
            Empresa.registro_patronal = TB_RegistroPa.Text;
            Empresa.domicilio_fiscal = TB_DomicilioFi.Text;
            Empresa.contacto = TB_Contacto.Text;
            Empresa.fecha_inicio_operaciones = FechaInicio_Empresa.Value.Date;
            EmpresaDAP.InsertarEmpresa(Empresa);
            refrescar();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Vista_Empresa.DataSource = EmpresaDAP.ObtenerEmpresas();
            this.FormClosed += Form5_FormClosed;
        }

        private void refrescar()
        {
            Vista_Empresa.DataSource = EmpresaDAP.ObtenerEmpresas();
        }

        private void Usuarios_MEAD_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void DepaPues__MEAD_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void Nomina_MEAD_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void Reporte_MEAD_Click(object sender, EventArgs e)
        {
            Form11 form10 = new Form11();
            form10.Show();
            this.Hide();
        }

        private void Salir_MEAD_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
