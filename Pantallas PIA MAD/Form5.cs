using Pantallas_PIA_MAD.DAO;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void BTN_GuardarEMP_Click(object sender, EventArgs e)
        {
            RegistroEmpresa Empresa = new RegistroEmpresa();
            Empresa.nombre = TB_Nombre.Text;
            Empresa.razon_social = TB_RazonSocial.Text;
            Empresa.RFC=TB_RFC.Text;
            Empresa.registro_patronal = TB_RegistroPa.Text;
            Empresa.domicilio_fiscal = TB_DomicilioFi.Text;
            Empresa.contacto = TB_Contacto.Text;
            Empresa.fecha_inicio_operaciones = FechaInicio_Empresa.Value.Date;
            EmpresaDAP.InsertarEmpresa(Empresa);
            refrescar();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Vista_Empresa.DataSource = EmpresaDAP.ObtenerEmpresas();
            this.FormClosed += Form5_FormClosed;
        }

        private void refrescar()
        {
            Vista_Empresa.DataSource = EmpresaDAP.ObtenerEmpresas();
        }

        private void Usuarios_MEAD_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void DepaPues__MEAD_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        //halo

        private void Nomina_MEAD_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void Reporte_MEAD_Click(object sender, EventArgs e)
        {
            Form11 form10 = new Form11();
            form10.Show();
            this.Hide();
        }

        private void Salir_MEAD_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Vista_Empresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = Vista_Empresa.Rows[e.RowIndex];

            // Llena los TextBox con los valores de la fila seleccionada
            TB_Nombre.Text = fila.Cells["nombre"].Value?.ToString();
            TB_RazonSocial.Text = fila.Cells["razon_social"].Value?.ToString();
            TB_RFC.Text = fila.Cells["RFC"].Value?.ToString();
            TB_RegistroPa.Text = fila.Cells["registro_patronal"].Value?.ToString();
            TB_DomicilioFi.Text = fila.Cells["domicilio_fiscal"].Value?.ToString();
            TB_Contacto.Text = fila.Cells["contacto"].Value?.ToString();

            // Si tienes la fecha en una columna tipo DateTime
            if (fila.Cells["fecha_inicio_operaciones"].Value != null)
                FechaInicio_Empresa.Value = Convert.ToDateTime(fila.Cells["fecha_inicio_operaciones"].Value);
        }

        private void BTN_EditarEMP_Click(object sender, EventArgs e)
        {
            if (Vista_Empresa.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una empresa para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenemos el ID de la fila seleccionada
                int id_empresa = Convert.ToInt32(Vista_Empresa.CurrentRow.Cells["id_empresa"].Value);

                // Creamos el objeto con los nuevos valores
                RegistroEmpresa empresa = new RegistroEmpresa();
                empresa.id_empresa = id_empresa;
                empresa.nombre = TB_Nombre.Text;
                empresa.razon_social = TB_RazonSocial.Text;
                empresa.RFC = TB_RFC.Text;
                empresa.registro_patronal = TB_RegistroPa.Text;
                empresa.domicilio_fiscal = TB_DomicilioFi.Text;
                empresa.contacto = TB_Contacto.Text;
                empresa.fecha_inicio_operaciones = FechaInicio_Empresa.Value.Date;

                // Llamamos al método de actualización
                int resultado = EmpresaDAP.ActualizarEmpresa(empresa);

                if (resultado > 0)
                {
                    MessageBox.Show("Empresa actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
