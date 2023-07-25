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
    public class CD_Vehiculos
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public DataTable MostrarVehiculo(CE_Orden_Trabajo orden_trabajo)
        {
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarVehiculo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cod", orden_trabajo.Cod);
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        //Insertar


        public void InsertarVehiculo(CE_Vehiculos vehiculo)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarVehiculo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Matricula", vehiculo.Matricula);
            comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            comando.Parameters.AddWithValue("@Color", vehiculo.Color);
            comando.Parameters.AddWithValue("@Año", vehiculo.Año);
            comando.Parameters.AddWithValue("@Cod_Marca", vehiculo.Cod_Marca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
