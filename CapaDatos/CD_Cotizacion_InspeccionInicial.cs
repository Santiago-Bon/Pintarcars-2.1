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
    public class CD_Cotizacion_InspeccionInicial
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarCotizacion_InspeccionInicial(CE_Cotizacion_InspeccionInicial cotizacion_inspeccioninicial)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCotizacion_InspeccionInicial";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cantidad", cotizacion_inspeccioninicial.Cantidad);
            comando.Parameters.AddWithValue("@Descripcion", cotizacion_inspeccioninicial.Descripcion);
            comando.Parameters.AddWithValue("@Costos_Unitarios", cotizacion_inspeccioninicial.Costos_Unitarios);
            comando.Parameters.AddWithValue("@cod_cotizacion_inicial", cotizacion_inspeccioninicial.cod_cotizacion_inicial);
            comando.Parameters.AddWithValue("@cod_inspeccion_inicial", cotizacion_inspeccioninicial.cod_inspeccion_inicial);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
