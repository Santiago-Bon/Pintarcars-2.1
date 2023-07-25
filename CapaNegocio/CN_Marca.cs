using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Marca
    {
        CD_Marca oCD_Marca = new CD_Marca();


        //Consultar


        public DataTable MostrarMarcas()
        {
            DataTable tabla = oCD_Marca.MostrarMarcas();
            return tabla;
        }
    }
}
