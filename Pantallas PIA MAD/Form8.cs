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

            // Cargar empresas para ambas secciones
            CargarEmpresas();        // Para agregar departamento
            CargarEmpresasPuesto();  // Para agregar puesto

            refrescarDepartamentos();
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

            try
            {
                Departamento depto = new Departamento
                {
                    nombre = TB_NumDepaADMIN.Text,
                    numero = int.Parse(TB_NumEMPADMIN.Text),
                    id_empresa = (int)ComboBoxEmpresa.SelectedValue
                };

                int resultado = DepartamentoDAO.InsertarDepartamento(depto);

                if (resultado > 0)
                {
                    MessageBox.Show("Departamento registrado correctamente.");
                    TB_NumDepaADMIN.Clear();
                    TB_NumEMPADMIN.Clear();
                    refrescarDepartamentos();
                }
                else
                {
                    MessageBox.Show("Error al registrar el departamento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                int idEmpresa = (int)ComboBoxEmpresaPuesto.SelectedValue;
                CargarDepartamentosPuesto(idEmpresa);
            }
            else
            {
                ComboBoxDepartamentoPuesto.DataSource = null;
            }
        }

        // Cargar departamentos según empresa seleccionada (para puestos)
        private void CargarDepartamentosPuesto(int idEmpresa)
        {
            var departamentos = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
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

    }
}
