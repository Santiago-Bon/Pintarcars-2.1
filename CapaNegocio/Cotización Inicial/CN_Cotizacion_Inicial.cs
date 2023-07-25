using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cotizacion_Inicial
    {
        CD_Cotizacion_Inicial oCD_Cotizacion_Inicial = new CD_Cotizacion_Inicial();


        //Consultar


        public string BuscarNumeroCotizacionInicial()
        {
            string factura = oCD_Cotizacion_Inicial.BuscarNumeroCotizacionInicial();
            return factura;
        }


        public DataTable MostrarCotizacionInicial()
        {
            DataTable tabla = oCD_Cotizacion_Inicial.MostrarCotizacionInicial();
            return tabla;
        }


        //Insertar


        public void InsertarCotizacionInicial(CE_Cotizacion_Inicial cotizacion_inicial)
        {
            oCD_Cotizacion_Inicial.InsertarCotizacionInicial(cotizacion_inicial);
        }
    }
}
