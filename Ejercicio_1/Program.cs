using System;

namespace EXTRADOS___Ejercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] Empleados = new string[,]
        // La estructura de datos es { Nro de empleado, Nombre, puesto, empleados a cargo, sucurcales a cargo}
        // Puesto: 0. Empleado; 1. Supervisor; 2. Encargado regional
            {
                { "100","Tadeo Medinilla", "0","0","0", "DD/MM/YY"},
                { "101", "Pepe Flores", "1", "10" , "0", "DD/MM/YY" },
                { "102", "Juan Perez", "2", "0", "10", "DD/MM/YY"},
                { "103", "Rafael Nadal", "1", "30", "0", "DD/MM/YY"},
                { "104", "Roger Federer", "0", "0", "0", "DD/MM/YY"}
            };

            MenuPrincipal(Empleados);
            Console.Read();
        }
        
        public static void ListarEmpleados(string [,] Emp)
        {   
            int row = 0;
            string puesto = "" ;
            string mensaje = "" ;
            string nombre ;
            string cumple;
            while (row < 5 )
                // Modificar la logica y calcular la cantidad de columnas de la matriz Empleados
            {
                int emp = Convert.ToInt32(Emp[row, 0]);
                nombre = Emp[row, 1];
                cumple = Emp[row, 5];
                if (Emp[row, 2] == "0")
                {
                    puesto = "Empleado";
                    mensaje = ".";
                }
                else if (Emp[row, 2] == "1")
                {
                    puesto = "Supervisor";
                    mensaje = ($", Empleados a cargo: {Emp[row, 3]}.");
                }

                else if (Emp[row, 2] == "2")
                {
                    puesto = "Encargado Regional";
                    mensaje = ($", Sucursales a cargo: {Emp[row, 4]}.");
                }
                Console.WriteLine($"Empleado: {emp}, Nombre: {nombre}, Fecha de nacimiento: {cumple}, Puesto: {puesto}{mensaje}\n");
                row += 1;
            }
        }
        
        public static void ModificarEmpleado( string [,] Emp)
        {
            int row = 0;
            Console.WriteLine("Ingrese el empleado a modificar:");
            string EmpAMod = Console.ReadLine();
            // EmpAMod = Empleado a modificar 
            while (row < 5)
            {
                if (EmpAMod != Emp[row,0])
                {
                    row += 1;
                }
                
                else
                {
                    if (Emp[row, 2] == "2")
                    {
                        Console.WriteLine("No se puede ascender a encargados regionales.\n");
                    }

                    else
                    {
                        Console.WriteLine("Seleccione el puesto al que sera ascendido \n" +
                                            "1. Supervisor\n" +
                                            "2. Encargado Regional\n");
                        string PuestoNuevo = Console.ReadLine();
                        if (PuestoNuevo == "1")
                        {
                            Emp[row, 2] = PuestoNuevo;
                            Console.WriteLine("Ingrese la cantidad de empleados a cargo que tendra:");
                            Emp[row, 3] = Console.ReadLine();
                        }
                        else if (PuestoNuevo == "2")
                        {
                            Emp[row, 2] = PuestoNuevo;
                            Emp[row, 3] = "0";
                            Console.WriteLine("Ingrese la cantidad de sucursales a cargo tendra:");
                            Emp[row, 4] = Console.ReadLine();
                        }
                    }
                break;
                }
                
            }
        }

        public static void MenuPrincipal(string [,] Empleados)
        {
            while (true)
            {
                Console.WriteLine("Menu de opciones seleccione la accion a realizar:\n" +
                                "1- Listar a todos los empleados.\n" +
                                "2- Ascender a un empleado.\n" +
                                "3- Cerrar menú.\n");
                string opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    ListarEmpleados(Empleados);
                }
                else if (opcion == "2")
                {
                    ModificarEmpleado(Empleados);
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("\nCerrando programa.");
                    break;
                }
                else
                {
                    Console.WriteLine("La opcion ingresada no es correcta.\n");
                }
            }

        }
    }
}
