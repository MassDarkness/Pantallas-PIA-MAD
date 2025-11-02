using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD
{
    public class RegistroEmpresa
    {
    public int id_empresa { get; set; }
    public string razon_social { get; set; }
    public string domicilio_fiscal { get; set; }
    public string contacto { get; set; }
    public string registro_patronal { get; set; }
    public string RFC { get; set; }
     
    public DateTime fecha_inicio_operaciones { get; set; }

    }
}
