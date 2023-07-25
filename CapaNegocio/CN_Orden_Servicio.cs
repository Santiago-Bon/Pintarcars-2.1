using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Orden_Servicio
    {
        CD_Orden_Servicio oCD_Orden_Servicio = new CD_Orden_Servicio();


        //Insertar


        public void InsertarOrdenServicio(CE_Orden_Servicio orden_servicio)
        {
            oCD_Orden_Servicio.InsertarOrdenServicio(orden_servicio);
        }
    }
}
