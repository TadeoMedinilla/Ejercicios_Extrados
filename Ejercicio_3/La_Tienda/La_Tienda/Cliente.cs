using System;
using System.Collections.Generic;
using System.Text;

namespace La_Tienda
{
    class Cliente
    {
        public string Nombre { get; set; }
        public int Cuil { get; set; }
        public int Deuda { get; set; }
        public int Status { get; set; }
        public int ID { get; set; } 

        public Cliente(string nombre, int cuil)
        {
            this.Nombre = nombre;  
            this.Cuil = cuil;
            Status = 0;
            Deuda= 0;
        }

        public SetDeuda(int deuda)
        {
            Deuda = deuda;
        }

        public void DetalleCliente()
        {
            Console
        }
        puto 
    }

    class Cli_List
    {
          
        List<Cliente> clientes;
        public Cli_List(int size)
        {
            this.size = size;
            List<Cliente> clientes = new List<Cliente>(size);
        }

        public void InsertarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        private void GetPosicion(Cliente cliente)
        {
            int p = this.clientes.IndexOf(cliente);
            return p;
        }
        public void ImprimirLista()
        {
            Console.WriteLine($"")
        }
    }
}
