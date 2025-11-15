using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class EmpresaDAP
    {
        public static int InsertarEmpresa(RegistroEmpresa empresa)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarEmpresa", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@razon_social", empresa.razon_social);
                    comando.Parameters.AddWithValue("@domicilio_fiscal", empresa.domicilio_fiscal);
                    comando.Parameters.AddWithValue("@contacto", (object)empresa.contacto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@registro_patronal", (object)empresa.registro_patronal ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@RFC", empresa.RFC);
                    comando.Parameters.AddWithValue("@fecha_inicio_operaciones", (object)empresa.fecha_inicio_operaciones ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@nombre", empresa.nombre);
                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }
        public static List<RegistroEmpresa> ObtenerEmpresas()
        {
            List<RegistroEmpresa> lista = new List<RegistroEmpresa>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_empresa,nombre,razon_social, domicilio_fiscal, contacto, registro_patronal, RFC," +
                    "fecha_inicio_operaciones FROM Empresa;";
                SqlCommand comando = new SqlCommand(query, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RegistroEmpresa empresa = new RegistroEmpresa();

                        empresa.id_empresa = reader.GetInt32(0);
                        empresa.nombre = reader.IsDBNull(1) ? null : reader.GetString(1);
                        empresa.razon_social = reader.IsDBNull(2) ? null : reader.GetString(2);
                        empresa.domicilio_fiscal = reader.IsDBNull(3) ? null : reader.GetString(3);
                        empresa.contacto = reader.IsDBNull(4) ? null : reader.GetString(4);
                        empresa.registro_patronal = reader.IsDBNull(5) ? null : reader.GetString(5);
                        empresa.RFC = reader.IsDBNull(6) ? null : reader.GetString(6);
                        empresa.fecha_inicio_operaciones = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7);
                        lista.Add(empresa);
                    }
                }
            }

            return lista;
        }
        public static int ActualizarEmpresa(RegistroEmpresa empresa)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarEmpresa", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id_empresa", empresa.id_empresa);
                    comando.Parameters.AddWithValue("@razon_social", empresa.razon_social);
                    comando.Parameters.AddWithValue("@domicilio_fiscal", empresa.domicilio_fiscal);
                    comando.Parameters.AddWithValue("@contacto", (object)empresa.contacto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@registro_patronal", (object)empresa.registro_patronal ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@RFC", empresa.RFC);
                    comando.Parameters.AddWithValue("@fecha_inicio_operaciones", (object)empresa.fecha_inicio_operaciones ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@nombre", empresa.nombre);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }
        public static RegistroEmpresa ObtenerEmpresaPorId(int idEmpresa)
        {
            RegistroEmpresa empresa = null;
            using (var con = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_empresa,nombre,razon_social, domicilio_fiscal, contacto, registro_patronal, RFC," +
                               "fecha_inicio_operaciones FROM Empresa WHERE id_empresa = @id";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idEmpresa);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        empresa = new RegistroEmpresa
                        {
                            id_empresa = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            razon_social = reader.IsDBNull(2) ? null : reader.GetString(2),
                            domicilio_fiscal = reader.IsDBNull(3) ? null : reader.GetString(3),
                            contacto = reader.IsDBNull(4) ? null : reader.GetString(4),
                            registro_patronal = reader.IsDBNull(5) ? null : reader.GetString(5),
                            RFC = reader.IsDBNull(6) ? null : reader.GetString(6),
                            fecha_inicio_operaciones = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                        };
                    }
                }
            }
            return empresa;
        }
    }
}
