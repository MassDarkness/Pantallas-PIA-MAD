using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.entidades
{
    public class Empleado
    {
        public int id_empleado { get; set; }
        public string numero_empleado { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public string nss { get; set; }
        public decimal? salario { get; set; }
        public decimal? salario_diario_integrado { get; set; }
        public string numero_cuenta { get; set; }
        public string banco { get; set; }

        // Llaves foráneas
        public int? id_puesto { get; set; }
        public int? id_departamento { get; set; }
        public int id_empresa { get; set; }  // NOT NULL en la base de datos

        // Referencias opcionales a las entidades relacionadas
        public Puesto Puesto { get; set; }           // clase Puesto
        public Departamento Departamento { get; set; } // clase Departamento
        public Empresa Empresa { get; set; }         // clase Empresa

        public Empleado() { }

        public Empleado(int id_empleado, string numero_empleado, string nombres, string apellido_paterno, string apellido_materno,
                                string domicilio, string telefono, string email, DateTime? fecha_nacimiento, string curp, string rfc,
                                string nss, decimal? salario, decimal? salario_diario_integrado, string numero_cuenta, string banco,
                                int? id_puesto, int? id_departamento, int id_empresa)
        {
            this.id_empleado = id_empleado;
            this.numero_empleado = numero_empleado;
            this.nombres = nombres;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.email = email;
            this.fecha_nacimiento = fecha_nacimiento;
            this.curp = curp;
            this.rfc = rfc;
            this.nss = nss;
            this.salario = salario;
            this.salario_diario_integrado = salario_diario_integrado;
            this.numero_cuenta = numero_cuenta;
            this.banco = banco;
            this.id_puesto = id_puesto;
            this.id_departamento = id_departamento;
            this.id_empresa = id_empresa;
        }
    }

}
