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
        public string nombre { get; set; }
        public int numero { get; set; }
        public int id_empresa { get; set; }
        public Departamento() { }


        public Departamento(int id_departamento, string nombre, int numero, int id_empresa)
        {
            this.id_departamento = id_departamento;
            this.nombre = nombre;
            this.numero = numero;
            this.id_empresa = id_empresa;
        }
    }
}
