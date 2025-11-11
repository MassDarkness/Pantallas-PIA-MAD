using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class ReciboNominaDAO
    {
        public static int InsertarReciboNomina(Recibo_Nomina recibo)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarReciboNomina", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha", recibo.fecha);
                    comando.Parameters.AddWithValue("@sueldo_bruto", recibo.sueldo_bruto);
                    comando.Parameters.AddWithValue("@sueldo_neto", recibo.sueldo_neto);
                    comando.Parameters.AddWithValue("@percepciones", recibo.percepciones);
                    comando.Parameters.AddWithValue("@deducciones", recibo.deducciones);
                    comando.Parameters.AddWithValue("@id_nomina", recibo.id_nomina);

                    retorno = comando.ExecuteNonQuery();
                }
            }
            return retorno;
        }
        public static List<Recibo_Nomina> ObtenerRecibosNomina()
        {
            List<Recibo_Nomina> lista = new List<Recibo_Nomina>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"SELECT 
                            id_recibo, 
                            fecha, 
                            sueldo_bruto, 
                            sueldo_neto, 
                            percepciones, 
                            deducciones, 
                            id_nomina
                         FROM Recibo_Nomina;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recibo_Nomina recibo = new Recibo_Nomina
                            {
                                id_recibo = reader.GetInt32(0),
                                fecha = reader.GetDateTime(1),
                                sueldo_bruto = reader.GetDecimal(2),
                                sueldo_neto = reader.GetDecimal(3),
                                percepciones = reader.GetDecimal(4),
                                deducciones = reader.GetDecimal(5),
                                id_nomina = reader.GetInt32(6)
                            };

                            lista.Add(recibo);
                        }
                    }
                }
            }

            return lista;
        }

        public static List<ReciboDetallado> ObtenerRecibosDetallados()
        {
            var lista = new List<ReciboDetallado>();
            using (var con = BDConexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                e.numero_empleado AS NumeroEmpleado,
                (e.nombres + ' ' + e.apellido_paterno) AS NombreEmpleado,
                rn.fecha AS Fecha,
                rn.sueldo_neto AS CantidadADepositar,
                e.banco AS Banco,
                e.numero_cuenta AS NumeroCuenta
            FROM Recibo_Nomina rn
            JOIN Nomina n ON rn.id_nomina = n.id_nomina
            JOIN Empleado e ON n.id_empleado = e.id_empleado
            ORDER BY rn.fecha DESC;
        ";

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReciboDetallado
                        {
                            NumeroEmpleado = reader["NumeroEmpleado"].ToString(),
                            NombreEmpleado = reader["NombreEmpleado"].ToString(),
                            Fecha = (DateTime)reader["Fecha"],
                            CantidadADepositar = (decimal)reader["CantidadADepositar"],
                            Banco = reader["Banco"].ToString(),
                            NumeroCuenta = reader["NumeroCuenta"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

    }
}
