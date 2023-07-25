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
    public class CD_Orden_Trabajo
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public string BuscarNumeroOrdenTrabajo()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNumeroOrdenTrabajo";
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


        public DataTable MostrarOrdenTrabajo()
        {
            comando.Parameters.Clear();
            Tabla.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarOrdenTrabajo";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        //Insertar


        public void InsertarOrdenTrabajo(CE_Orden_Trabajo orden_trabajo)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarOrdenTrabajo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Clave", orden_trabajo.Clave);
            comando.Parameters.AddWithValue("@Kilometraje", orden_trabajo.Kilometraje);
            comando.Parameters.AddWithValue("@Fecha_Llegada", orden_trabajo.Fecha_Llegada);
            comando.Parameters.AddWithValue("@Fecha_Entrega", orden_trabajo.Fecha_Entrega);
            comando.Parameters.AddWithValue("@Descripcion", orden_trabajo.Descripcion);
            comando.Parameters.AddWithValue("@entrega", orden_trabajo.entrega);
            comando.Parameters.AddWithValue("@D_I_Usuario", orden_trabajo.D_I_Usuario);
            comando.Parameters.AddWithValue("@mano_obra", orden_trabajo.mano_obra);
            comando.Parameters.AddWithValue("@repuestos", orden_trabajo.repuestos);
            comando.Parameters.AddWithValue("@otros", orden_trabajo.otros);
            comando.Parameters.AddWithValue("@Precio", orden_trabajo.Precio);
            comando.Parameters.AddWithValue("@saldo", orden_trabajo.saldo);
            comando.Parameters.AddWithValue("@D_I_Cliente", orden_trabajo.D_I_Cliente);
            comando.Parameters.AddWithValue("@Matricula_Vehiculo", orden_trabajo.Matricula_Vehiculo);
            comando.Parameters.AddWithValue("@Cod_Cotizacion_Inicial", orden_trabajo.Cod_Cotizacion_Inicial);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
