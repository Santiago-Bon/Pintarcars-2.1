using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Orden_Trabajo
    {
        public string Cod { get; set; }
        public string Clave { get; set; }
        public string Kilometraje { get; set; }
        public DateTime Fecha_Llegada { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Descripcion { get; set; }
        public string entrega { get; set; }
        public string D_I_Usuario { get; set; }
        public float mano_obra { get; set; }
        public float repuestos { get; set; }
        public float otros { get; set; }
        public float Precio { get; set; }
        public float saldo { get; set; }
        public string D_I_Cliente { get; set; }
        public string Matricula_Vehiculo { get; set; }
        public int Cod_Cotizacion_Inicial { get; set; }
    }
}