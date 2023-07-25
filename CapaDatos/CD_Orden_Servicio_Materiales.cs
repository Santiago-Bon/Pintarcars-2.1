using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Orden_Servicio_Materiales
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarOrdenServicioMateriales(CE_Orden_Servicio_Materiales orden_servicio_materiales)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarOrdenServicioMateriales";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cantidad", orden_servicio_materiales.Cantidad);
            comando.Parameters.AddWithValue("@Costos_Unitarios", orden_servicio_materiales.Costos_Unitarios);
            comando.Parameters.AddWithValue("@Fecha_Compra", orden_servicio_materiales.Fecha_Compra);
            comando.Parameters.AddWithValue("@Cod_Orden_Servicio", orden_servicio_materiales.Cod_Orden_Servicio);
            comando.Parameters.AddWithValue("@Cod_Materiales", orden_servicio_materiales.Cod_Materiales);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}