using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class UsuarioDAO
    {
        public static int InsertarUsuario(Usuarios usuario)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                    comando.Parameters.AddWithValue("@correo", (object)usuario.correo ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@contra", (object)usuario.contraseña ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@tipo", (object)usuario.tipo ?? (object)DBNull.Value);

                    retorno = comando.ExecuteNonQuery();
                }
            }
            return retorno;
        }
        public static List<Usuarios> registroUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_Usuario, nombre, correo, contra, tipo from Usuario";
                SqlCommand comando = new SqlCommand(query, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuarios usuario = new Usuarios();
                        usuario.id_Usuario = reader.GetInt32(0);
                        usuario.nombre = reader.IsDBNull(1) ? null : reader.GetString(1);
                        usuario.correo = reader.IsDBNull(2) ? null : reader.GetString(2);
                        usuario.contraseña = reader.IsDBNull(3) ? null : reader.GetString(3);
                        usuario.tipo = reader.IsDBNull(4) ? (byte?)null : reader.GetByte(4);
                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }

        public static Usuarios IniciarSesion(string correo, string contraseña, byte tipo)
        {
            Usuarios usuario = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_Usuario, nombre, correo, contra, tipo FROM Usuario WHERE correo = @correo AND contra = @contra AND tipo = @tipo";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@contra", contraseña);
                comando.Parameters.AddWithValue("@tipo", tipo);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuarios();
                        usuario.id_Usuario = reader.GetInt32(0);
                        usuario.nombre = reader.GetString(1);
                        usuario.correo = reader.GetString(2);
                        usuario.contraseña = reader.GetString(3);
                        usuario.tipo = reader.GetByte(4);
                    }
                }
            }

            return usuario;
        }

        public static int ActualizarUsuario(Usuarios usuario)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id_Usuario", usuario.id_Usuario);
                    comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                    comando.Parameters.AddWithValue("@correo", (object)usuario.correo ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@contra", (object)usuario.contraseña ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@tipo", (object)usuario.tipo ?? (object)DBNull.Value);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }


    }
}
