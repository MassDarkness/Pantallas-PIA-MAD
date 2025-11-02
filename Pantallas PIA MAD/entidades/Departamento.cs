using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class Departamento
    {
        public int id_departamento { get; set; }
        string nombre { get; set; }

        int numero { get; set; }

        public Departamento() { }


        public Departamento(int id_departamento, string nombre, int numero)
        {
            this.id_departamento = id_departamento;
            this.nombre = nombre;
            this.numero = numero;
        }
    }
}
