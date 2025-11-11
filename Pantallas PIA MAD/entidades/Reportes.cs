using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class ReporteGeneralNominaDTO
    {
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public string NombreEmpleado { get; set; }
        public decimal? SalarioDiario { get; set; }
    }

    public class ReporteHeadcounterDTO
    {
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public int CantidadEmpleados { get; set; }
    }

    public class ReporteResumenNominaDTO
    {
        public string Departamento { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal TotalSueldoBruto { get; set; }
        public decimal TotalSueldoNeto { get; set; }
    }
}
