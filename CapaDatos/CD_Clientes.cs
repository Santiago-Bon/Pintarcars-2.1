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
    public class CD_Clientes
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarCliente(CE_Clientes cliente)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@D_I", cliente.D_I);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@Celular", cliente.Celular);
            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            comando.Parameters.AddWithValue("@Correo", cliente.Correo);
            comando.Parameters.AddWithValue("@Cod_Tipo_Doc", cliente.Cod_Tipo_Doc);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}