using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        CD_Clientes oCD_Clientes = new CD_Clientes();


        //Consultar


        public DataTable MostrarCliente(CE_Cotizacion_Inicial cotizacion_inicial)
        {
            DataTable tabla = oCD_Clientes.MostrarCliente(cotizacion_inicial);
            return tabla;
        }


        //Insertar


        public void InsertarCliente(CE_Clientes cliente)
        {
            oCD_Clientes.InsertarCliente(cliente);
        }
    }
}
