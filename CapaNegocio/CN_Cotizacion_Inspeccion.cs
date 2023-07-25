using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cotizacion_Inspeccion
    {
        CD_Cotizacion_Inspeccion oCD_Cotizacion_Inspeccion = new CD_Cotizacion_Inspeccion();


        //Insertar


        public void InsertarCotizacionInspeccion(CE_Cotizacion_Inspeccion cotizacion_inspeccion)
        {
            oCD_Cotizacion_Inspeccion.InsertarCotizacionInspeccion(cotizacion_inspeccion);
        }
    }
}

