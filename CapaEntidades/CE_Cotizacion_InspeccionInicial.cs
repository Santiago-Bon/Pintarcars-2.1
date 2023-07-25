using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Cotizacion_InspeccionInicial
    {
        public int Cod { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public float Costos_Unitarios { get; set; }
        public int cod_cotizacion_inicial { get; set; }
        public int cod_inspeccion_inicial { get; set; }
    }
}