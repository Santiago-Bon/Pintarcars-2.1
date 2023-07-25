using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Orden_de_Trabajo
{
    public class CE_Pagos
    {
        public int Cod { get; set; }
        public float Monto { get; set; } 
        public DateTime Fecha { get; set; }
        public int Cod_Tipo_Pago { get; set; }
        public int Cod_Orden_Trabajo { get; set; }
    }
}
