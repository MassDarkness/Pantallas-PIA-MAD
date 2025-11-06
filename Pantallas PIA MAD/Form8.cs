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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void CargarEmpresas()
        {
            var empresas = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresa.DataSource = empresas;
            ComboBoxEmpresa.DisplayMember = "nombre";
            ComboBoxEmpresa.ValueMember = "id_empresa";
            ComboBoxEmpresa.SelectedIndex = -1;
        }

        // Botón Agregar Departamento a la base de datos
        private void BTN_AñadirDepa_Click(object sender, EventArgs e)
        {
            var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;

            Departamento depto = new Departamento
            {
                nombre = TB_NumDepaADMIN.Text,
                numero = int.Parse(TB_NumEMPADMIN.Text),
                id_empresa = empresaSeleccionada.id_empresa
            };

            DepartamentoDAO.InsertarDepartamento(depto);
            MessageBox.Show("Departamento registrado correctamente.");
            TB_NumDepaADMIN.Clear();
            TB_NumEMPADMIN.Clear();

            refrescarDepartamentos();
        }
        private void refrescarDepartamentos()
        {
            Vista_Departamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();
        }

        private void refrescarPuestos()
        {
            Vista_PuestoADMIN.DataSource = PuestoDAO.ObtenerTodosLosPuestos();
        }

        private void CargarEmpresasPuesto()
        {
            var empresas = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuesto.DataSource = empresas;
            ComboBoxEmpresaPuesto.DisplayMember = "nombre";
            ComboBoxEmpresaPuesto.ValueMember = "id_empresa";
            ComboBoxEmpresaPuesto.SelectedIndex = -1;
        }
        //Evento al seleccionar una empresa se muestre
        private void ComboBoxEmpresaPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuesto.SelectedIndex != -1)
            {
                try
                {
                    var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresaPuesto.SelectedItem;

                    int idEmpresa = empresaSeleccionada.id_empresa;

                    CargarDepartamentosPuesto(idEmpresa);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                ComboBoxDepartamentoPuesto.DataSource = null;
            }
        }

        // Cargar departamentos según empresa seleccionada (para puestos)
        private void CargarDepartamentosPuesto(int id_empresa)
        {
            var departamentos = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(id_empresa);
            ComboBoxDepartamentoPuesto.DataSource = departamentos;
            ComboBoxDepartamentoPuesto.DisplayMember = "nombre";
            ComboBoxDepartamentoPuesto.ValueMember = "id_departamento";
            ComboBoxDepartamentoPuesto.SelectedIndex = -1;
        }

        // Boton agregar Puesto en la base de datos
        private void BTN_AñadirPuestoADMIN_Click(object sender, EventArgs e)
        {
            Puesto puesto = new Puesto
            {
                nombre = TB_NombrePuesto.Text,
                descripcion = TB_DescripcionPuesto.Text,
                numero = int.Parse(TB_NumPuesto.Text),
                id_departamento = (int)ComboBoxDepartamentoPuesto.SelectedValue
            };
            PuestoDAO.InsertarPuesto(puesto);
            MessageBox.Show("Puesto registrado correctamente.");
            TB_NombrePuesto.Clear();
            TB_DescripcionPuesto.Clear();
            TB_NumPuesto.Clear();
            refrescarPuestos();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            CargarEmpresas();       
            CargarEmpresasPuesto();  
            refrescarDepartamentos();
            refrescarPuestos();
            this.FormClosed += Form8_FormClosed;
        }
        //Al seleccionar un Puesto en la vista se rellenen los datos automaticamentes
        private void Vista_PuestoADMIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = Vista_PuestoADMIN.Rows[e.RowIndex];

            TB_NombrePuesto.Text = fila.Cells["nombre"].Value?.ToString();
            TB_DescripcionPuesto.Text = fila.Cells["descripcion"].Value?.ToString();
            TB_NumPuesto.Text = fila.Cells["numero"].Value?.ToString();

            if (fila.Cells["id_departamento"].Value != null)
            {
                int idDepartamento = Convert.ToInt32(fila.Cells["id_departamento"].Value);

                ComboBoxDepartamentoPuesto.SelectedValue = idDepartamento;
                var departamento = DepartamentoDAO.ObtenerDepartamentoPorId(idDepartamento);
                if (departamento != null)
                {
                    ComboBoxEmpresaPuesto.SelectedValue = departamento.id_empresa;
                    CargarDepartamentosPuesto(departamento.id_empresa);
                    ComboBoxDepartamentoPuesto.SelectedValue = idDepartamento;
                }
            }
        }

        //Boton para editar Puestos ya almacenados en la Base de Datos
        private void BTN_EditarPuestoADMIN_Click(object sender, EventArgs e)
        {
            if (Vista_PuestoADMIN.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un puesto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPuesto = Convert.ToInt32(Vista_PuestoADMIN.CurrentRow.Cells["id_puesto"].Value);

                if (ComboBoxDepartamentoPuesto.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Puesto puesto = new Puesto
                {
                    id_puesto = idPuesto,
                    nombre = TB_NombrePuesto.Text,
                    descripcion = TB_DescripcionPuesto.Text,
                    numero = int.TryParse(TB_NumPuesto.Text, out int num) ? num : (int?)null,
                    id_departamento = (int)ComboBoxDepartamentoPuesto.SelectedValue
                };

                int resultado = PuestoDAO.ActualizarPuesto(puesto);

                if (resultado > 0)
                {
                    MessageBox.Show("Puesto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescarPuestos();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el puesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el puesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Empresas agregadas se vean en el ComboBox de Empresas
        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresa.SelectedIndex != -1)
            {
                var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
                int idEmpresa = empresaSeleccionada.id_empresa;
            }
        }
        //Al seleccionar un departamento en la vista se rellenen los datos automaticamentes
        private void Vista_Departamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = Vista_Departamento.Rows[e.RowIndex];

            TB_NumDepaADMIN.Text = fila.Cells["nombre"].Value?.ToString();
            TB_NumEMPADMIN.Text = fila.Cells["numero"].Value?.ToString();

            if (fila.Cells["id_empresa"].Value != null)
            {
                int idEmpresa = Convert.ToInt32(fila.Cells["id_empresa"].Value);
                ComboBoxEmpresa.SelectedIndexChanged -= ComboBoxEmpresa_SelectedIndexChanged;
                ComboBoxEmpresa.SelectedValue = idEmpresa;
                ComboBoxEmpresa.SelectedIndexChanged += ComboBoxEmpresa_SelectedIndexChanged;
            }
        }
        //Boton para editar Departamentos ya almacenados en la Base de Datos
        private void BTN_EditarDepa_Click(object sender, EventArgs e)
        {
            if (Vista_Departamento.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un departamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idDepa = Convert.ToInt32(Vista_Departamento.CurrentRow.Cells["id_departamento"].Value);

                if (ComboBoxEmpresa.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona una empresa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Departamento depto = new Departamento
                {
                    id_departamento = idDepa,
                    nombre = TB_NumDepaADMIN.Text,
                    numero = int.TryParse(TB_NumEMPADMIN.Text, out int num) ? num : 0,
                    id_empresa = (int)ComboBoxEmpresa.SelectedValue
                };

                int resultado = DepartamentoDAO.ActualizarDepartamento(depto);

                if (resultado > 0)
                {
                    MessageBox.Show("Departamento actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescarDepartamentos();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina_MEAD_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
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

        private void EliminarDEPAdmin_Click(object sender, EventArgs e)
        {
            if (Vista_Departamento.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un departamento para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este departamento?\n\nSe eliminarán también sus puestos y empleados relacionados.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No)
                return;

            try
            {
                int idDepartamento = Convert.ToInt32(Vista_Departamento.CurrentRow.Cells["id_departamento"].Value);

                int resultado = DepartamentoDAO.EliminarDepartamento(idDepartamento);

                if (resultado > 0)
                {
                    MessageBox.Show("Departamento eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescarDepartamentos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el departamento o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void EliminarPuesAdmin_Click(object sender, EventArgs e)
        {
            if (Vista_PuestoADMIN.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un puesto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este puesto?\n\nSe eliminarán también los empleados relacionados (si existen).",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No)
                return;

            try
            {
                int idPuesto = Convert.ToInt32(Vista_PuestoADMIN.CurrentRow.Cells["id_puesto"].Value);
                
                int resultado = PuestoDAO.EliminarPuesto(idPuesto);

                if (resultado > 0)
                {
                    MessageBox.Show("Puesto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescarPuestos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el puesto o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el puesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
