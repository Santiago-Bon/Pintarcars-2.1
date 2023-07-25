using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Cotizacion_Inicial
    {
        public int Cod { get; set; }
        public DateTime Fecha_Llegada { get; set; }
        public string Observaciones { get; set; }
        public float Costo_Total { get; set; }
        public string D_I_Usuario { get; set; }
        public string Matricula_Vehiculo { get; set; }
        public string D_I_Cliente { get; set; }
    }
}