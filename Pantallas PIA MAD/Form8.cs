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
            if (string.IsNullOrWhiteSpace(TB_NumDepaADMIN.Text) || string.IsNullOrWhiteSpace(TB_NumEMPADMIN.Text))
            {
                MessageBox.Show("Ingresa nombre y número del departamento.");
                return;
            }

            if (ComboBoxEmpresa.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una empresa.");
                return;
            }

            bool exito = false;

            try
            {
                // Obtenemos el objeto empresa completo
                var empresaSeleccionada = (RegistroEmpresa)ComboBoxEmpresa.SelectedItem;

                Departamento depto = new Departamento
                {
                    nombre = TB_NumDepaADMIN.Text,
                    numero = int.Parse(TB_NumEMPADMIN.Text),
                    id_empresa = empresaSeleccionada.id_empresa
                };

                // --- El TRY ahora SÓLO protege la inserción ---
                int resultado = DepartamentoDAO.InsertarDepartamento(depto);

                if (resultado > 0)
                {
                    exito = true; // ¡Se logró!
                }
                else
                {
                    MessageBox.Show("Error al registrar el departamento.");
                }
            }
            catch (Exception ex)
            {
                // Si hay un error, lo mostramos
                MessageBox.Show("Error: " + ex.Message);
            }

            // --- El refrescado va AFUERA ---
            // Si el guardado fue exitoso, entonces refrescamos.
            if (exito)
            {
                MessageBox.Show("Departamento registrado correctamente.");
                TB_NumDepaADMIN.Clear();
                TB_NumEMPADMIN.Clear();

                // Si refrescar falla, ahora sí verás el error de refrescar,
                // no el error "genérico"
                refrescarDepartamentos();
            }
        }

        // Refrescar la vista de departamentos
        private void refrescarDepartamentos()
        {
            Vista_Departamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();
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
            if (string.IsNullOrWhiteSpace(TB_NombrePuesto.Text) || string.IsNullOrWhiteSpace(TB_NumPuesto.Text))
            {
                MessageBox.Show("Ingresa nombre y número del puesto.");
                return;
            }

            if (ComboBoxDepartamentoPuesto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona primero un departamento.");
                return;
            }

            try
            {
                Puesto puesto = new Puesto
                {
                    nombre = TB_NombrePuesto.Text,
                    descripcion = TB_DescripcionPuesto.Text,
                    numero = int.Parse(TB_NumPuesto.Text),
                    id_departamento = (int)ComboBoxDepartamentoPuesto.SelectedValue
                };

                int resultado = PuestoDAO.InsertarPuesto(puesto);

                if (resultado > 0)
                {
                    MessageBox.Show("Puesto registrado correctamente.");
                    TB_NombrePuesto.Clear();
                    TB_DescripcionPuesto.Clear();
                    TB_NumPuesto.Clear();
                }
                else
                {
                    MessageBox.Show("Error al registrar el puesto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            CargarEmpresas();        // Para agregar departamento
            CargarEmpresasPuesto();  // Para agregar puesto
            refrescarDepartamentos();
        }


    }
}
