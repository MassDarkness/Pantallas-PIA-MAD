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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            RefrescarEmpleados();
            CargarEmpresas();
        }
        private void CargarEmpresas()
        {
            // Obtener empresas desde la base de datos
            var empresas = EmpresaDAP.ObtenerEmpresas();

            ComboBoxEmpresa.DataSource = empresas;
            ComboBoxEmpresa.DisplayMember = "nombre"; // lo que se verá en el combo
            ComboBoxEmpresa.ValueMember = "id_empresa"; // el ID real
            ComboBoxEmpresa.SelectedIndex = -1; // opción inicial vacía
        }

        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresa.SelectedIndex != -1)
            {
                int idEmpresa = (int)ComboBoxEmpresa.SelectedValue;
                CargarDepartamentos(idEmpresa);
            }
            else
            {
                ComboBoxDepartamento.DataSource = null;
                ComboBoxPuesto.DataSource = null;
            }
        }

        private void CargarDepartamentos(int idEmpresa)
        {
            // Obtener departamentos por empresa
            var departamentos = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);

            ComboBoxDepartamento.DataSource = departamentos;
            ComboBoxDepartamento.DisplayMember = "nombre"; // nombre del departamento
            ComboBoxDepartamento.ValueMember = "id_departamento";
            ComboBoxDepartamento.SelectedIndex = -1;
        }

        private void ComboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamento.SelectedIndex != -1)
            {
                int idDepartamento = (int)ComboBoxDepartamento.SelectedValue;
                CargarPuestos(idDepartamento);
            }
            else
            {
                ComboBoxPuesto.DataSource = null;
            }
        }

        private void CargarPuestos(int idDepartamento)
        {
            var puestos = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);

            ComboBoxPuesto.DataSource = puestos;
            ComboBoxPuesto.DisplayMember = "nombre"; // nombre del puesto
            ComboBoxPuesto.ValueMember = "id_puesto";
            ComboBoxPuesto.SelectedIndex = -1;
        }


        private void BTN_AgregarEMP_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado
            {
                numero_empleado = TB_NumEmp.Text,
                nombres = TB_Nombres.Text,
                apellido_paterno = TB_APPaterno.Text,
                apellido_materno = TB_APMaterno.Text,
                domicilio = TB_Domicilio.Text,
                telefono = TB_Telefono.Text,
                email = TB_Email.Text,
                fecha_nacimiento = FechaNac_EMP.Value.Date,
                curp = TB_CURP.Text,
                rfc = TB_RFC.Text,
                nss = TB_NSS.Text,
                salario = string.IsNullOrEmpty(TB_SalarioDiario.Text) ? (decimal?)null : decimal.Parse(TB_SalarioDiario.Text),
                salario_diario_integrado = string.IsNullOrEmpty(TB_SDInte.Text) ? (decimal?)null : decimal.Parse(TB_SDInte.Text),
                numero_cuenta = TB_NumCuenta.Text,
                banco = TB_Banco.Text,
                id_empresa = (int)ComboBoxEmpresa.SelectedValue,
                id_departamento = (int)ComboBoxDepartamento.SelectedValue,
                id_puesto = (int)ComboBoxPuesto.SelectedValue
            };

            RefrescarEmpleados();
        }


        // Método para actualizar el DataGridView
        private void RefrescarEmpleados()
        {
            Vista_EMP.DataSource = EmpleadoDAO.ObtenerEmpleados();
        }
    }
}
