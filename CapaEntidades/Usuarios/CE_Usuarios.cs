using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CE_Usuarios
    {
        public string D_I { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int Cod_Tipo_Documento { get; set; }
        public string Cod_Pais { get; set; }
        public string Cod_Departamento { get; set; }
        public int Cod_Tipo_Usuario { get; set; }
    }
}
