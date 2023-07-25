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
    public class CD_Tipo_Documento
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();

        
        //Consultar


        public DataTable MostrarTipoDocumento()
        {
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarTipoDocumento";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
    }
}
