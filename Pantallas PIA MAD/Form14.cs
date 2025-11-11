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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form14_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Cargar la pantalla y datos de otros lugares 
        private void Form14_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form14_FormClosed;
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

            ComboBoxEmpresaADMIN.DataSource = empresas;
            ComboBoxEmpresaADMIN.DisplayMember = "nombre";
            ComboBoxEmpresaADMIN.ValueMember = "id_empresa";
            ComboBoxEmpresaADMIN.SelectedIndex = -1;
        }
        //Evento para ver las empresas en el ComboBox
        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaADMIN.SelectedIndex != -1)
            {
                try
                {
                    var empresaSel = (RegistroEmpresa)ComboBoxEmpresaADMIN.SelectedItem;
                    int idEmpresa = empresaSel.id_empresa; 
                    CargarDepartamentos(idEmpresa);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar empresa: " + ex.Message);
                }
            }
            else
            {
                ComboBoxDepartamentoADMIN.DataSource = null;
                ComboBoxPuestoADMIN.DataSource = null;
            }
        }

        private void CargarDepartamentos(int idEmpresa)
        {
            var departamentos = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
            ComboBoxDepartamentoADMIN.DataSource = departamentos;
            ComboBoxDepartamentoADMIN.DisplayMember = "nombre";
            ComboBoxDepartamentoADMIN.ValueMember = "id_departamento";
            ComboBoxDepartamentoADMIN.SelectedIndex = -1;
        }
        //Evento para ver tanto los departamentos y puestos en sus respectivos ComboBox
        private void ComboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamentoADMIN.SelectedIndex != -1)
            {
                try
                {
                    var deptoSel = (Departamento)ComboBoxDepartamentoADMIN.SelectedItem;
                    int idDepartamento = deptoSel.id_departamento;
                    CargarPuestos(idDepartamento);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar departamento: " + ex.Message);
                }
            }
            else
            {
                ComboBoxPuestoADMIN.DataSource = null;
            }
        }
        private void CargarPuestos(int idDepartamento)
        {
            var puestos = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);
            ComboBoxPuestoADMIN.DataSource = puestos;
            ComboBoxPuestoADMIN.DisplayMember = "nombre";
            ComboBoxPuestoADMIN.ValueMember = "id_puesto";
            ComboBoxPuestoADMIN.SelectedIndex = -1;
        }

        //Boton para agregar correctamente un empleado a la base de datos 
        private void BTN_AgregarEMPADMIN_Click(object sender, EventArgs e)
        {
            var empresaSel = (RegistroEmpresa)ComboBoxEmpresaADMIN.SelectedItem;
            var deptoSel = (Departamento)ComboBoxDepartamentoADMIN.SelectedItem;
            var puestoSel = (Puesto)ComboBoxPuestoADMIN.SelectedItem;

            string salarioLimpio = TB_SalarioDiarioADMIN.Text.Replace("$", "").Replace(",", "");
            string sdiLimpio = TB_SDInteADMIN.Text.Replace("$", "").Replace(",", "");

            Empleado empleado = new Empleado
            {
                numero_empleado = TB_NumEmpADMIN.Text,
                nombres = TB_NombresADMIN.Text,
                apellido_paterno = TB_APPaternoADMIN.Text,
                apellido_materno = TB_APMaternoADMIN.Text,
                domicilio = TB_DomicilioADMIN.Text,
                telefono = TB_TelefonoADMIN.Text,
                email = TB_EmailADMIN.Text,
                fecha_nacimiento = FechaNac_EMPADMIN.Value.Date,
                curp = TB_CURPADMIN.Text,
                rfc = TB_RFCADMIN.Text,
                nss = TB_NSSADMIN.Text,
                salario = string.IsNullOrEmpty(salarioLimpio) ? (decimal?)null : decimal.Parse(salarioLimpio),
                salario_diario_integrado = string.IsNullOrEmpty(sdiLimpio) ? (decimal?)null : decimal.Parse(sdiLimpio),
                numero_cuenta = TB_NumCuentaADMIN.Text,
                banco = TB_BancoADMIN.Text,

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
        // Metodo para actualizar el DataGridView
        private void RefrescarEmpleados()
        {

            if (Vista_EMPADMIN.Columns["salario"] != null)
            {
                Vista_EMPADMIN.Columns["salario"].DefaultCellStyle.Format = "C2";
            }
            if (Vista_EMPADMIN.Columns["salario_diario_integrado"] != null)
            {
                Vista_EMPADMIN.Columns["salario_diario_integrado"].DefaultCellStyle.Format = "C2";
            }

            Vista_EMPADMIN.DataSource = EmpleadoDAO.ObtenerEmpleados();
            if (Vista_EMPADMIN.Columns["Puesto"] != null)
                Vista_EMPADMIN.Columns["Puesto"].Visible = false;
            if (Vista_EMPADMIN.Columns["Departamento"] != null)
                Vista_EMPADMIN.Columns["Departamento"].Visible = false;
            if (Vista_EMPADMIN.Columns["Empresa"] != null)
                Vista_EMPADMIN.Columns["Empresa"].Visible = false;
        }

        //Metodo para al momento de picarle a un empleado en la vista se rellenen los datos automaticamente para asi verlos o modificarlos
        private void Vista_EMPADMIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Vista_EMPADMIN.Rows[e.RowIndex];

            // Llenamos los TextBox con sus respectivos datos
            TB_NumEmpADMIN.Text = fila.Cells["numero_empleado"].Value?.ToString();
            TB_NombresADMIN.Text = fila.Cells["nombres"].Value?.ToString();
            TB_APPaternoADMIN.Text = fila.Cells["apellido_paterno"].Value?.ToString();
            TB_APMaternoADMIN.Text = fila.Cells["apellido_materno"].Value?.ToString();
            TB_DomicilioADMIN.Text = fila.Cells["domicilio"].Value?.ToString();
            TB_TelefonoADMIN.Text = fila.Cells["telefono"].Value?.ToString();
            TB_EmailADMIN.Text = fila.Cells["email"].Value?.ToString();
            TB_CURPADMIN.Text = fila.Cells["curp"].Value?.ToString();
            TB_RFCADMIN.Text = fila.Cells["rfc"].Value?.ToString();
            TB_NSSADMIN.Text = fila.Cells["nss"].Value?.ToString();
            TB_SalarioDiarioADMIN.Text = fila.Cells["salario"].Value?.ToString();
            TB_SDInteADMIN.Text = fila.Cells["salario_diario_integrado"].Value?.ToString();
            TB_NumCuentaADMIN.Text = fila.Cells["numero_cuenta"].Value?.ToString();
            TB_BancoADMIN.Text = fila.Cells["banco"].Value?.ToString();

            TB_SalarioDiarioADMIN.Text = fila.Cells["salario"].FormattedValue.ToString();
            TB_SDInteADMIN.Text = fila.Cells["salario_diario_integrado"].FormattedValue.ToString();

            if (fila.Cells["fecha_nacimiento"].Value != DBNull.Value)
                FechaNac_EMPADMIN.Value = Convert.ToDateTime(fila.Cells["fecha_nacimiento"].Value);
            else
                FechaNac_EMPADMIN.Value = DateTime.Today;

            // Llenamos los ComboBox depende de lo guardado en cada una
            int idEmpresa = fila.Cells["id_empresa"].Value != DBNull.Value ? Convert.ToInt32(fila.Cells["id_empresa"].Value) : 0;
            int? idDepartamento = fila.Cells["id_departamento"].Value != DBNull.Value ? (int?)Convert.ToInt32(fila.Cells["id_departamento"].Value) : null;
            int? idPuesto = fila.Cells["id_puesto"].Value != DBNull.Value ? (int?)Convert.ToInt32(fila.Cells["id_puesto"].Value) : null;

            if (idEmpresa != 0)
            {
                ComboBoxEmpresaADMIN.SelectedValue = idEmpresa;

                if (idDepartamento.HasValue)
                {
                    CargarDepartamentos(idEmpresa);
                    ComboBoxDepartamentoADMIN.SelectedValue = idDepartamento.Value;

                    if (idPuesto.HasValue)
                    {
                        CargarPuestos(idDepartamento.Value);
                        ComboBoxPuestoADMIN.SelectedValue = idPuesto.Value;
                    }
                    else
                    {
                        ComboBoxPuestoADMIN.SelectedIndex = -1;
                    }
                }
                else
                {
                    ComboBoxDepartamentoADMIN.SelectedIndex = -1;
                    ComboBoxPuestoADMIN.SelectedIndex = -1;
                }
            }
            else
            {
                ComboBoxEmpresaADMIN.SelectedIndex = -1;
                ComboBoxDepartamentoADMIN.SelectedIndex = -1;
                ComboBoxPuestoADMIN.SelectedIndex = -1;
            }
        }

        //Boton Guardar los datos almacenados en la Base de Datos
        private void BTN_GuardarEMPADMIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vista_EMPADMIN.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un empleado para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Convert.ToInt32(Vista_EMPADMIN.CurrentRow.Cells["id_empleado"].Value);

                var empresaSel = (RegistroEmpresa)ComboBoxEmpresaADMIN.SelectedItem;
                var deptoSel = (Departamento)ComboBoxDepartamentoADMIN.SelectedItem;
                var puestoSel = (Puesto)ComboBoxPuestoADMIN.SelectedItem;

                string salarioLimpio = TB_SalarioDiarioADMIN.Text.Replace("$", "").Replace(",", "");
                string sdiLimpio = TB_SDInteADMIN.Text.Replace("$", "").Replace(",", "");

                Empleado empleado = new Empleado
                {
                    id_empleado = idEmpleado,
                    numero_empleado = TB_NumEmpADMIN.Text,
                    nombres = TB_NombresADMIN.Text,
                    apellido_paterno = TB_APPaternoADMIN.Text,
                    apellido_materno = TB_APMaternoADMIN.Text,
                    domicilio = TB_DomicilioADMIN.Text,
                    telefono = TB_TelefonoADMIN.Text,
                    email = TB_EmailADMIN.Text,
                    fecha_nacimiento = FechaNac_EMPADMIN.Value.Date,
                    curp = TB_CURPADMIN.Text,
                    rfc = TB_RFCADMIN.Text,
                    nss = TB_NSSADMIN.Text,
                    salario = string.IsNullOrEmpty(salarioLimpio) ? (decimal?)null : decimal.Parse(salarioLimpio),
                    salario_diario_integrado = string.IsNullOrEmpty(sdiLimpio) ? (decimal?)null : decimal.Parse(sdiLimpio),
                    numero_cuenta = TB_NumCuentaADMIN.Text,
                    banco = TB_BancoADMIN.Text,
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
        private void DepaPues_MEAD_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina_MEAD_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de los reportes
        private void Reportes_MEAD_Click(object sender, EventArgs e)
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
        //Calcular el salario integrado en automatico con el dado en el diario
        private void TB_SalarioDiarioADMIN_Leave(object sender, EventArgs e)
        {
            string salarioLimpio = TB_SalarioDiarioADMIN.Text
                            .Replace("$", "")
                            .Replace(",", "");
            if (decimal.TryParse(TB_SalarioDiarioADMIN.Text, out decimal salarioDiario))
            {
                decimal sdi = salarioDiario * 1.0493m;
                TB_SDInteADMIN.Text = sdi.ToString("C2");
            }
            else
            {
                TB_SDInteADMIN.Text = "";
            }
        }
        //Limpiar todas las casillas de los empleados
        private void BTN_LimpiarEMPADMIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vista_EMPADMIN.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un empleado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idEmpleado = Convert.ToInt32(Vista_EMPADMIN.CurrentRow.Cells["id_empleado"].Value);
                DialogResult confirmacion = MessageBox.Show(
                    "¿Seguro que deseas eliminar este empleado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    int resultado = EmpleadoDAO.EliminarEmpleado(idEmpleado);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
