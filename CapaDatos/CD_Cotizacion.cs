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
    public class CD_Cotizacion
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public string BuscarNumeroCotizacion()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNumeroCotizacion";
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


        public void InsertarCotizacion(CE_Cotizacion cotizacion)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCotizacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Kilometraje", cotizacion.Kilometraje);
            comando.Parameters.AddWithValue("@Fecha_Llegada", cotizacion.Fecha_Llegada);
            comando.Parameters.AddWithValue("@Fecha_Entrega", cotizacion.Fecha_Entrega);
            comando.Parameters.AddWithValue("@Descripcion", cotizacion.Descripcion);
            comando.Parameters.AddWithValue("@entrega", cotizacion.entrega);
            comando.Parameters.AddWithValue("@recibe", cotizacion.recibe);
            comando.Parameters.AddWithValue("@mano_obra", cotizacion.mano_obra);
            comando.Parameters.AddWithValue("@repuestos", cotizacion.repuestos);
            comando.Parameters.AddWithValue("@otros", cotizacion.otros);
            comando.Parameters.AddWithValue("@Precio", cotizacion.Precio);
            comando.Parameters.AddWithValue("@saldo", cotizacion.saldo);
            comando.Parameters.AddWithValue("@D_I_Cliente", cotizacion.D_I_Cliente);
            comando.Parameters.AddWithValue("@Matricula_Vehiculo", cotizacion.Matricula_Vehiculo);
            comando.Parameters.AddWithValue("@Cod_Cotizacion_Inicial", cotizacion.Cod_Cotizacion_Inicial);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}