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
    public class CN_Usuarios
    {
        CD_Usuarios oCD_Usuarios = new CD_Usuarios();


        //Consultar


        public bool BuscarUsuario(CE_Usuarios usuario)
        {
            DataTable encontrado = oCD_Usuarios.BuscarUsuario(usuario);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public DataTable TraerUsuario(CE_Usuarios usuario)
        {
            DataTable tabla = oCD_Usuarios.TraerUsuario(usuario);
            return tabla;
        }
    }
}
