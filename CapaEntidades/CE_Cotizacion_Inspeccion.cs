using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Cotizacion_Inspeccion
    {
        public int cod { get; set; }
        public string observaciones { get; set; }
        public int cod_partes_inspeccion { get; set; }
        public int cod_cotizacion { get; set; }
    }
}