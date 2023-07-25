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
    public class CD_Costos_Generales_Materiales
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarCostosGeneralesMateriales(CE_Costos_Generales_Materiales costos_generales_materiales)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCostosGeneralesMateriales";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cantidad", costos_generales_materiales.Cantidad);
            comando.Parameters.AddWithValue("@Costos_Unitarios", costos_generales_materiales.Costos_Unitarios);
            comando.Parameters.AddWithValue("@Fecha_Compra", costos_generales_materiales.Fecha_Compra);
            comando.Parameters.AddWithValue("@Cod_Costos_Generales", costos_generales_materiales.Cod_Costos_Generales);
            comando.Parameters.AddWithValue("@Cod_Materiales", costos_generales_materiales.Cod_Materiales);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}