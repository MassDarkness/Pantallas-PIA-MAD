using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Pantallas_PIA_MAD.entidades;
using System.Windows.Forms;


namespace Pantallas_PIA_MAD.DAO
{
    public class ReportesDAO
    {
        //Reporte 1: General Nómina
        public static List<ReporteGeneralNominaDTO> ObtenerReporteGeneral (int anio, int mes)
        {
            var lista = new List<ReporteGeneralNominaDTO>();
            using (var con = BDConexion.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        d.nombre AS Departamento,
                        p.nombre AS Puesto,
                        (e.nombres + ' ' + e.apellido_paterno) AS NombreEmpleado,
                        e.salario AS SalarioDiario
                    FROM Empleado e
                    LEFT JOIN Puesto p ON e.id_puesto = p.id_puesto
                    LEFT JOIN Departamento d ON e.id_departamento = d.id_departamento
                    WHERE 
                        EXISTS (SELECT 1 FROM Nomina n 
                                WHERE n.id_empleado = e.id_empleado 
                                AND YEAR(n.fecha) = @anio AND MONTH(n.fecha) = @mes)
                    ORDER BY 
                        Departamento, Puesto, NombreEmpleado;";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@mes", mes);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReporteGeneralNominaDTO
                        {
                            Departamento = reader["Departamento"].ToString(),
                            Puesto = reader["Puesto"].ToString(),
                            NombreEmpleado = reader["NombreEmpleado"].ToString(),
                            SalarioDiario = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                        });
                    }
                }
            }
            return lista;
        }
        //Reporte 2: Headcounter
        public static List<ReporteHeadcounterDTO> ObtenerReporteHeadcounter (int? idDepartamento, int anio, int mes)
        {
            var lista = new List<ReporteHeadcounterDTO>();
            using (var con = BDConexion.ObtenerConexion ())
            {
                string query = @"
                    SELECT 
                        d.nombre AS Departamento,
                        p.nombre AS Puesto,
                        COUNT(e.id_empleado) AS CantidadEmpleados
                    FROM Empleado e
                    LEFT JOIN Puesto p ON e.id_puesto = p.id_puesto
                    LEFT JOIN Departamento d ON e.id_departamento = d.id_departamento
                    WHERE 
                        (@idDepartamento IS NULL OR d.id_departamento = @idDepartamento)
                        AND EXISTS (SELECT 1 FROM Nomina n 
                                    WHERE n.id_empleado = e.id_empleado 
                                    AND YEAR(n.fecha) = @anio AND MONTH(n.fecha) = @mes)
                    GROUP BY 
                        d.nombre, p.nombre
                    ORDER BY 
                        Departamento, Puesto;";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idDepartamento", (object)idDepartamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@mes", mes);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReporteHeadcounterDTO
                        {
                            Departamento = reader["Departamento"].ToString(),
                            Puesto = reader["Puesto"].ToString(),
                            CantidadEmpleados = reader.GetInt32(2)
                        });
                    }
                }
            }
            return lista;
        }

        //Reporte 3: Resumen de Nómina
        public static List<ReporteResumenNominaDTO> ObtenerReporteResumen (int anio)
        {
            var lista = new List<ReporteResumenNominaDTO>();
            using (var con = BDConexion.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        d.nombre AS Departamento,
                        YEAR(rn.fecha) AS Anio,
                        MONTH(rn.fecha) AS Mes,
                        SUM(rn.sueldo_bruto) AS TotalSueldoBruto,
                        SUM(rn.sueldo_neto) AS TotalSueldoNeto
                    FROM Recibo_Nomina rn
                    JOIN Nomina n ON rn.id_nomina = n.id_nomina
                    JOIN Empleado e ON n.id_empleado = e.id_empleado
                    JOIN Departamento d ON e.id_departamento = d.id_departamento
                    WHERE 
                        YEAR(rn.fecha) = @anio
                    GROUP BY 
                        d.nombre, YEAR(rn.fecha), MONTH(rn.fecha)
                    ORDER BY 
                        Departamento, Anio, Mes;";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@anio", anio);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReporteResumenNominaDTO
                        {
                            Departamento = reader["Departamento"].ToString(),
                            Anio = reader.GetInt32(1),
                            Mes = reader.GetInt32(2),
                            TotalSueldoBruto = reader.GetDecimal(3),
                            TotalSueldoNeto = reader.GetDecimal(4)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
