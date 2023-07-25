using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Tipo_Pago
    {
        CD_Tipo_Pago oCD_Tipo_Pago = new CD_Tipo_Pago();


        //Consultar


        public DataTable MostrarTipoPago()
        {
            DataTable tabla = oCD_Tipo_Pago.MostrarTipoPago();
            return tabla;
        }
    }
}
