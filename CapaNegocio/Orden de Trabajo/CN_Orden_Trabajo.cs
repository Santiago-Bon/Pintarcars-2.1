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
    public class CN_Orden_Trabajo
    {
        CD_Orden_Trabajo oCD_Orden_Trabajo = new CD_Orden_Trabajo();


        //Consultar


        public string BuscarNumeroOrdenTrabajo()
        {
            string factura = oCD_Orden_Trabajo.BuscarNumeroOrdenTrabajo();
            return factura;
        }


        public DataTable MostrarOrdenTrabajo()
        {
            DataTable tabla = oCD_Orden_Trabajo.MostrarOrdenTrabajo();
            return tabla;
        }


        //Insertar


        public void InsertarOrdenTrabajo(CE_Orden_Trabajo orden_trabajo)
        {
            oCD_Orden_Trabajo.InsertarOrdenTrabajo(orden_trabajo);
        }
    }
}
