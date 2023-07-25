using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        CD_Clientes oCD_Clientes = new CD_Clientes();


        //Insertar


        public void InsertarCliente(CE_Clientes cliente)
        {
            oCD_Clientes.InsertarCliente(cliente);
        }
    }
}
