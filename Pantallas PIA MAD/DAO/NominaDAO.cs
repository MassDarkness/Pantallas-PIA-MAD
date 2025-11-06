using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class NominaDAO
    {
        // INSERTAR NÓMINA
        public static int InsertarNomina(Nomina nomina, out int idNominaNueva)
        {
            int filasAfectadas = 0;
            idNominaNueva = 0; // Inicializamos el ID de salida en 0

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarNomina", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    // Parámetros de ENTRADA (los que ya tenías)
                    comando.Parameters.AddWithValue("@fecha", (object)nomina.fecha ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@estatus", (object)nomina.estatus ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_empleado", nomina.id_empleado);

                    // --- ¡EL CAMBIO IMPORTANTE! ---
                    // 1. Creamos el parámetro de SALIDA
                    SqlParameter paramIdSalida = new SqlParameter("@id_nomina_nuevo", System.Data.SqlDbType.Int);
                    paramIdSalida.Direction = System.Data.ParameterDirection.Output;
                    comando.Parameters.Add(paramIdSalida);

                    // 2. Ejecutamos (ahora sí, con NonQuery)
                    filasAfectadas = comando.ExecuteNonQuery();

                    // 3. ¡Leemos el valor de SALIDA!
                    if (filasAfectadas > 0)
                    {
                        idNominaNueva = (int)paramIdSalida.Value;
                    }
                }
            }

            // Devolvemos 1 (éxito) o 0 (fracaso), como te gusta
            return filasAfectadas;
        }

        // MOSTRAR TODAS LAS NÓMINAS
        public static List<Nomina> ObtenerNominas()
        {
            List<Nomina> lista = new List<Nomina>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_nomina, fecha, estatus, id_empleado FROM Nomina";
                SqlCommand comando = new SqlCommand(query, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Nomina nomina = new Nomina();
                        nomina.id_nomina = reader.GetInt32(0);
                        nomina.fecha = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1);
                        nomina.estatus = reader.IsDBNull(2) ? null : reader.GetString(2);
                        nomina.id_empleado = reader.GetInt32(3);

                        lista.Add(nomina);
                    }
                }
            }

            return lista;
        }

        // EDITAR UNA NÓMINA (opcional)
        public static int EditarNomina(Nomina nomina)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "UPDATE Nomina SET fecha=@fecha, estatus=@estatus, id_empleado=@id_empleado WHERE id_nomina=@id_nomina";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@fecha", (object)nomina.fecha ?? DBNull.Value);
                comando.Parameters.AddWithValue("@estatus", (object)nomina.estatus ?? DBNull.Value);
                comando.Parameters.AddWithValue("@id_empleado", nomina.id_empleado);
                comando.Parameters.AddWithValue("@id_nomina", nomina.id_nomina);

                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }
    }
}
