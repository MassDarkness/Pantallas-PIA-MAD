using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class Usuarios
    {
        public int id_Usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public byte? tipo { get; set; }

        public Usuarios() { }

        public Usuarios(int id_Usuario, string nombre, string correo, string contraseña, byte? tipo)
        {
            this.id_Usuario = id_Usuario;
            this.nombre = nombre;
            this.correo = correo;
            this.contraseña = contraseña;
            this.tipo = tipo;
        }
    }
}
