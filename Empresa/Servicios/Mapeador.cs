using AutoMapper;
using Empresa.DTOs;
using Empresa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Servicios
{
    internal class Mapeador
    {
        public IMapper mapper { get; set; }

        public Mapeador()
        {
            mapper = SetConfiguration();
        }

        private IMapper SetConfiguration()
        {
            var configuration = new MapperConfiguration(configuration =>
            {
                //configuration.CreateMap<Personal, EmpleadoCRUD>();
                configuration.CreateMap<Empleado, EmpleadoDTOs>();

                //configuration.CreateMap<Personal, SupervisorCRUD>();
                configuration.CreateMap<Supervisor, SupervisorDTOs>();

                //configuration.CreateMap<Personal, EncargadoCRUD>();
                configuration.CreateMap<Encargado, EncargadoDTOs>();

                configuration.CreateMap<Personal, PersonalDTOs>();

            });
            return configuration.CreateMapper();
        }

        
    }
}
