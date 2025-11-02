using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class Nomina
    {
        public int id_nomina { get; set; }
        public DateTime? fecha { get; set; }
        public string estatus { get; set; }
        
        //Llave Foranea
        public int id_empleado { get; set; }

        public Nomina() { }

        public Nomina(int id_nomina, DateTime? fecha, string estatus, int id_empleado)
        {
            this.id_nomina = id_nomina;
            this.fecha = fecha;
            this.estatus = estatus;
            this.id_empleado = id_empleado;
        }
    }
}
