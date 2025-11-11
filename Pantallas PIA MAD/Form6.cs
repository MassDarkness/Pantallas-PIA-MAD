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
        //Metodo para cerrar completamente el programa
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
            ComboBoxEmpresa.ValueMember = "id_empresa";
            ComboBoxEmpresa.SelectedIndex = -1;
        }
        //Evento para ver las empresas en el ComboBox
        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresa.SelectedIndex != -1)
            {
                try
                {
                    var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;

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
        //Evento para ver tanto los departamentos y puestos en sus respectivos ComboBox
        private void ComboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamento.SelectedIndex != -1)
            {
                try
                {
                    var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
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
        //Boton para agregar correctamente un empleado a la base de datos 
        private void BTN_AgregarEMP_Click(object sender, EventArgs e)
        {
            var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
            var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
            var puestoSel = (Puesto)ComboBoxPuesto.SelectedItem;

            string salarioLimpio = TB_SalarioDiario.Text.Replace("$", "").Replace(",", "");
            string sdiLimpio = TB_SDInte.Text.Replace("$", "").Replace(",", "");

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
                salario = string.IsNullOrEmpty(salarioLimpio) ? (decimal?)null : decimal.Parse(salarioLimpio),
                salario_diario_integrado = string.IsNullOrEmpty(sdiLimpio) ? (decimal?)null : decimal.Parse(sdiLimpio),
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


        // Metodo para actualizar el DataGridView
        private void RefrescarEmpleados()
        {
            if (Vista_EMP.Columns["salario"] != null)
            {
                Vista_EMP.Columns["salario"].DefaultCellStyle.Format = "C2";
            }
            if (Vista_EMP.Columns["salario_diario_integrado"] != null)
            {
                Vista_EMP.Columns["salario_diario_integrado"].DefaultCellStyle.Format = "C2";
            }
            Vista_EMP.DataSource = EmpleadoDAO.ObtenerEmpleados();
            if (Vista_EMP.Columns["Puesto"] != null)
                Vista_EMP.Columns["Puesto"].Visible = false;
            if (Vista_EMP.Columns["Departamento"] != null)
                Vista_EMP.Columns["Departamento"].Visible = false;
            if (Vista_EMP.Columns["Empresa"] != null)
                Vista_EMP.Columns["Empresa"].Visible = false;
        }

        //Metodo para al momento de picarle a un empleado en la vista se rellenen los datos automaticamente para asi verlos o modificarlos
        private void Vista_EMP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Vista_EMP.Rows[e.RowIndex];

            // Llenamos los TextBox con sus respectivos datos
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
            TB_SalarioDiario.Text = fila.Cells["salario"].FormattedValue.ToString();
            TB_SDInte.Text = fila.Cells["salario_diario_integrado"].FormattedValue.ToString();
            if (fila.Cells["fecha_nacimiento"].Value != DBNull.Value)
                FechaNac_EMP.Value = Convert.ToDateTime(fila.Cells["fecha_nacimiento"].Value);
            else
                FechaNac_EMP.Value = DateTime.Today;

            // Llenamos los ComboBox depende de lo guardado en cada una
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

        //Boton Guardar los datos almacenados en la Base de Datos
        private void BTN_GuardarEMP_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vista_EMP.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un empleado para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Convert.ToInt32(Vista_EMP.CurrentRow.Cells["id_empleado"].Value);

                var empresaSel = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
                var deptoSel = (Departamento)ComboBoxDepartamento.SelectedItem;
                var puestoSel = (Puesto)ComboBoxPuesto.SelectedItem;

                string salarioLimpio = TB_SalarioDiario.Text.Replace("$", "").Replace(",", "");
                string sdiLimpio = TB_SDInte.Text.Replace("$", "").Replace(",", "");

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
                    salario = string.IsNullOrEmpty(salarioLimpio) ? (decimal?)null : decimal.Parse(salarioLimpio),
                    salario_diario_integrado = string.IsNullOrEmpty(sdiLimpio) ? (decimal?)null : decimal.Parse(sdiLimpio),
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
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina__MEAU_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
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

        private void TB_SalarioDiario_TextChanged(object sender, EventArgs e)
        {

        }
        //Calcular el salario integral con el diario
        private void TB_SalarioDiario_Leave(object sender, EventArgs e)
        {
            string salarioLimpio = TB_SalarioDiario.Text
                            .Replace("$", "")
                            .Replace(",", "");

            if (decimal.TryParse(TB_SalarioDiario.Text, out decimal salarioDiario))
            {

                decimal sdi = salarioDiario * 1.0493m;

                TB_SDInte.Text = sdi.ToString("C2");
            }
            else
            {
                TB_SDInte.Text = "";
            }
        }
        //Limpiar todas las casillas
        private void BTN_LimpiarEMP_Click(object sender, EventArgs e)
        {
            try
            {

                if (Vista_EMP.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un empleado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Convert.ToInt32(Vista_EMP.CurrentRow.Cells["id_empleado"].Value);


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