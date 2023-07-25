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
    public class CD_Costos_Generales
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public string BuscarNumeroCostosGenerales()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNumeroCostosGenerales";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            if (Leer.Read() == true)
            {
                string cod = Leer["Cod"].ToString();
                Leer.Close();
                return cod;
            }
            else
            {
                Leer.Close();
                return " ";
            }
            conexion.CerrarConexion();
        }


        //Insertar


        public void InsertarCostosGenerales(CE_Costos_Generales costos_generales)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCostosGenerales";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fecha_Inicio", costos_generales.Fecha_Inicio);
            comando.Parameters.AddWithValue("@Fecha_Entrega_Final", costos_generales.Fecha_Entrega_Final);
            comando.Parameters.AddWithValue("@Proceso", costos_generales.Proceso);
            comando.Parameters.AddWithValue("@Costo_Total_Materiales", costos_generales.Costo_Total_Materiales);
            comando.Parameters.AddWithValue("@Costo_Total_Mano_Obra", costos_generales.Costo_Total_Mano_Obra);
            comando.Parameters.AddWithValue("@Costo_Total", costos_generales.Costo_Total);
            comando.Parameters.AddWithValue("@D_I_Usuario", costos_generales.D_I_Usuario);
            comando.Parameters.AddWithValue("@Matricula_Vehiculo", costos_generales.Matricula_Vehiculo);
            comando.Parameters.AddWithValue("@Cod_Orden_Trabajo", costos_generales.Cod_Orden_Trabajo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
