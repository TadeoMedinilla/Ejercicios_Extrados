using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_2
{
    class Identificador
    {
        public int numero = 100;
        //Crear metodo para verificar la unicidad del ID en caso de ser ingresado.         
    }
    class Empleado
    {
        // Atributos 

        public int ID { get; set; }
        //public string FullName { get { return this.FullName; } set { FullName = value; } }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        //public string Job { get { return this.Job; } set { this.Job = Convert.ToString(this.GetType()); } }
        public virtual string Job { get; } = "Empleado";
        //public int status { get { return this.status; } set { this.status = 0; } } 
        public int status { get; set; } // 0: Activo; 1: Inactivo.

        /* Metodos a definir:
        - C.R.U.D. 
        - Buscar empleado por nombre 
         */

        // Constructor

        public Empleado(string nombre, string fechaDeNac)
        {
            FullName = nombre;
            BirthDate = fechaDeNac;
        }

        //Getters:
        public virtual int GetID()
        {
            return ID;
        }
        public virtual string GetFullName()
        {
            return FullName;
        }
        public virtual string GetBirthDate()
        {
            return BirthDate;
        }
        public virtual string GetJob()
        {
            return Job;
        }
        public virtual int GetStatus()
        {
            return status;
        }
        public virtual void MostrarEmpleado()
        //Muestra nombre, ID y puesto.
        {
            Console.WriteLine($"{FullName} - \t ID: {ID} - \t Puesto: {Job}\n");
        }
        public virtual void InformacionEmpleado()
        //Muestra la info completa del empleado
        {
            Console.WriteLine($"Nombre: {FullName} - \tPuesto: {Job} \nID: {ID} - \tFecha de nacimiento: {BirthDate}");
        }
        public Supervisor AscenderASupervisor()
        {
            Console.WriteLine("Ingrese la cantidad de empleados que va a tener a cargo.");
            int aCargo = Convert.ToInt32(Console.ReadLine());
            Supervisor ascendido = new Supervisor(this.FullName, this.BirthDate, aCargo);
            ascendido.ID = this.ID;
            this.ID = 0; // Aquellos empleados con ID 0 su puesto fue modificado al menos una vez. 
            this.status = 1; // status 1 = Inactivo. 
            return ascendido;
        }
        public virtual EncargadoRegional AscenderAEncargado()
        {
            Console.WriteLine("Ingrese la cantidad de sucursales que va a tener a cargo.");
            int aCargo = Convert.ToInt32(Console.ReadLine());
            EncargadoRegional ascendido = new EncargadoRegional(this.FullName, this.BirthDate, aCargo);
            ascendido.ID = this.ID;
            this.ID = 0; // Aquellos empleados con ID 0 su puesto fue modificado al menos una vez. 
            this.status = 1; // status 1 = Inactivo.
            return ascendido;
        }
    }

    class Supervisor:Empleado
    {
        // Atributos
        public int EmpleadosSupervisados {get; set;}
        public override string Job { get; } = "Supervisor";

        // Metodos

        public Supervisor(string nombre, string fechaDeNac, int empleadosACargo):base(nombre,fechaDeNac)
        {
            this.FullName = nombre;
            this.BirthDate = fechaDeNac;
            this.EmpleadosSupervisados = empleadosACargo;
        }
        public override void InformacionEmpleado()
            //Muestra la info completa del empleado
        {
            Console.WriteLine($"Nombre: {FullName} - \tPuesto: {Job} " +
                              $"\nID: {ID} - \tFecha de nacimiento: {BirthDate} - " +
                              $"\n Empleados a cargo: {EmpleadosSupervisados}");
        }

    }

    class EncargadoRegional : Empleado
    {
        //Atributos
        public int SucursalesACargo {get; set;}
        public override string Job { get; } = "Encargado Regional";

        //Metodos 
        public EncargadoRegional(string nombre, string fechaDeNac, int sucursales):base(nombre,fechaDeNac)
        {
            this.FullName = nombre;
            this.BirthDate = fechaDeNac;
            this.SucursalesACargo = sucursales;
        }
        public override void InformacionEmpleado()
            //Muestra la info completa del empleado
        {
            Console.WriteLine($"\nNombre: {FullName} - \tPuesto: {Job} " +
                               $"\nID: {ID} - \tFecha de nacimiento: {BirthDate} - " +
                               $"\nSucursales a cargo: {SucursalesACargo}\n");
        }
    }
}
