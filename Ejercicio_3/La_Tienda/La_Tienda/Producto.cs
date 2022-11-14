using System;
using System.Collections.Generic;
using System.Text;

namespace La_Tienda
{
    class Identificador
    {
        int ID;
        List <int> IDs = new List <int> ();

        public Identificador()
        {
            int controlador = VerificarID(this.ID);
            if (controlador==0)
            {
                ID++;
            }
            IDs.Add(ID);
        }
        private int VerificarID(int a)
        {
            int controlador = 0;
            foreach (int id in IDs)
            {
                if (id == a + 1)
                {
                    controlador++;
                }
            }
            return controlador;
        }
    }
    class Producto
    {
        public string Nombre { get; set; }
        public Guid ID { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        //public int Ganancia { get; set; }
        public int Precio_Venta { get { return Precio_Venta;  } set { this.Precio_Venta = this.Costo * this.Ganancia; } }
        public int Stock { get; set; }


        public Producto(string nombre,string descripcion, int costo, int stock)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Stock = stock;
            this.ID = new Guid();
        }
       
        public void DetalleProducto()
        {
            Console.WriteLine($"Nombre: {this.Nombre}\t ID: {this.ID}\n" +
                              $"Descripcion: {this.Descripcion}\n" +
                              $"Precio: {this.Precio_Venta}\t Stock: {this.Stock} ");
        }

        public int SetPrecioVenta(Tienda a)
        {
            this.Precio_Venta = this.Costo * a.Ganancia;
            return Precio_Venta;
        }

    }
}
