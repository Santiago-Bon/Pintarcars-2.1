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
    public class CN_Tipo_Documento
    {
        CD_Tipo_Documento oCD_Tipo_Documento = new CD_Tipo_Documento();


        //Consultar


        public DataTable MostrarTipoDocumento()
        {
            DataTable tabla = oCD_Tipo_Documento.MostrarTipoDocumento();
            return tabla;
        }
    }
}
