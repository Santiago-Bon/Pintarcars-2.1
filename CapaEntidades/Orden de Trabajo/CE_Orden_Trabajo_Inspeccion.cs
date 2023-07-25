using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Orden_de_Trabajo
{
    public class CE_Orden_Trabajo_Inspeccion
    {
        public int cod { get; set; }
        public string observaciones { get; set; }
        public int cod_partes_inspeccion { get; set; }
        public int cod_Orden_Trabajo { get; set; }
    }
}
