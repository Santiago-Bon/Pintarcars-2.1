using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Partes_Inspeccion
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public DataTable MostrarPartesInspecion_CE()
        {
            DataTable Tabla = new DataTable();
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPartesInspecion_CE";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable MostrarPartesInspecion_IC()
        {
            DataTable Tabla = new DataTable();
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPartesInspecion_IC";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable MostrarPartesInspecion_IB()
        {
            DataTable Tabla = new DataTable();
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPartesInspecion_IB";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable MostrarPartesInspecion_IV()
        {
            DataTable Tabla = new DataTable();
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPartesInspecion_IV";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
    }
}
