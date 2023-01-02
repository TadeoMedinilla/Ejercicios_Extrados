using AutoMapper;
using Dapper;
using Empresa.DTOs;
using Empresa.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Servicios
{
    internal class Consultas
    {
        public Configuracion config{ get; set; }
        private Personal personal { get; set; }
        private List<Personal> personalList { get; set; }
        private PersonalDTOs personalDTO { get; set; }
        private List<PersonalDTOs> personalDTOsList { get; set; }

        public Consultas(Configuracion config)
        {
            this.config = config;
        }

        public async List<PersonalDTOs> ListarPersonal()
            //Listo
        {
            var query = "SELECT ID_Personal, Nombre, Apellido, Puesto FROM Personal WHERE Status = 0";
            
            using (var connection = new SqlConnection(config.DB_Connection))
            {
                var personalListTask =await  connection.QueryAsync<Personal>(query);//Buscar la forma de hacerlo asincrono.
                personalList = personalListTask.ToList();
                if (personalList.Count == 0) Console.WriteLine("No hay empleados registrados.");
                else
                {
                    personalDTOsList = new List<PersonalDTOs>();

                    foreach (Personal item in personalList)
                    {
                        personalDTO = config.mapper.mapper.Map<Personal, PersonalDTOs>(item);
                        personalDTOsList.Add(personalDTO);
                    }
                }
            }
            return personalDTOsList;
        }

        public async Task AscenderEmpleado(int ID_Personal, int NuevoPuesto)
            //Listo
        {
            var query = "SELECT Puesto FROM Personal WHERE ID_Personal = @ID_Personal AND Status = 0";
            using(var connection = new SqlConnection(config.DB_Connection))
            {
                personal =await connection.QuerySingleOrDefaultAsync<Personal>(query, new { ID_Personal = ID_Personal});

                if (personal == null) Console.WriteLine($"No hay empleados registrados con el ID ingresado [{ID_Personal}]");
                else
                {
                    if (personal.Puesto == 1)
                    {
                        EmpleadoCRUD emp = new EmpleadoCRUD(this.config);
                        await emp.Update(ID_Personal,NuevoPuesto);
                    }
                    else if (personal.Puesto == 2)
                    {
                        SupervisorCRUD sup = new SupervisorCRUD(this.config);
                        await sup.Update(ID_Personal, NuevoPuesto);
                    }
                    else
                    {
                        EncargadoCRUD enc = new EncargadoCRUD(this.config);
                        await enc.Update(ID_Personal, NuevoPuesto);
                    }
                }
            }
        }

    }
}
