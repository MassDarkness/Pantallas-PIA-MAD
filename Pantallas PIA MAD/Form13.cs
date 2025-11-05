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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form13_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form13_FormClosed;
        }
        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAU_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina__MEAU_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de los reportes
        private void Reportes__MEAU_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir__MEAU_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
