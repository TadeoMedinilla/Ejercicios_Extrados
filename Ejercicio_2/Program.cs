using System;

namespace Ejercicio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Empleado Tadeo = new Empleado("Tadeo", "DD/MM");
            //Tadeo.FullName= "Tadeo";
            Supervisor Marisa = new Supervisor("Tadeo", "DD/MM", 1);
            //Marisa.FullName = "Marisa";
            ObjList Empleados = new ObjList(2);
            Empleados.Push(Marisa);
            //Tadeo.AscenderASupervisor();
            //Empleados.Push(Tadeo.AscenderASupervisor());
            
            
            Empleados.BuscarPorNombre("Tadeo");
            Console.Read();*/
            ObjList BD = new ObjList(1);
            Empleado Tadeo = new Empleado("Tadeo", "DD/MM");
            Empleado Marisa = new Empleado("Marisa", "DD/MM");
            Empleado Alejo = new Empleado("Alejo", "DD/MM");
            BD.Push(Tadeo);
            Marisa.ID = 1;
            BD.Push(Marisa);
            Alejo.ID = 2;
            BD.Push(Alejo);
            MenuPrincipal(BD);
            Console.ReadLine();
            
        }

        // MENU PRINCIPAL
        //ObjList BD = new ObjList(1);
        public static void AscenderAEncargadoRegional(int id, ObjList BD)
        {
            Console.WriteLine("Ingrese la cantidad de sucursales que tendra a cargo:");
            int aCargo = Convert.ToInt32(Console.ReadLine());
            string nombre = BD.GetObjeto(id).FullName;
            string fechaDeNac = BD.GetObjeto(id).BirthDate;

            EncargadoRegional NuevoEncargado = new EncargadoRegional(nombre, fechaDeNac, aCargo);
            BD.GetObjeto(id).status = 1; 
            NuevoEncargado.ID = BD.GetObjeto(id).ID;
            BD.GetObjeto(id).ID = 0;
            
            BD.Push(NuevoEncargado);
        }
        public static void AscenderASupervisor(int id, ObjList BD)
        {
            Console.WriteLine("Ingrese la cantidad de empleados que tendra a cargo:");
            int aCargo = Convert.ToInt32(Console.ReadLine());
            string nombre = BD.GetObjeto(id).FullName;
            string fechaDeNac = BD.GetObjeto(id).BirthDate;

            Supervisor NuevoSupervisor = new Supervisor(nombre, fechaDeNac, aCargo);
            BD.GetObjeto(id).status = 1;
            NuevoSupervisor.ID = BD.GetObjeto(id).ID;
            BD.GetObjeto(id).ID = 0;
           
            BD.Push(NuevoSupervisor);
        }
        public static void MenuPrincipal( ObjList BD)
        {
            Console.WriteLine("¡Bienvenido!");
            while (true)
            {
                Console.WriteLine("Menu principal:\n" +
                                    "1 - Listar todos los empleados activos\n" +
                                    "2 - Listar todos los empleados inactivos\n" +
                                    "3 - Buscar empleado\n" +
                                    "4 - Agregar empleado\n" +
                                    "5 - Eliminar empleado\n" +
                                    "6 - Ascender empleado\n" +
                                    "7 - Salir\n" +
                                    "Ingrese el numero de la opcion que desee seleccionar");

                int seleccion = Convert.ToInt32(Console.ReadLine());
                if (seleccion == 1)
                {
                    BD.ImprimirActivos();
                        //Tratar error en caso de lista vacia. 
                }
                if (seleccion == 2)
                {
                    BD.ImprimirInactivos();
                        //Tratar error en caso de lista vacia.
                }
                if (seleccion == 3)
                {
                    Console.WriteLine("Ingrese el nombre del empleado a buscar:");
                    string nombre = Console.ReadLine();
                    BD.BuscarPorNombre(nombre);
                        //Tratar error por no encontrar resultado
                }
                if (seleccion==4)
                {
                    break;
                }
                if (seleccion == 6) //Ascender
                {
                    Console.WriteLine("Ingrese el ID del empleado que desea ascender:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string Job = (BD.GetObjeto(id)).Job;
                    while (true)
                    {
                        if (Job == "Empleado")  //Puedo ascender a supervisor y a encargado regional
                        {
                            Console.WriteLine("Opciones:\n" +
                                               "1 - Ascender a Supervisor\n" +
                                               "2 - Ascender a Encargado\n" +
                                    "Ingrese el numero de la opcion que desee seleccionar");
                            int opcion = Convert.ToInt32(Console.ReadLine());
                            if (opcion == 1) 
                            {
                                AscenderASupervisor(id,BD);
                                break;
                            }
                            if (opcion == 2)
                            {
                                AscenderAEncargadoRegional(id, BD);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La opcion ingresada es incorrecta");
                            }
                        }
                        if (Job == "Supervisor") 
                        {
                            AscenderAEncargadoRegional(id, BD);
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("No se puede ascender a Encargados regionales.");
                        }
                    }
                }
                if (seleccion == 7)
                {
                    break;
                }
            }
        }
    
    
    }
}
