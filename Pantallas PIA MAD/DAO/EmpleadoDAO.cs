using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_PIA_MAD.DAO
{
    public class EmpleadoDAO
    {
        // Método para insertar un empleado usando el stored procedure
        public static int InsertarEmpleado(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    // Parámetros
                    comando.Parameters.AddWithValue("@numero_empleado", empleado.numero_empleado);
                    comando.Parameters.AddWithValue("@nombres", empleado.nombres);
                    comando.Parameters.AddWithValue("@apellido_paterno", empleado.apellido_paterno);
                    comando.Parameters.AddWithValue("@apellido_materno", (object)empleado.apellido_materno ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@domicilio", (object)empleado.domicilio ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@telefono", (object)empleado.telefono ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@email", (object)empleado.email ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@fecha_nacimiento", (object)empleado.fecha_nacimiento ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@curp", empleado.curp);
                    comando.Parameters.AddWithValue("@rfc", empleado.rfc);
                    comando.Parameters.AddWithValue("@nss", empleado.nss);
                    comando.Parameters.AddWithValue("@salario", (object)empleado.salario ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@salario_diario_integrado", (object)empleado.salario_diario_integrado ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@numero_cuenta", (object)empleado.numero_cuenta ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@banco", (object)empleado.banco ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_puesto", (object)empleado.id_puesto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_departamento", (object)empleado.id_departamento ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_empresa", empleado.id_empresa);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }

        // Método para obtener todos los empleados
        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_empleado, numero_empleado, nombres, apellido_paterno, apellido_materno, domicilio, telefono, email, fecha_nacimiento, curp, rfc, nss, salario, salario_diario_integrado, numero_cuenta, banco, id_puesto, id_departamento, id_empresa FROM Empleado;";
                SqlCommand comando = new SqlCommand(query, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado();

                        empleado.id_empleado = reader.GetInt32(0);
                        empleado.numero_empleado = reader.IsDBNull(1) ? null : reader.GetString(1);
                        empleado.nombres = reader.IsDBNull(2) ? null : reader.GetString(2);
                        empleado.apellido_paterno = reader.IsDBNull(3) ? null : reader.GetString(3);
                        empleado.apellido_materno = reader.IsDBNull(4) ? null : reader.GetString(4);
                        empleado.domicilio = reader.IsDBNull(5) ? null : reader.GetString(5);
                        empleado.telefono = reader.IsDBNull(6) ? null : reader.GetString(6);
                        empleado.email = reader.IsDBNull(7) ? null : reader.GetString(7);
                        empleado.fecha_nacimiento = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8);
                        empleado.curp = reader.IsDBNull(9) ? null : reader.GetString(9);
                        empleado.rfc = reader.IsDBNull(10) ? null : reader.GetString(10);
                        empleado.nss = reader.IsDBNull(11) ? null : reader.GetString(11);
                        empleado.salario = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12);
                        empleado.salario_diario_integrado = reader.IsDBNull(13) ? (decimal?)null : reader.GetDecimal(13);
                        empleado.numero_cuenta = reader.IsDBNull(14) ? null : reader.GetString(14);
                        empleado.banco = reader.IsDBNull(15) ? null : reader.GetString(15);
                        empleado.id_puesto = reader.IsDBNull(16) ? (int?)null : reader.GetInt32(16);
                        empleado.id_departamento = reader.IsDBNull(17) ? (int?)null : reader.GetInt32(17);
                        empleado.id_empresa = reader.GetInt32(18);

                        lista.Add(empleado);
                    }
                }
            }

            return lista;
        }

        public static int ActualizarEmpleado(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id_empleado", empleado.id_empleado);
                    comando.Parameters.AddWithValue("@numero_empleado", empleado.numero_empleado);
                    comando.Parameters.AddWithValue("@nombres", empleado.nombres);
                    comando.Parameters.AddWithValue("@apellido_paterno", empleado.apellido_paterno);
                    comando.Parameters.AddWithValue("@apellido_materno", (object)empleado.apellido_materno ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@domicilio", (object)empleado.domicilio ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@telefono", (object)empleado.telefono ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@email", (object)empleado.email ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@fecha_nacimiento", (object)empleado.fecha_nacimiento ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@curp", empleado.curp);
                    comando.Parameters.AddWithValue("@rfc", empleado.rfc);
                    comando.Parameters.AddWithValue("@nss", empleado.nss);
                    comando.Parameters.AddWithValue("@salario", (object)empleado.salario ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@salario_diario_integrado", (object)empleado.salario_diario_integrado ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@numero_cuenta", (object)empleado.numero_cuenta ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@banco", (object)empleado.banco ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_puesto", (object)empleado.id_puesto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_departamento", (object)empleado.id_departamento ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@id_empresa", empleado.id_empresa);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }

        public static List<Empleado> ObtenerEmpleadosPorPuesto(int idPuesto)
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"SELECT 
                            id_empleado, 
                            numero_empleado, 
                            nombres, 
                            apellido_paterno, 
                            apellido_materno, 
                            domicilio, 
                            telefono, 
                            email, 
                            fecha_nacimiento, 
                            curp, 
                            rfc, 
                            nss, 
                            salario, 
                            salario_diario_integrado, 
                            numero_cuenta, 
                            banco, 
                            id_puesto, 
                            id_departamento, 
                            id_empresa
                         FROM Empleado
                         WHERE id_puesto = @idPuesto;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@idPuesto", idPuesto);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado
                            {
                                id_empleado = reader.GetInt32(0),
                                numero_empleado = reader.IsDBNull(1) ? null : reader.GetString(1),
                                nombres = reader.IsDBNull(2) ? null : reader.GetString(2),
                                apellido_paterno = reader.IsDBNull(3) ? null : reader.GetString(3),
                                apellido_materno = reader.IsDBNull(4) ? null : reader.GetString(4),
                                domicilio = reader.IsDBNull(5) ? null : reader.GetString(5),
                                telefono = reader.IsDBNull(6) ? null : reader.GetString(6),
                                email = reader.IsDBNull(7) ? null : reader.GetString(7),
                                fecha_nacimiento = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                curp = reader.IsDBNull(9) ? null : reader.GetString(9),
                                rfc = reader.IsDBNull(10) ? null : reader.GetString(10),
                                nss = reader.IsDBNull(11) ? null : reader.GetString(11),
                                salario = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12),
                                salario_diario_integrado = reader.IsDBNull(13) ? (decimal?)null : reader.GetDecimal(13),
                                numero_cuenta = reader.IsDBNull(14) ? null : reader.GetString(14),
                                banco = reader.IsDBNull(15) ? null : reader.GetString(15),
                                id_puesto = reader.IsDBNull(16) ? (int?)null : reader.GetInt32(16),
                                id_departamento = reader.IsDBNull(17) ? (int?)null : reader.GetInt32(17),
                                id_empresa = reader.GetInt32(18)
                            };

                            lista.Add(empleado);
                        }
                    }
                }
            }

            return lista;
        }
        public static Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            Empleado empleado = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"SELECT id_empleado, numero_empleado, nombres, apellido_paterno, 
                                apellido_materno, domicilio, telefono, email, fecha_nacimiento, 
                                curp, rfc, nss, salario, salario_diario_integrado, 
                                numero_cuenta, banco, id_puesto, id_departamento, id_empresa 
                         FROM Empleado 
                         WHERE id_empleado = @idEmpleado;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        empleado = new Empleado
                        {
                            id_empleado = reader.GetInt32(0),
                            numero_empleado = reader.IsDBNull(1) ? null : reader.GetString(1),
                            nombres = reader.IsDBNull(2) ? null : reader.GetString(2),
                            apellido_paterno = reader.IsDBNull(3) ? null : reader.GetString(3),
                            apellido_materno = reader.IsDBNull(4) ? null : reader.GetString(4),
                            domicilio = reader.IsDBNull(5) ? null : reader.GetString(5),
                            telefono = reader.IsDBNull(6) ? null : reader.GetString(6),
                            email = reader.IsDBNull(7) ? null : reader.GetString(7),
                            fecha_nacimiento = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                            curp = reader.IsDBNull(9) ? null : reader.GetString(9),
                            rfc = reader.IsDBNull(10) ? null : reader.GetString(10),
                            nss = reader.IsDBNull(11) ? null : reader.GetString(11),
                            salario = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12),
                            salario_diario_integrado = reader.IsDBNull(13) ? (decimal?)null : reader.GetDecimal(13),
                            numero_cuenta = reader.IsDBNull(14) ? null : reader.GetString(14),
                            banco = reader.IsDBNull(15) ? null : reader.GetString(15),
                            id_puesto = reader.IsDBNull(16) ? (int?)null : reader.GetInt32(16),
                            id_departamento = reader.IsDBNull(17) ? (int?)null : reader.GetInt32(17),
                            id_empresa = reader.GetInt32(18)
                        };
                    }
                }
            }
            return empleado;
        }
        public static int EliminarEmpleado(int idEmpleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_empleado", idEmpleado);

                    retorno = comando.ExecuteNonQuery();
                }
            }

            return retorno;
        }

    }
}
