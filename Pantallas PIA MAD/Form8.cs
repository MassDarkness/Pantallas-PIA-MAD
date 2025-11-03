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

            int resultado = DepartamentoDAO.InsertarDepartamento(depto);
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


    }
}
