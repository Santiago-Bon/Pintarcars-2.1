﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Orden_Servicio_Materiales
    {
        public int Cod { get; set; }
        public float Cantidad { get; set; }
        public float Costos_Unitarios { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public int Cod_Orden_Servicio { get; set; }
        public int Cod_Materiales { get; set; }
    }
}