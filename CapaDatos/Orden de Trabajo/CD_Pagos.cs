using CapaEntidades.Orden_de_Trabajo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Orden_de_Trabajo
{
    public class CD_Pagos
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarPago(CE_Pagos pago)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarPago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Monto", pago.Monto);
            comando.Parameters.AddWithValue("@Fecha", pago.Fecha);
            comando.Parameters.AddWithValue("@Cod_Tipo_Pago", pago.Cod_Tipo_Pago);
            comando.Parameters.AddWithValue("@Cod_Orden_Trabajo", pago.Cod_Orden_Trabajo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
