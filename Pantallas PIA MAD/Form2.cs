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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío por ahora
        }

        // --- CÓDIGO NUEVO A PARTIR DE AQUÍ ---

        private void BTN_IS_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el texto de los campos
            // !! RECUERDA CAMBIAR ESTOS NOMBRES SI LOS TUYOS SON DIFERENTES !!
            string correo = IS_Correo.Text;
            string contrasena = IS_Contraseña.Text;

            // 2. Revisamos si el botón ADMIN está marcado
            if (RB_ADMIN.Checked)
            {
                // 3. Verificamos las credenciales del ADMIN
                // (Estos son usuarios "quemados" de ejemplo. Lo ideal es usar una base de datos)
                if (correo == "admin@correo.com" && contrasena == "admin123")
                {
                    MessageBox.Show("¡Bienvenido ADMIN!");
                    Form3 menuAdmin = new Form3();
                    menuAdmin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 4. Si ADMIN no está marcado, revisamos si AUXILIAR está marcado
            else if (RB_AUXILIAR.Checked)
            {
                // 5. Verificamos las credenciales del AUXILIAR
                if (correo == "auxiliar@correo.com" && contrasena == "auxiliar123")
                {
                    MessageBox.Show("¡Bienvenido AUXILIAR!");
                    Form13 menuAuxiliar = new Form13();
                    menuAuxiliar.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 6. Si ninguno está seleccionado
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de usuario (ADMIN o AUXILIAR).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BTN_SALIRIS_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación
            Application.Exit();
        }
    }
}