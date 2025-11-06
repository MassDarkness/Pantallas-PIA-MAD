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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }

        //Nos mandara a la pantalla de iniciar sesion
        private void BTN_Empresa_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        //Metodo para cerrar completamente el programa
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form1_FormClosed;
        }
    }
}
