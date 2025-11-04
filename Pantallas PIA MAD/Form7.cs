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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void BTN_AgregarUSUARIO_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.nombre = TB_NombreUsuario.Text;
            usuario.correo = TB_CorreoUsuario.Text;
            usuario.contraseña = TB_ContraseñaUsuario.Text;
            if (RB_AUXILIARUSUARIO.Checked)
                usuario.tipo = 0;  // por ejemplo, 0 = Usuario
            else if (RB_EMPUSUARIO.Checked)
                usuario.tipo = 1;  // por ejemplo, 1 = administrador
            else
                usuario.tipo = null;
            UsuarioDAO.InsertarUsuario(usuario);
            Refrescar();
        }
        private void Refrescar()
        {
            Vista_USUARIOS.DataSource = UsuarioDAO.registroUsuarios();
        }
        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            Vista_USUARIOS.DataSource = UsuarioDAO.registroUsuarios();
            this.FormClosed += Form7_FormClosed;
        }

        private void Empresa_MEAD_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void DepaPues__MEAD_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

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
            Application.Exit();
        }
    }
}
