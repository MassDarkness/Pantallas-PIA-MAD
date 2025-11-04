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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form6_Load_1(object sender, EventArgs e)
        {
            this.FormClosed += Form6_FormClosed;
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

                id_empresa = empresaSel.id_empresa,
                id_departamento = deptoSel.id_departamento,
                id_puesto = puestoSel.id_puesto
            };

            int resultado = EmpleadoDAO.InsertarEmpleado(empleado);

            if (resultado < 0)
            {
                MessageBox.Show("Empleado registrado con éxito.");
                RefrescarEmpleados();

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

        private void Vista_EMP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita que se ejecute al dar click en el header

            DataGridViewRow fila = Vista_EMP.Rows[e.RowIndex];

            // Llenamos los TextBox
            TB_NumEmp.Text = fila.Cells["numero_empleado"].Value?.ToString();
            TB_Nombres.Text = fila.Cells["nombres"].Value?.ToString();
            TB_APPaterno.Text = fila.Cells["apellido_paterno"].Value?.ToString();
            TB_APMaterno.Text = fila.Cells["apellido_materno"].Value?.ToString();
            TB_Domicilio.Text = fila.Cells["domicilio"].Value?.ToString();
            TB_Telefono.Text = fila.Cells["telefono"].Value?.ToString();
            TB_Email.Text = fila.Cells["email"].Value?.ToString();
            TB_CURP.Text = fila.Cells["curp"].Value?.ToString();
            TB_RFC.Text = fila.Cells["rfc"].Value?.ToString();
            TB_NSS.Text = fila.Cells["nss"].Value?.ToString();
            TB_SalarioDiario.Text = fila.Cells["salario"].Value?.ToString();
            TB_SDInte.Text = fila.Cells["salario_diario_integrado"].Value?.ToString();
            TB_NumCuenta.Text = fila.Cells["numero_cuenta"].Value?.ToString();
            TB_Banco.Text = fila.Cells["banco"].Value?.ToString();

            // Llenamos el DateTimePicker
            if (fila.Cells["fecha_nacimiento"].Value != DBNull.Value)
                FechaNac_EMP.Value = Convert.ToDateTime(fila.Cells["fecha_nacimiento"].Value);
            else
                FechaNac_EMP.Value = DateTime.Today;

            // Llenamos los ComboBox
            int idEmpresa = fila.Cells["id_empresa"].Value != DBNull.Value ? Convert.ToInt32(fila.Cells["id_empresa"].Value) : 0;
            int? idDepartamento = fila.Cells["id_departamento"].Value != DBNull.Value ? (int?)Convert.ToInt32(fila.Cells["id_departamento"].Value) : null;
            int? idPuesto = fila.Cells["id_puesto"].Value != DBNull.Value ? (int?)Convert.ToInt32(fila.Cells["id_puesto"].Value) : null;

            if (idEmpresa != 0)
            {
                ComboBoxEmpresa.SelectedValue = idEmpresa;

                if (idDepartamento.HasValue)
                {
                    CargarDepartamentos(idEmpresa);
                    ComboBoxDepartamento.SelectedValue = idDepartamento.Value;

                    if (idPuesto.HasValue)
                    {
                        CargarPuestos(idDepartamento.Value);
                        ComboBoxPuesto.SelectedValue = idPuesto.Value;
                    }
                    else
                    {
                        ComboBoxPuesto.SelectedIndex = -1;
                    }
                }
                else
                {
                    ComboBoxDepartamento.SelectedIndex = -1;
                    ComboBoxPuesto.SelectedIndex = -1;
                }
            }
            else
            {
                ComboBoxEmpresa.SelectedIndex = -1;
                ComboBoxDepartamento.SelectedIndex = -1;
                ComboBoxPuesto.SelectedIndex = -1;
            }
        }

        private void BTN_GuardarEMP_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vista_EMP.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un empleado para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtén el ID del empleado seleccionado
                int idEmpleado = Convert.ToInt32(Vista_EMP.CurrentRow.Cells["id_empleado"].Value);

                var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
                var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
                var puestoSel = (Puesto)ComboBoxPuesto.SelectedItem;

                Empleado empleado = new Empleado
                {
                    id_empleado = idEmpleado,
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
                    id_empresa = empresaSel?.id_empresa ?? 0,
                    id_departamento = deptoSel?.id_departamento,
                    id_puesto = puestoSel?.id_puesto
                };

                int resultado = EmpleadoDAO.ActualizarEmpleado(empleado);

                if (resultado > 0)
                {
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarEmpleados();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nomina__MEAU_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }

        private void Reportes__MEAU_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void Salir__MEAU_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}