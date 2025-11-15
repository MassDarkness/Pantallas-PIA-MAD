using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class CalculoDesglose
    {
        public decimal Aguinaldo { get; set; }
        public decimal BonoPuntualidad { get; set; }
        public decimal BonoAsistencia { get; set; }
        public decimal DeduccionISR { get; set; }
        public decimal DeduccionIMSS { get; set; }
        public decimal DeduccionSindical { get; set; }
    }
}
