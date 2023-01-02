using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Servicios
{
    class Configuracion
    {
        public string DB_Connection { get; set; }
        public Mapeador mapper { get; set; }

        public Configuracion()
        {
            this.DB_Connection = "DataBase = .; Initial Catalog = Empresa; Integrated Security = True; TrustServerCertificate=True;";
            this.mapper = new Mapeador();
        }
    }
    //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
}
