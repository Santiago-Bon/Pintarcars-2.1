using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Vehiculos
    {
        CD_Vehiculos oCD_Vehiculos = new CD_Vehiculos();


        //Insertar


        public void InsertarVehiculo(CE_Vehiculos vehiculo)
        {
            oCD_Vehiculos.InsertarVehiculo(vehiculo);
        }
    }
}
