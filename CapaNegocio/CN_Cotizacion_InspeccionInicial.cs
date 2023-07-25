using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cotizacion_InspeccionInicial
    {
        CD_Cotizacion_InspeccionInicial oCD_Cotizacion_InspeccionInicial = new CD_Cotizacion_InspeccionInicial();


        //Insertar


        public void InsertarCotizacion_InspeccionInicial(CE_Cotizacion_InspeccionInicial cotizacion_inspeccioninicial)
        {
            oCD_Cotizacion_InspeccionInicial.InsertarCotizacion_InspeccionInicial(cotizacion_inspeccioninicial);
        }
    }
}
