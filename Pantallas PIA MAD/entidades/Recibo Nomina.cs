using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class Recibo_Nomina
    {
        public int id_recibo { get; set; }
        public DateTime? fecha { get; set; }
        public Decimal sueldo_bruto { get; set; }
        public Decimal sueldo_neto { get; set; }
        public Decimal percepciones { get; set; }
        public Decimal deducciones { get; set; }
        
        //Llave Foranea
        public int id_nomina { get; set; }

        public Recibo_Nomina() { }

        public Recibo_Nomina(int id_recibo, DateTime? fecha, decimal sueldo_bruto, decimal sueldo_neto, decimal percepciones, decimal deducciones, int id_nomina)
        {
            this.id_recibo = id_recibo;
            this.fecha = fecha;
            this.sueldo_bruto = sueldo_bruto;
            this.sueldo_neto = sueldo_neto;
            this.percepciones = percepciones;
            this.deducciones = deducciones;
            this.id_nomina = id_nomina;
        }
    }
}
