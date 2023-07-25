using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cotizacion
    {
        CD_Cotizacion oCD_Cotizacion = new CD_Cotizacion();


        //Consultar


        public string BuscarNumeroCotizacion()
        {
            string factura = oCD_Cotizacion.BuscarNumeroCotizacion();
            return factura;
        }


        //Insertar


        public void InsertarCotizacion(CE_Cotizacion cotizacion)
        {
            oCD_Cotizacion.InsertarCotizacion(cotizacion);
        }
    }
}
