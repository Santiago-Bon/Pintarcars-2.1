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
    public class CD_Inspeccion_Inicial
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        //public string BuscarCodigoInspeccionInicial()
        //{
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "BuscarCodigoInspeccionInicial";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    Leer = comando.ExecuteReader();
        //    if (Leer.Read() == true)
        //    {
        //        string cod = Leer["cod"].ToString();
        //        Leer.Close();
        //        return cod;
        //    }
        //    else
        //    {
        //        Leer.Close();
        //        return " ";
        //    }
        //    conexion.CerrarConexion();
        //}


        //Insertar


        public void InsertarInspeccionInicial(CE_Inspeccion_Inicial inspeccion_inicial)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarInspeccionInicial";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cantidad", inspeccion_inicial.Cantidad);
            comando.Parameters.AddWithValue("@Descripcion", inspeccion_inicial.Descripcion);
            comando.Parameters.AddWithValue("@Costos_Unitarios", inspeccion_inicial.Costos_Unitarios);
            comando.Parameters.AddWithValue("@cod_cotizacion_inicial", inspeccion_inicial.cod_cotizacion_inicial);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}