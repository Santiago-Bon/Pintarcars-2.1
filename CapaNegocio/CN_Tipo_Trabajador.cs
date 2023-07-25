using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Tipo_Trabajador
    {
        CD_Tipo_Trabajador oCD_Tipo_Trabajador = new CD_Tipo_Trabajador();


        //Consultar


        public DataTable MostrarTipoTrabajador()
        {
            DataTable tabla = oCD_Tipo_Trabajador.MostrarTipoTrabajador();
            return tabla;
        }
    }
}
