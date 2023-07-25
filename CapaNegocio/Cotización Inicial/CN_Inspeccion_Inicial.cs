using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Inspeccion_Inicial
    {
        CD_Inspeccion_Inicial oCD_Inspeccion_Inicial = new CD_Inspeccion_Inicial();


        //Consultar


        //public string BuscarCodigoInspeccionInicial()
        //{
        //    string factura = oCD_Inspeccion_Inicial.BuscarCodigoInspeccionInicial();
        //    return factura;
        //}


        //Insertar


        public void InsertarInspeccionInicial(CE_Inspeccion_Inicial inspeccion_inicial)
        {
            oCD_Inspeccion_Inicial.InsertarInspeccionInicial(inspeccion_inicial);
        }
    }
}
