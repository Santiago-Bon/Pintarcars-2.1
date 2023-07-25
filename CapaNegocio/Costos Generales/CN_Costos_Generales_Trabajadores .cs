using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Costos_Generales_Trabajadores
    {
        CD_Costos_Generales_Trabajadores oCD_Costos_Generales_Trabajadores = new CD_Costos_Generales_Trabajadores();


        //Insertar


        public void InsertarCostosGeneralesTrabajadores(CE_Costos_Generales_Trabajadores costos_generales_trabajadores)
        {
            oCD_Costos_Generales_Trabajadores.InsertarCostosGeneralesTrabajadores(costos_generales_trabajadores);
        }
    }
}
