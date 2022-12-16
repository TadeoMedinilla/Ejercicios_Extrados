// See https://aka.ms/new-console-template for more information

using AutoMapper;
using Dapper;
using PracticasDapper.DTOs;
using PracticasDapper.Entidades;
using System.Data.SqlClient;

class Program
{
    private static void Main(string[] args)
    {
        var connectionString = "Data Source=.;Initial Catalog=Empresa;Integrated Security=True";

        IMapper mapper = SetAutomapper();

        GetEmpleado(connectionString,mapper);
        
        Console.WriteLine("Hello, World!");
    }

    static IMapper SetAutomapper()
    //Aqui creo los mapeos necesarios
    {
        var config = new MapperConfiguration(configuration =>
        {
            configuration.CreateMap<Personal, PersonalDTO_Get>();
            configuration.CreateMap<Empleado, EmpleadoDTO_Get>();
            configuration.CreateMap<Encargado, EncargadoDTO_Get>();
        });
        return config.CreateMapper();
    }

    static void GetEmpleados(string connectionString, IMapper mapper)
    {
        var query = "SELECT * FROM Personal WHERE puesto = 'Empleado'";

        using (var connection = new SqlConnection(connectionString))
        {

            var empleados = connection.Query<Empleado>(query).ToList(); //Obtengo los empleados
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados");
            }
            List<EmpleadoDTO_Get> empleadosDTOs = new List<EmpleadoDTO_Get>(); //Genero la lista de DTOs

            foreach (Empleado item in empleados) //Transfiero los objetos a la lista de DTOs
            {
                var aux = mapper.Map<Empleado, EmpleadoDTO_Get>(item); //Mapeo al DTO [Nota: CREAR EL MAPEO EN 'SetAutomapper()'] 
                empleadosDTOs.Add(aux); //Agrego el DTO al List.
            }
        }
    }

    static void GetEncargados(string connectionString, IMapper mapper)
    {
        var query = "SELECT * FROM Personal WHERE Puesto = 'Encargado'";

        using (var connection = new SqlConnection(connectionString))
        {
            var encargados = connection.Query<Encargado>(query).ToList();
            if (encargados.Count == 0)
            {
                Console.WriteLine("No hay supervisores registrados.");
            }
            else
            {
                List<EncargadoDTO_Get> encargadosDTOs = new List<EncargadoDTO_Get>();

                foreach (Encargado item in encargados)
                {
                    var aux = mapper.Map<Encargado, EncargadoDTO_Get>(item);
                    encargadosDTOs.Add(aux);
                }
            }

        }
    }

    static void GetSupervisores(string connectionString, IMapper mapper)
    {
        var query = "SELECT * FROM Personal WHERE Puesto = 'Supervisor'";

        using (var connection = new SqlConnection(connectionString))
        {
            var supervisores = connection.Query<Supervisor>(query).ToList();
            if (supervisores.Count == 0)
            {
                Console.WriteLine("No hay supervisores registrados.");
            }
            else
            {
                List<SupervisorDTO_Get> supervisoresDTOs = new List<SupervisorDTO_Get>();

                foreach (Supervisor item in supervisores)
                {
                    var aux = mapper.Map<Supervisor, SupervisorDTO_Get>(item);
                    supervisoresDTOs.Add(aux);
                }
            }
        }
    }

    static void GetEmpleado(string connectionString, IMapper mapper)
    {
        var query = "SELECT * FROM Personal WHERE Nombre LIKE @Nombre";

        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Ingrese el nombre del empleado que desea buscar: \t");
            string Nombre = "%"+Console.ReadLine()+"%";
            var empleados = connection.Query<Empleado>(query, new { nombre = Nombre }).ToList(); //Obtengo los empleados
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados");
            }
            List<EmpleadoDTO_Get> empleadosDTOs = new List<EmpleadoDTO_Get>(); //Genero la lista de DTOs

            foreach (Empleado item in empleados) //Transfiero los objetos a la lista de DTOs
            {
                var aux = mapper.Map<Empleado, EmpleadoDTO_Get>(item); //Mapeo al DTO [Nota: CREAR EL MAPEO EN 'SetAutomapper()'] 
                empleadosDTOs.Add(aux); //Agrego el DTO al List.
            }
        }

    }
}