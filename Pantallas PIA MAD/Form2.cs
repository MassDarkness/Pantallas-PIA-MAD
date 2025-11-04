using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pantallas_PIA_MAD.DAO;
using Pantallas_PIA_MAD.entidades;

namespace Pantallas_PIA_MAD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

    private void BTN_IS_Click(object sender, EventArgs e)
    {
        string correo = IS_Correo.Text.Trim();
        string contrasena = IS_Contraseña.Text.Trim();

        if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
        {
            MessageBox.Show("Por favor ingresa correo y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        byte tipo;

        if (RB_ADMIN.Checked)
            tipo = 1;  // Supón que en la base de datos tipo=1 es admin
        else if (RB_AUXILIAR.Checked)
            tipo = 0;  // tipo=2 es auxiliar
        else
        {
            MessageBox.Show("Selecciona el tipo de usuario (ADMIN o AUXILIAR).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        Usuarios usuario = UsuarioDAO.IniciarSesion(correo, contrasena, tipo);

        if (usuario != null)
        {
            if (tipo == 1)
            {
                MessageBox.Show("¡Bienvenido ADMIN " + usuario.nombre + "!");
                Form3 menuAdmin = new Form3();
                menuAdmin.Show();
            }
            else
            {
                MessageBox.Show("¡Bienvenido AUXILIAR " + usuario.nombre + "!");
                Form13 menuAux = new Form13();
                menuAux.Show();
            }
            this.Hide();
        }
        else
        {
            MessageBox.Show("Correo o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

        private void BTN_SALIRIS_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            this.FormClosed += Form2_FormClosed;
        }
    }
}