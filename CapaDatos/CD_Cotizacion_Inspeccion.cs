using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cotizacion_Inspeccion
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarCotizacionInspeccion(CE_Cotizacion_Inspeccion cotizacion_inspeccion)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCotizacionInspeccion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@observaciones", cotizacion_inspeccion.observaciones);
            comando.Parameters.AddWithValue("@cod_partes_inspeccion", cotizacion_inspeccion.cod_partes_inspeccion);
            comando.Parameters.AddWithValue("@cod_cotizacion", cotizacion_inspeccion.cod_cotizacion);
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
