using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Partes_Inspeccion
    {
        CD_Partes_Inspeccion oCD_Partes_Inspeccion = new CD_Partes_Inspeccion();


        //Consultar


        public DataTable MostrarPartesInspecion_CE()
        {
            DataTable tabla = oCD_Partes_Inspeccion.MostrarPartesInspecion_CE();
            return tabla;
        }


        public DataTable MostrarPartesInspecion_IC()
        {
            DataTable tabla = oCD_Partes_Inspeccion.MostrarPartesInspecion_IC();
            return tabla;
        }


        public DataTable MostrarPartesInspecion_IB()
        {
            DataTable tabla = oCD_Partes_Inspeccion.MostrarPartesInspecion_IB();
            return tabla;
        }


        public DataTable MostrarPartesInspecion_IV()
        {
            DataTable tabla = oCD_Partes_Inspeccion.MostrarPartesInspecion_IV();
            return tabla;
        }
    }
}
