using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.DTOs
{
    class PersonalDTOs
    {
        public int ID_Personal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Email { get; set; }
        public virtual int Puesto { get; set; }
        public int? ID_Jefe { get; set; }
        public int? Status { get; set; }// 0. Activo 1. Inactivo
    }
    class EmpleadoDTOs : PersonalDTOs 
    {
        public override int Puesto { get; set; } = 1;//1. Empleado 2. Supervisor 3. Encargado
    }
    class SupervisorDTOs : PersonalDTOs
    {
        public override int Puesto { get; set; } = 2;//1. Empleado 2. Supervisor 3. Encargado
        public int? Empleados_Supervisados { get; set; }
    }
    class EncargadoDTOs : PersonalDTOs
    {
        public override int Puesto { get; set; } = 3;//1. Empleado 2. Supervisor 3. Encargado
        public int? Sucursales_Supervisadas { get; set; }
    }

}
