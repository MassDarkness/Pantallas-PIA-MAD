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
        }

        private void refrescar()
        {
            Vista_Empresa.DataSource = EmpresaDAP.ObtenerEmpresas();
        }
    }

}
