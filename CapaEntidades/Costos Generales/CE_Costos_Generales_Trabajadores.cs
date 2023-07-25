using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Costos_Generales_Trabajadores
    {
        public int Cod { get; set; }
        public int cod_tipo_trabajador { get; set; }
        public string responsable { get; set; }
        public float costo_hora { get; set; }
        public int Cod_Costos_Generales { get; set; }
    }
}
