using Dapper;
using Empresa.DTOs;
using Empresa.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Servicios
{
    
    class EmpleadoCRUD : IPersonalCRUD
        //LISTO
    {
        public Configuracion config { get; set; }
        public EmpleadoCRUD()
        {

        }
        public EmpleadoCRUD(Configuracion config)
        {
            this.config = config;
        }
        private Empleado emp { get; set; }
        private EmpleadoDTOs empDTO { get; set; }
        public async Task Delete(int ID_Personal)
            //Listo
        {
            var query = "UPDATE personal SET Status = 1 WHERE ID_Personal = @ID_Personal";
            using (var connection = new SqlConnection(config.DB_Connection))
            {
                await connection.ExecuteAsync(query, new {  ID_Personal = ID_Personal });
            }
        }

        public virtual async Task<object> Get(int ID_Personal)
            //Listo
        {
            var query = "SELECT * FROM Personal WHERE ID_personal = @ID_Personal AND Puesto = 1";
            
            using (var connection = new SqlConnection(config.DB_Connection))
            {
                emp = await connection.QuerySingleOrDefaultAsync<Empleado>(query, new { ID_Personal });
                
                if (emp == null) 
                {
                    Console.WriteLine($"No hay empleados registrados con ese id [{ID_Personal}]");

                }
                else
                {
                    empDTO = config.mapper.mapper.Map<Empleado, EmpleadoDTOs>(emp);
                }
            }
            return empDTO;
        }

        public virtual async Task Insert()
            //Listo.
        {
            var query = "INSERT INTO Personal (Nombre, Apellido,Email,Puesto,ID_Jefe) VALUES (@Nombre,@Apellido,@Email,@Puesto,@ID_Jefe)";
            empDTO = SolicitarParametros();
            
            using(var connection = new SqlConnection(config.DB_Connection)) 
            {
                await connection.ExecuteAsync(query, new {
                                                Nombre = empDTO.Nombre,
                                                Apellido = empDTO.Apellido,
                                                Email = empDTO.Email,
                                                Puesto = empDTO.Puesto,
                                                ID_Jefe = empDTO.ID_Jefe
                                               });

            } 
        }

        public virtual async Task Update(int ID_Personal, int Puesto)
            //Listo.
        {
            string query; // "UPDATE personal SET Puesto = @Puesto,  WHERE ID_Personal = @ID_Personal";
            if (Puesto == 2)
            {
                query = "UPDATE personal SET Puesto = @Puesto, Empleados_Supervisados = @Empleados_Supervisados  WHERE ID_Personal = @ID_Personal";
                Console.Write("Ingrese la cantidad de empleados que tendra a cargo:\t");
                string aux = Console.ReadLine();
                int Empleados_Supervisados = ParametroInt(aux);
                
                using (var connection = new SqlConnection(config.DB_Connection))
                {
                    await connection.ExecuteAsync(query, new { Puesto = Puesto, Empleados_Supervisados = Empleados_Supervisados, ID_Personal = ID_Personal });
                }
            }
            else if (Puesto == 3)
            {
                query = "UPDATE personal SET Puesto = @Puesto, Sucursales_Supervisadas = @Sucursales_Supervisadas  WHERE ID_Personal = @ID_Personal";
                Console.Write("Ingrese la cantidad de sucursales que tendra a cargo:\t");
                string aux = Console.ReadLine();
                int Sucursales_Supervisadas = ParametroInt(aux);

                using (var connection = new SqlConnection(config.DB_Connection))
                {
                    await connection.ExecuteAsync(query, new { Puesto = Puesto, Sucursales_Supervisadas = Sucursales_Supervisadas, ID_Personal = ID_Personal });
                }
            }
            else
            {
                throw new Exception("El puesto debe ser un numero entre 1 y 3.");
            }
        }

        private EmpleadoDTOs SolicitarParametros()
        {
            empDTO = new EmpleadoDTOs();
            Console.Write("Ingrese el nombre del empleado:\t");
            empDTO.Nombre= ParametroString();
            Console.Write("Ingrese el apellido del empleado:\t");
            empDTO.Apellido = ParametroString();
            Console.Write("Ingrese el email del empleado:\t");
            empDTO.Email = Console.ReadLine();
            if (String.IsNullOrEmpty(empDTO.Email)) empDTO.Email = "No especifica";
            
            Console.Write("Ingrese el ID del jefe:\t");
            string aux = Console.ReadLine();
            if (String.IsNullOrEmpty(aux))
            {
                empDTO.ID_Jefe = null;
            }
            else
            {
                empDTO.ID_Jefe = ParametroInt(aux);
            }
            
            return empDTO;
        }

        protected string ParametroString()
        {
            string parametro = Console.ReadLine();
            while (parametro == null)
            {
                Console.WriteLine("El campo no debe estar vacio.");
            }
            return parametro;
        }

        protected int ParametroInt(string aux)
        {
            int parametro;
            try
            {
                parametro = Convert.ToInt32(aux);
            }
            catch (Exception)
            {
                throw new Exception("El dato ingresado debe ser numerico.") ;
            }
            return parametro;
        }
    }

    class SupervisorCRUD : EmpleadoCRUD, IPersonalCRUD
        //LISTO
    {
        private Supervisor supervisor { get; set; }
        private SupervisorDTOs supervisorDTO { get; set; }

        public SupervisorCRUD(Configuracion config) : base(config)
        {
            this.config = config;
        }

        public override async Task Update(int ID_Personal, int Puesto)
            //Listo
        {
            string query; // "UPDATE personal SET Puesto = @Puesto,  WHERE ID_Personal = @ID_Personal";
            if (Puesto == 1)
            {
                Console.WriteLine("Si esta seguro que desea descender a este supervisor ingrese 1.");
                string aux = Console.ReadLine();
                int decision = ParametroInt(aux);
                if (decision == 1)
                {
                    query = "UPDATE personal SET Puesto = @Puesto, Empleados_Supervisados = 0 WHERE ID_Personal = @ID_Personal";

                    using (var connection = new SqlConnection(config.DB_Connection))
                    {
                        await connection.ExecuteAsync(query, new { Puesto = Puesto,  ID_Personal = ID_Personal });
                    }
                }
                else
                {
                    throw new Exception("¡Desarrollar!");
                }
            }
            if (Puesto == 3)
            {
                query = "UPDATE personal SET Puesto = @Puesto, Empleados_Supervisados = 0,Sucursales_Supervisadas = @Sucursales_Supervisadas  WHERE ID_Personal = @ID_Personal";
                Console.Write("Ingrese la cantidad de sucursales que tendra a cargo:\t");
                string aux = Console.ReadLine();
                int Sucursales_Supervisadas = ParametroInt(aux);

                using (var connection = new SqlConnection(config.DB_Connection))
                {
                    await connection.ExecuteAsync(query, new { Puesto = Puesto, Sucursales_Supervisadas = Sucursales_Supervisadas, ID_Personal = ID_Personal });
                }
            }
        }
        public override async Task Insert()
            //Listo
        {
            var query = @"INSERT INTO Personal (Nombre, Apellido,Email,Puesto,ID_Jefe, Empleados_Supervisados) 
                                        VALUES (@Nombre,@Apellido,@Email,@Puesto,@ID_Jefe, @Empleados_Supervisados)";
            supervisorDTO = SolicitarParametros();

            using (var connection = new SqlConnection(config.DB_Connection))
            {
                await connection.ExecuteAsync(query, new
                {
                    Nombre = supervisorDTO.Nombre,
                    Apellido = supervisorDTO.Apellido,
                    Email = supervisorDTO.Email,
                    Puesto = supervisorDTO.Puesto,
                    ID_Jefe = supervisorDTO.ID_Jefe,
                    Empleados_Supervisados = supervisorDTO.Empleados_Supervisados
                });

            }
        }
            
        public override async Task<object> Get(int ID_Personal)
            //Listo
        {
            var query = "SELECT * FROM Personal WHERE ID_personal = @ID_Personal AND Puesto = 2";

            using (var connection = new SqlConnection(config.DB_Connection))
            {
                supervisor = await connection.QuerySingleOrDefaultAsync<Supervisor>(query, new { ID_Personal });

                if (supervisor == null)
                {
                    Console.WriteLine($"No hay supervisores registrados con ese id [{ID_Personal}]");

                }
                else
                {
                    supervisorDTO = config.mapper.mapper.Map<Supervisor, SupervisorDTOs>(supervisor);
                }
            }
            return supervisorDTO;
        }
        private SupervisorDTOs SolicitarParametros()
        {
            supervisorDTO = new SupervisorDTOs();
            Console.Write("Ingrese el nombre del empleado:\t");
            supervisorDTO.Nombre = ParametroString();
            Console.Write("Ingrese el apellido del empleado:\t");
            supervisorDTO.Apellido = ParametroString();
            Console.Write("Ingrese el email del empleado:\t");
            supervisorDTO.Email = Console.ReadLine();
            if (String.IsNullOrEmpty(supervisorDTO.Email)) supervisorDTO.Email = "No especifica";

            Console.Write("Ingrese el ID del jefe:\t");
            string aux = Console.ReadLine();
            if (String.IsNullOrEmpty(aux))
            {
                supervisorDTO.ID_Jefe = null;
            }
            else
            {
                supervisorDTO.ID_Jefe = ParametroInt(aux);
            }
            Console.Write("Ingrese el numero de empleados supervisados:\t");
            string aux2 = Console.ReadLine();
            if (String.IsNullOrEmpty(aux2))
            {
                supervisorDTO.Empleados_Supervisados = null;
            }
            else
            {
                supervisorDTO.Empleados_Supervisados = ParametroInt(aux2);
            }

            return supervisorDTO;
        }

    }

    class EncargadoCRUD : EmpleadoCRUD, IPersonalCRUD
        //LISTO
    {
        private Encargado encargado { get; set; }
        private EncargadoDTOs encargadoDTO { get; set; }
        public EncargadoCRUD(Configuracion config) : base (config)
        {
            this.config = config;
        }

        public override async Task Update(int ID_Personal, int Puesto)
            //Listo
        {
            string query; // "UPDATE personal SET Puesto = @Puesto,  WHERE ID_Personal = @ID_Personal";
            if (Puesto == 1)
            {
                Console.WriteLine("Si esta seguro que desea descender a este supervisor ingrese 1.");
                string aux = Console.ReadLine();
                int decision = ParametroInt(aux);
                if (decision == 1)
                {
                    query = "UPDATE personal SET Puesto = @Puesto, Empleados_Supervisados = 0, Sucursales_Supervisadas = 0 WHERE ID_Personal = @ID_Personal";

                    using (var connection = new SqlConnection(config.DB_Connection))
                    {
                        await connection.ExecuteAsync(query, new { Puesto = Puesto, ID_Personal = ID_Personal });
                    }
                }
            }
            else if (Puesto == 2)
            {
                Console.WriteLine("Si esta seguro que desea descender a este encargado ingrese 1.");
                string aux2 = Console.ReadLine();
                int decision1 = ParametroInt(aux2);
                if (decision1 == 1)
                {
                    query = "UPDATE personal SET Puesto = @Puesto, Empleados_Supervisados = @Empleados_Supervisados, Sucursales_Supervisadas = 0  WHERE ID_Personal = @ID_Personal";
                    Console.Write("Ingrese la cantidad de empleados que tendra a cargo:\t");
                    string aux1 = Console.ReadLine();
                    int Empleados_Supervisados = ParametroInt(aux1);

                    using (var connection = new SqlConnection(config.DB_Connection))
                    {
                        await connection.ExecuteAsync(query, new { Puesto = Puesto, Empleados_Supervisados = Empleados_Supervisados, ID_Personal = ID_Personal });
                    }
                }
            }
            else
            {
                throw new Exception("¡Desarrollar!");
            }
            
        }
        public override async Task Insert()
            //Listo
        {
            var query = @"INSERT INTO Personal (Nombre, Apellido,Email,Puesto,ID_Jefe, Empleados_Supervisados) 
                                        VALUES (@Nombre,@Apellido,@Email,@Puesto,@ID_Jefe, @Sucursales_Supervisadas)";
            encargadoDTO = SolicitarParametros();

            using (var connection = new SqlConnection(config.DB_Connection))
            {
                await connection.ExecuteAsync(query, new
                {
                    Nombre = encargadoDTO.Nombre,
                    Apellido = encargadoDTO.Apellido,
                    Email = encargadoDTO.Email,
                    Puesto = encargadoDTO.Puesto,
                    ID_Jefe = encargadoDTO.ID_Jefe,
                    Sucursales_Supervisadas = encargadoDTO.Sucursales_Supervisadas
                });

            }
        }

        public override async Task<object> Get(int ID_Personal)
            //Listo
        {
            var query = "SELECT * FROM Personal WHERE ID_personal = @ID_Personal AND Puesto = 3";

            using (var connection = new SqlConnection(config.DB_Connection))
            {
                encargado = await connection.QuerySingleOrDefaultAsync<Encargado>(query, new { ID_Personal });

                if (encargado == null)
                {
                    Console.WriteLine($"No hay supervisores registrados con ese id [{ID_Personal}]");

                }
                else
                {
                    encargadoDTO = config.mapper.mapper.Map<Encargado, EncargadoDTOs>(encargado);
                }
            }
            return encargadoDTO;
        }
        private EncargadoDTOs SolicitarParametros()
        {
            encargadoDTO = new EncargadoDTOs();
            Console.Write("Ingrese el nombre del empleado: \t");
            encargadoDTO.Nombre = ParametroString();
            Console.Write("Ingrese el apellido del empleado:\t");
            encargadoDTO.Apellido = ParametroString();
            Console.Write("Ingrese el email del empleado:\t");
            encargadoDTO.Email = Console.ReadLine();
            if (String.IsNullOrEmpty(encargadoDTO.Email)) encargadoDTO.Email = "No especifica";

            Console.Write("Ingrese el ID del jefe:\t");
            string aux = Console.ReadLine();
            if (String.IsNullOrEmpty(aux))
            {
                encargadoDTO.ID_Jefe = null;
            }
            else
            {
                encargadoDTO.ID_Jefe = ParametroInt(aux);
            }
            Console.Write("Ingrese el numero de sucursales supervisadas:\t");
            string aux2 = Console.ReadLine();
            if (String.IsNullOrEmpty(aux2))
            {
                encargadoDTO.Sucursales_Supervisadas = null;
            }
            else
            {
                encargadoDTO.Sucursales_Supervisadas = ParametroInt(aux2);
            }

            return encargadoDTO;
        }


    }
}
