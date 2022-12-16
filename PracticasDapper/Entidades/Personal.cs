using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasDapper.Entidades
{
    class Personal
    {
        public int ID_Empleado { get; set; }
        public string  Nombre { get; set; }
        public string Puesto { get; set; }
        public int ID_Jefe { get; set; }

    }
    class Empleado:Personal
    { 
    }

    class Supervisor: Personal
    {
        public int Empleados_Supervisados { get; set; }
    }
    
    class Encargado: Personal
    {
        public int Sucursales_Supervisadas { get; set; }
    }

}
