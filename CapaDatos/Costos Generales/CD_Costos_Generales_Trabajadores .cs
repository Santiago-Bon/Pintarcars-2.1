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
    public class CD_Costos_Generales_Trabajadores
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Insertar


        public void InsertarCostosGeneralesTrabajadores(CE_Costos_Generales_Trabajadores costos_generales_trabajadores)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCostosGeneralesTrabajadores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_tipo_trabajador", costos_generales_trabajadores.cod_tipo_trabajador);
            comando.Parameters.AddWithValue("@responsable", costos_generales_trabajadores.responsable);
            comando.Parameters.AddWithValue("@costo_hora", costos_generales_trabajadores.costo_hora);
            comando.Parameters.AddWithValue("@Cod_Costos_Generales", costos_generales_trabajadores.Cod_Costos_Generales);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}