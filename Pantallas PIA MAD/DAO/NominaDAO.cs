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
        public static int InsertarNomina(Nomina nomina)
        {
            // 'retorno' ahora guardará el NUEVO I
            int retorn = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarNomina", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha", (object)nomina.fecha ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@estatus", (object)nomina.estatus ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_empleado", nomina.id_empleado);

                    // --- ¡CAMBIO IMPORTANTE AQUÍ! ---
                    // ExecuteNonQuery() solo devuelve '1' (filas afectadas).
                    // ExecuteScalar() lee el primer valor que devuelve el SP (¡nuestro ID!)

                    // Convertimos el resultado (que es 'object') a 'int'
                }
            }

            // Devolvemos el ID
            return retorn;
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
