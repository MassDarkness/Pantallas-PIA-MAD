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


        // Cargar empresas para la sección de departamento
        private void CargarEmpresas()
        {
            var empresas = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresa.DataSource = empresas;
            ComboBoxEmpresa.DisplayMember = "nombre";
            ComboBoxEmpresa.ValueMember = "id_empresa";
            ComboBoxEmpresa.SelectedIndex = -1;
        }

        // Botón Agregar Departamento
        private void BTN_AñadirDepa_Click(object sender, EventArgs e)
        {
            // Obtenemos el objeto empresa completo
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

        // Refrescar la vista de departamentos
        private void refrescarDepartamentos()
        {
            Vista_Departamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();
        }

        private void refrescarPuestos()
        {
            Vista_PuestoADMIN.DataSource = PuestoDAO.ObtenerTodosLosPuestos();
        }


        // Cargar empresas para la sección de puesto
        private void CargarEmpresasPuesto()
        {
            var empresas = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuesto.DataSource = empresas;
            ComboBoxEmpresaPuesto.DisplayMember = "nombre";
            ComboBoxEmpresaPuesto.ValueMember = "id_empresa";
            ComboBoxEmpresaPuesto.SelectedIndex = -1;
        }

        // Evento: cuando se selecciona empresa para agregar puesto
        private void ComboBoxEmpresaPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuesto.SelectedIndex != -1)
            {
                try
                {
                    // 1. Arreglamos el Problema #1 (la conversión de tipo)
                    var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresaPuesto.SelectedItem;

                    // 2. Arreglamos el Problema #2 (el nombre de la propiedad)
                    // Usamos el nombre 'idempresa' (sin guion bajo) que tú identificaste
                    int idEmpresa = empresaSeleccionada.id_empresa;

                    // 3. Con el ID, cargamos los departamentos
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

        // Botón Agregar Puesto
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
            CargarEmpresas();        // Para agregar departamento
            CargarEmpresasPuesto();  // Para agregar puesto
            refrescarDepartamentos();
            refrescarPuestos();
        }

        private void Vista_PuestoADMIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = Vista_PuestoADMIN.Rows[e.RowIndex];

            // Llenamos los TextBox con los valores de la fila seleccionada
            TB_NombrePuesto.Text = fila.Cells["nombre"].Value?.ToString();
            TB_DescripcionPuesto.Text = fila.Cells["descripcion"].Value?.ToString();
            TB_NumPuesto.Text = fila.Cells["numero"].Value?.ToString();

            // Si tienes columnas con los IDs (necesario para vincular los ComboBox)
            if (fila.Cells["id_departamento"].Value != null)
            {
                int idDepartamento = Convert.ToInt32(fila.Cells["id_departamento"].Value);

                // Buscamos el departamento al que pertenece el puesto
                ComboBoxDepartamentoPuesto.SelectedValue = idDepartamento;

                // Si además tienes la empresa relacionada, podrías hacer algo así:
                var departamento = DepartamentoDAO.ObtenerDepartamentoPorId(idDepartamento);
                if (departamento != null)
                {
                    ComboBoxEmpresaPuesto.SelectedValue = departamento.id_empresa;
                    CargarDepartamentosPuesto(departamento.id_empresa);
                    ComboBoxDepartamentoPuesto.SelectedValue = idDepartamento;
                }
            }
        }


        private void BTN_EditarPuestoADMIN_Click(object sender, EventArgs e)
        {
            if (Vista_PuestoADMIN.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un puesto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenemos el id del puesto seleccionado en el DataGridView
                int idPuesto = Convert.ToInt32(Vista_PuestoADMIN.CurrentRow.Cells["id_puesto"].Value);

                // Validamos que se haya seleccionado un departamento
                if (ComboBoxDepartamentoPuesto.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Creamos el objeto Puesto con los datos editados
                Puesto puesto = new Puesto
                {
                    id_puesto = idPuesto,
                    nombre = TB_NombrePuesto.Text,
                    descripcion = TB_DescripcionPuesto.Text,
                    numero = int.TryParse(TB_NumPuesto.Text, out int num) ? num : (int?)null,
                    id_departamento = (int)ComboBoxDepartamentoPuesto.SelectedValue
                };

                // Llamamos al método de actualización
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

        private void ComboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresa.SelectedIndex != -1)
            {
                var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;
                int idEmpresa = empresaSeleccionada.id_empresa;
            }
        }

        private void Vista_Departamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita header clicks

            DataGridViewRow fila = Vista_Departamento.Rows[e.RowIndex];

            // Llenamos los TextBox con los valores de la fila
            TB_NumDepaADMIN.Text = fila.Cells["nombre"].Value?.ToString();
            TB_NumEMPADMIN.Text = fila.Cells["numero"].Value?.ToString();

            // Si tienes columna con el id de la empresa
            if (fila.Cells["id_empresa"].Value != null)
            {
                int idEmpresa = Convert.ToInt32(fila.Cells["id_empresa"].Value);

                // 🔒 Desactivamos el evento temporalmente para evitar recarga innecesaria
                ComboBoxEmpresa.SelectedIndexChanged -= ComboBoxEmpresa_SelectedIndexChanged;

                // Seleccionamos la empresa correcta
                ComboBoxEmpresa.SelectedValue = idEmpresa;

                // 🔓 Reactivamos el evento
                ComboBoxEmpresa.SelectedIndexChanged += ComboBoxEmpresa_SelectedIndexChanged;
            }
        }

        private void BTN_EditarDepa_Click(object sender, EventArgs e)
        {
            if (Vista_Departamento.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un departamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenemos el id del departamento seleccionado
                int idDepa = Convert.ToInt32(Vista_Departamento.CurrentRow.Cells["id_departamento"].Value);

                // Validamos que se haya seleccionado una empresa
                if (ComboBoxEmpresa.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona una empresa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Creamos el objeto Departamento con los datos editados
                Departamento depto = new Departamento
                {
                    id_departamento = idDepa,
                    nombre = TB_NumDepaADMIN.Text,
                    numero = int.TryParse(TB_NumEMPADMIN.Text, out int num) ? num : 0,
                    id_empresa = (int)ComboBoxEmpresa.SelectedValue
                };

                // Llamamos al método de actualización
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

    }

}
