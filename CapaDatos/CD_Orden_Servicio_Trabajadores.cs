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
    public class CD_Orden_Servicio_Trabajadores
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarOrdenServicioTrabajadores(CE_Orden_Servicio_Trabajadores orden_servicio_trabajadores)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarOrdenServicioTrabajadores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_tipo_trabajador", orden_servicio_trabajadores.cod_tipo_trabajador);
            comando.Parameters.AddWithValue("@responsable", orden_servicio_trabajadores.responsable);
            comando.Parameters.AddWithValue("@costo_hora", orden_servicio_trabajadores.costo_hora);
            comando.Parameters.AddWithValue("@Cod_Orden_Servicio", orden_servicio_trabajadores.Cod_Orden_Servicio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}