using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Materiales
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public DataTable MostrarMateriales()
        {
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarMateriales";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
    }
}
