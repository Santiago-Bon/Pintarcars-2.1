using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Orden_Servicio_Materiales
    {
        CD_Orden_Servicio_Materiales oCD_Orden_Servicio_Materiales = new CD_Orden_Servicio_Materiales();


        //Insertar


        public void InsertarOrdenServicioMateriales(CE_Orden_Servicio_Materiales orden_servicio_materiales)
        {
            oCD_Orden_Servicio_Materiales.InsertarOrdenServicioMateriales(orden_servicio_materiales);
        }
    }
}
