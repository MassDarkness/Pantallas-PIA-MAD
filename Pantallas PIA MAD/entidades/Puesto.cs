using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pantallas_PIA_MAD.entidades
{
    public class Puesto
    {   
        public int id_puesto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int numero { get; set; }

        //Llave Foranea 
        public int? id_departamento { get; set; }
        public Puesto() { }

        public Puesto( int id_puesto, string nombre, string descripcion, int numero, int? id_departamento)
        {
            this.id_puesto = id_puesto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.numero = numero;
            this.id_departamento = id_departamento;
        }

    }
}
