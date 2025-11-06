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

                    // Asumo que tu entidad Recibo_Nomina tiene todo como NOT NULL
                    // basado en la corrección que te pasé
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
    }
}
