using CapaDatos.Orden_de_Trabajo;
using CapaEntidades.Orden_de_Trabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Orden_de_Trabajo
{
    public class CN_Pagos
    {
        CD_Pagos oCD_Pagos = new CD_Pagos();


        //Insertar


        public void InsertarPago(CE_Pagos pago)
        {
            oCD_Pagos.InsertarPago(pago);
        }
    }
}
