using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class CD_Orden_Servicio
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarOrdenServicio(CE_Orden_Servicio orden_servicio)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarOrdenServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fecha_Inicio", orden_servicio.Fecha_Inicio);
            comando.Parameters.AddWithValue("@Fecha_Entrega_Final", orden_servicio.Fecha_Entrega_Final);
            comando.Parameters.AddWithValue("@Proceso", orden_servicio.Proceso);
            comando.Parameters.AddWithValue("@Costo_Total_Materiales", orden_servicio.Costo_Total_Materiales);
            comando.Parameters.AddWithValue("@Costo_Total_Mano_Obra", orden_servicio.Costo_Total_Mano_Obra);
            comando.Parameters.AddWithValue("@Costo_Total", orden_servicio.Costo_Total);
            comando.Parameters.AddWithValue("@Recibe", orden_servicio.Recibe);
            comando.Parameters.AddWithValue("@Matricula_Vehiculo", orden_servicio.Matricula_Vehiculo);
            comando.Parameters.AddWithValue("@Cod_Cotizacion", orden_servicio.Cod_Cotizacion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
