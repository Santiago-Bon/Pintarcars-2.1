using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
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
