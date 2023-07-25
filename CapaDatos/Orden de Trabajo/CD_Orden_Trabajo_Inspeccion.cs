using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.Orden_de_Trabajo;

namespace CapaDatos.Orden_de_Trabajo
{
    public class CD_Orden_Trabajo_Inspeccion
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarOrdenTrabajoInspeccion(CE_Orden_Trabajo_Inspeccion orden_trabajo_inspeccion)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarOrdenTrabajoInspeccion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@observaciones", orden_trabajo_inspeccion.observaciones);
            comando.Parameters.AddWithValue("@cod_partes_inspeccion", orden_trabajo_inspeccion.cod_partes_inspeccion);
            comando.Parameters.AddWithValue("@cod_Orden_Trabajo", orden_trabajo_inspeccion.cod_Orden_Trabajo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
