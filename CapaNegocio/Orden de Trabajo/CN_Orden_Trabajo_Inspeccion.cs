using CapaDatos.Orden_de_Trabajo;
using CapaEntidades.Orden_de_Trabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Orden_de_Trabajo
{
    public class CN_Orden_Trabajo_Inspeccion
    {
        CD_Orden_Trabajo_Inspeccion oCD_Orden_Trabajo_Inspeccion = new CD_Orden_Trabajo_Inspeccion();


        //Insertar


        public void InsertarOrdenTrabajoInspeccion(CE_Orden_Trabajo_Inspeccion orden_trabajo_inspeccion)
        {
            oCD_Orden_Trabajo_Inspeccion.InsertarOrdenTrabajoInspeccion(orden_trabajo_inspeccion);
        }
    }
}
