using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Entidades
{
    public class Personal
    {
        public int ID_Personal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Puesto { get; set; } //1. Empleado 2. Supervisor 3. Encargado
        public int ID_Jefe { get; set; }
        public int Status { get; set; }// 0. Activo 1. Inactivo

    }

    class Empleado : Personal
    {
        
    }

    class Supervisor : Personal
    {
        public int Empleados_Supervisados { get; set; }
    }

    class Encargado : Personal
    {
        public int? Sucursales_Supervisadas { get; set; }
    }
}
