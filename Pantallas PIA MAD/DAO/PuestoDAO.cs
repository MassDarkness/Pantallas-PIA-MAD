using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pantallas_PIA_MAD.DAO
{
    public class PuestoDAO
    {
        public static int InsertarPuesto(Puesto puesto)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarPuesto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", puesto.nombre);
                    comando.Parameters.AddWithValue("@descripcion", (object)puesto.descripcion ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@numero", (object)puesto.numero ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_departamento", puesto.id_departamento ?? (object)DBNull.Value);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }

        public static List<Puesto> ObtenerPuestosPorDepartamento(int idDepartamento)
        {
            List<Puesto> lista = new List<Puesto>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_puesto, nombre, descripcion, numero, id_departamento FROM Puesto WHERE id_departamento=@id_dep";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id_dep", idDepartamento);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Puesto p = new Puesto
                            {
                                id_puesto = reader.GetInt32(0),
                                nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                                descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                numero = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                id_departamento = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4)
                            };
                            lista.Add(p);
                        }
                    }
                }
            }

            return lista;
        }

        public static List<Puesto> ObtenerTodosLosPuestos()
        {
            List<Puesto> lista = new List<Puesto>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"SELECT 
                            p.id_puesto, 
                            p.nombre, 
                            p.descripcion, 
                            p.numero, 
                            p.id_departamento
                         FROM Puesto p
                         INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
                         INNER JOIN Empresa e ON d.id_empresa = e.id_empresa";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Puesto p = new Puesto
                        {
                            id_puesto = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            numero = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            id_departamento = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        public static int ActualizarPuesto(Puesto puesto)
        {
            int filasAfectadas = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarPuesto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_puesto", puesto.id_puesto);
                    comando.Parameters.AddWithValue("@nombre", puesto.nombre);
                    comando.Parameters.AddWithValue("@descripcion", (object)puesto.descripcion ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@numero", (object)puesto.numero ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_departamento", puesto.id_departamento ?? (object)DBNull.Value);

                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }
        public static int EliminarPuesto(int idPuesto)
        {
            int filasAfectadas = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarPuesto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_puesto", idPuesto);

                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }
        public static Puesto ObtenerPuestoPorId(int idPuesto)
        {
            Puesto puesto = null;
            using (var con = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_puesto, nombre, descripcion, numero, id_departamento FROM Puesto WHERE id_puesto = @id";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idPuesto);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        puesto = new Puesto
                        {
                            id_puesto = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            numero = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            id_departamento = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4)
                        };
                    }
                }
            }
            return puesto;
        }

    }
}
