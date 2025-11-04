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

        // --- CORRECCIÓN 1: Puse un try...catch aquí ---
        // Si CargarEmpresas falla, ahora lo sabrás
        private void Form6_Load_1(object sender, EventArgs e)
        {
            try
            {
                RefrescarEmpleados();
                CargarEmpresas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        public void CargarEmpresas()
        {
            var empresas = EmpresaDAP.ObtenerEmpresas();

            ComboBoxEmpresa.DataSource = empresas;
            ComboBoxEmpresa.DisplayMember = "nombre";

            // --- CORRECCIÓN IMPORTANTE ---
            // Usamos la propiedad que tú dijiste que era la correcta
            ComboBoxEmpresa.ValueMember = "id_empresa"; // O "id_empresa" si me equivoqué

            ComboBoxEmpresa.SelectedIndex = -1;
        }

        // --- CORRECCIÓN 2: Arreglado el InvalidCastException ---
        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresa.SelectedIndex != -1)
            {
                try
                {
                    // Obtenemos el OBJETO completo
                    var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;

                    // Sacamos el ID de adentro del objeto
                    int idEmpresa = empresaSel.id_empresa; // O "id_empresa"

                    CargarDepartamentos(idEmpresa);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar empresa: " + ex.Message);
                }
            }
            else
            {
                ComboBoxDepartamento.DataSource = null;
                ComboBoxPuesto.DataSource = null;
            }
        }

        private void CargarDepartamentos(int idEmpresa)
        {
            var departamentos = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
            ComboBoxDepartamento.DataSource = departamentos;
            ComboBoxDepartamento.DisplayMember = "nombre";
            ComboBoxDepartamento.ValueMember = "id_departamento";
            ComboBoxDepartamento.SelectedIndex = -1;
        }

        // --- CORRECCIÓN 3: Arreglado el InvalidCastException ---
        private void ComboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamento.SelectedIndex != -1)
            {
                try
                {
                    var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
                    int idDepartamento = deptoSel.id_departamento;

                    // ¡Ves! Esta función es la que llama a CargarPuestos
                    CargarPuestos(idDepartamento);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar departamento: " + ex.Message);
                }
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
            ComboBoxPuesto.DisplayMember = "nombre";
            ComboBoxPuesto.ValueMember = "id_puesto";
            ComboBoxPuesto.SelectedIndex = -1;
        }

        // --- CORRECCIÓN 4: Lógica de Agregar completada ---
        private void BTN_AgregarEMP_Click(object sender, EventArgs e)
        {
            var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
            var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
            var puestoSel = (Puesto)ComboBoxPuesto.SelectedItem;

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

                // Sacamos los IDs de los objetos
                id_empresa = empresaSel.id_empresa, // O "id_empresa"
                id_departamento = deptoSel.id_departamento,
                id_puesto = puestoSel.id_puesto
            };

            // --- CORRECCIÓN 5: Faltaba llamar al DAO para insertar ---
            // (Asumo que tu método se llama así)
            int resultado = EmpleadoDAO.InsertarEmpleado(empleado);

            if (resultado < 0)
            {
                MessageBox.Show("Empleado registrado con éxito.");
                RefrescarEmpleados();
                // Aquí deberías limpiar los campos
                // LimpiarCampos(); 
            }
            else
            {
                MessageBox.Show("Error: No se pudo registrar el empleado.");
            }
        }


        // Método para actualizar el DataGridView
        private void RefrescarEmpleados()
        {
            Vista_EMP.DataSource = EmpleadoDAO.ObtenerEmpleados();
            if (Vista_EMP.Columns["Puesto"] != null)
                Vista_EMP.Columns["Puesto"].Visible = false;
            if (Vista_EMP.Columns["Departamento"] != null)
                Vista_EMP.Columns["Departamento"].Visible = false;
            if (Vista_EMP.Columns["Empresa"] != null)
                Vista_EMP.Columns["Empresa"].Visible = false;
        }
    }
}