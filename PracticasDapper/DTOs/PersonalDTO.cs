using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasDapper.DTOs
{
    class PersonalDTO_Get
        //Este DTO lo utilizo para mostrar solo los datos necesarios
    { 
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public int ID_Jefe { get; set; }
    }

    class EmpleadoDTO_Get : PersonalDTO_Get
    { 
    }

    class SupervisorDTO_Get:PersonalDTO_Get
    {
        public int Empleados_Supervisados { get; set; }
    }
    class EncargadoDTO_Get:PersonalDTO_Get
    {
        public int Sucursales_Supervisadas { get; set; }
    }

    class PersonalDTO_Insert
        //Este DTO lo utilizo para mostrar solo los datos necesarios
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public int ID_Jefe { get; set; }

    }
    

}
