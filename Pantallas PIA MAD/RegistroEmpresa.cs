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

        public string nombre { get; set; }
        public string razon_social { get; set; }
        public string domicilio_fiscal { get; set; }
        public string contacto { get; set; }
        public string registro_patronal { get; set; }
        public string RFC { get; set; }
     
        public DateTime? fecha_inicio_operaciones { get; set; }

        public RegistroEmpresa() { }


        public RegistroEmpresa(int id_empresa, string razon_social, string domicilio_fiscal, string contacto, string registro_patronal, string RFC, DateTime fecha_inicio_operaciones, string nombre)
        {
            this.id_empresa = id_empresa;
            this.nombre = nombre;
            this.razon_social = razon_social;
            this.domicilio_fiscal = domicilio_fiscal;
            this.contacto = contacto;
            this.registro_patronal = registro_patronal;
            this.RFC = RFC;
            this.fecha_inicio_operaciones = fecha_inicio_operaciones;

        }

    }
}
