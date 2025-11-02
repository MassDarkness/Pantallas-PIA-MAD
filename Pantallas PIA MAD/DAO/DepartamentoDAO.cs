using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pantallas_PIA_MAD.DAO
{
    public class DepartamentoDAO
    {
        // Obtener departamentos por empresa (sigue igual)
        public static List<Departamento> ObtenerDepartamentosPorEmpresa(int idEmpresa)
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_departamento, nombre, numero, id_empresa FROM Departamento WHERE id_empresa=@idEmpresa;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Departamento depto = new Departamento
                        {
                            id_departamento = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            numero = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            id_empresa = reader.GetInt32(3)
                        };
                        lista.Add(depto);
                    }
                }
            }

            return lista;
        }

        // Registrar un nuevo departamento usando stored procedure
        public static int InsertarDepartamento(Departamento depto)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarDepartamento", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@nombre", depto.nombre);
                    comando.Parameters.AddWithValue("@numero", depto.numero);
                    comando.Parameters.AddWithValue("@id_empresa", depto.id_empresa);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }

        // (Opcional) Obtener todos los departamentos (sigue igual)
        public static List<Departamento> ObtenerDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_departamento, nombre, numero, id_empresa FROM Departamento;";
                SqlCommand comando = new SqlCommand(query, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Departamento depto = new Departamento
                        {
                            id_departamento = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            numero = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            id_empresa = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                        lista.Add(depto);
                    }
                }
            }

            return lista;
        }
    }
}
