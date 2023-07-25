using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Pagos
    {
        public int Cod { get; set; }
        public DateTime Fecha { get; set; }
        public int Cod_Tipo_Pago { get; set; }
        public int cod_cotizacion { get; set; }
    }
}
