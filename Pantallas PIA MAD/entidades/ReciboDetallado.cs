using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class ReciboDetallado
    {
        public string NumeroEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal CantidadADepositar { get; set; }
        public string Banco { get; set; }
        public string NumeroCuenta { get; set; }
    }
}
