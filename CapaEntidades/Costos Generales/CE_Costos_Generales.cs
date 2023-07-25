using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Costos_Generales
    {
        public int Cod { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Entrega_Final { get; set; }
        public string Proceso { get; set; }
        public float Costo_Total_Materiales { get; set; }
        public float Costo_Total_Mano_Obra { get; set; }
        public float Costo_Total { get; set; }
        public string D_I_Usuario { get; set; }
        public string Matricula_Vehiculo { get; set; }
        public int Cod_Orden_Trabajo { get; set; }
    }
}