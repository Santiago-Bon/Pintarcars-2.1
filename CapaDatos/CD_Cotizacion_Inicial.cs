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
    public class CD_Cotizacion_Inicial
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public string BuscarNumeroCotizacionInicial()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNumeroCotizacionInicial";
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


        public void InsertarCotizacionInicial(CE_Cotizacion_Inicial cotizacion_inicial)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCotizacionInicial";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fecha_Llegada", cotizacion_inicial.Fecha_Llegada);
            comando.Parameters.AddWithValue("@Observaciones", cotizacion_inicial.Observaciones);
            comando.Parameters.AddWithValue("@Costo_Total", cotizacion_inicial.Costo_Total);
            comando.Parameters.AddWithValue("@Vendedor", cotizacion_inicial.Vendedor);
            comando.Parameters.AddWithValue("@D_I_Cliente", cotizacion_inicial.D_I_Cliente);
            comando.Parameters.AddWithValue("@Matricula_Vehiculo", cotizacion_inicial.Matricula_Vehiculo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
