using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Costos_Generales_Materiales
    {
        CD_Costos_Generales_Materiales oCD_Costos_Generales_Materiales = new CD_Costos_Generales_Materiales();


        //Insertar


        public void InsertarCostosGeneralesMateriales(CE_Costos_Generales_Materiales costos_generales_materiales)
        {
            oCD_Costos_Generales_Materiales.InsertarCostosGeneralesMateriales(costos_generales_materiales);
        }
    }
}
