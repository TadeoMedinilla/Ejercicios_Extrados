using Empresa.DTOs;
using Empresa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Servicios
{
    interface IPersonalCRUD
    {
        //Create | Read | Update | Delete
        public Task Insert(); //Create
        public Task<object> Get(int ID_Personal); //Read
        public Task Update(int ID_Personal, int Puesto); //Update
        public Task Delete(int ID_Personal); //Delete
        
    }
}
