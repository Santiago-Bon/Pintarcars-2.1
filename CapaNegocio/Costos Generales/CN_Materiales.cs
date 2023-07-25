using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Materiales
    {
        CD_Materiales oCD_Materiales = new CD_Materiales();


        //Consultar


        public DataTable MostrarMateriales()
        {
            DataTable tabla = oCD_Materiales.MostrarMateriales();
            return tabla;
        }
    }
}
