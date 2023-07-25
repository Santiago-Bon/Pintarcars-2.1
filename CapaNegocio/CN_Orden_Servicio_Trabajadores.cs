using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Orden_Servicio_Trabajadores
    {
        CD_Orden_Servicio_Trabajadores oCD_Orden_Servicio_Trabajadores = new CD_Orden_Servicio_Trabajadores();


        //Insertar


        public void InsertarOrdenServicioTrabajadores(CE_Orden_Servicio_Trabajadores orden_servicio_trabajadores)
        {
            oCD_Orden_Servicio_Trabajadores.InsertarOrdenServicioTrabajadores(orden_servicio_trabajadores);
        }
    }
}
