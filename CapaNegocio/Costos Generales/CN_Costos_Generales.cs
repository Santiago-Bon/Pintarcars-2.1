using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Costos_Generales
    {
        CD_Costos_Generales oCD_Costos_Generales = new CD_Costos_Generales();


        //Consultar


        public string BuscarNumeroCostosGenerales()
        {
            string factura = oCD_Costos_Generales.BuscarNumeroCostosGenerales();
            return factura;
        }


        //Insertar


        public void InsertarCostosGenerales(CE_Costos_Generales costos_generales)
        {
            oCD_Costos_Generales.InsertarCostosGenerales(costos_generales);
        }
    }
}
