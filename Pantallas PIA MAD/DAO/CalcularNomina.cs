using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class CalculoNomina
    {
        private const decimal SALARIO_MINIMO_A = 278.80m;
        private const decimal SALARIO_MINIMO_B = 419.88m;

        public Recibo_Nomina CalcularNomina(
                    Empleado empleado,
                    int diasDelMes,
                    int faltas,
                    int retardos,
                    decimal aguinaldoCalculado,
                    decimal bonoPuntualidadCalculado,
                    decimal bonoAsistenciaCalculado,
                    decimal cuotaImssCalculada,
                    decimal cuotaSindicalCalculada
                )
        {
            int faltasPorRetardos = retardos / 3;
            int faltasTotales = faltas + faltasPorRetardos;
            int diasTrabajados = diasDelMes - faltasTotales;
            if (faltasTotales > 0)
            {
                bonoPuntualidadCalculado = 0;
                bonoAsistenciaCalculado = 0;
            }

            decimal aguinaldoFinal = (15.0m / 365.0m) * diasTrabajados;
            decimal sueldoBruto = (empleado.salario ?? 0) * diasTrabajados;
            decimal totalPercepciones = sueldoBruto + aguinaldoFinal + bonoPuntualidadCalculado + bonoAsistenciaCalculado;
            decimal deduccionImss = 0;
            decimal deduccionIsr = 0;

            if ((empleado.salario ?? 0) > SALARIO_MINIMO_B)
            {
                deduccionImss = cuotaImssCalculada;
                decimal baseIsr = (empleado.salario ?? 0) * 30;
                deduccionIsr = CalcularISR(baseIsr);
            }

            decimal totalDeducciones = deduccionImss + deduccionIsr + cuotaSindicalCalculada;
            decimal sueldoNeto = totalPercepciones - totalDeducciones;

            Recibo_Nomina recibo = new Recibo_Nomina
            {
                fecha = DateTime.Now.Date,
                sueldo_bruto = sueldoBruto,
                percepciones = totalPercepciones,
                deducciones = totalDeducciones,
                sueldo_neto = sueldoNeto,
            };

            return recibo;
        }

        public decimal CalcularIMSS(Empleado empleado)
        {
            decimal sdi = empleado.salario_diario_integrado ?? 0;
            if (sdi == 0)
            {
                sdi = (empleado.salario ?? 0) * 1.0493m;
            }
            decimal imss = (sdi * 30) * 0.028m;
            return Math.Round(imss, 2);
        }

        private decimal CalcularISR(decimal baseGravableMensual)
        {
            decimal limiteInferior = 0;
            decimal cuotaFija = 0;
            decimal porcentaje = 0;

            if (baseGravableMensual <= 7735.00m)
            {
                limiteInferior = 0.01m;
                cuotaFija = 0.00m;
                porcentaje = 1.92m;
            }
            else if (baseGravableMensual <= 65651.07m)
            {
                limiteInferior = 7735.01m;
                cuotaFija = 148.51m;
                porcentaje = 6.40m;
            }
            else if (baseGravableMensual <= 115375.90m)
            {
                limiteInferior = 65651.08m;
                cuotaFija = 3855.14m;
                porcentaje = 10.88m;
            }

            else
            {
                limiteInferior = 375076.42m;
                limiteInferior = 65651.08m;
                cuotaFija = 3855.14m;
                porcentaje = 10.88m;
            }

            decimal excedente = baseGravableMensual - limiteInferior;
            decimal impuestoMarginal = (excedente * porcentaje) / 100m;
            decimal isr = impuestoMarginal + cuotaFija;

            return Math.Round(isr, 2);
        }
    }
}
