using System;
using System.Collections.Generic;
using System.Text;

namespace La_Tienda
{
    class Factura
    {   
        //Datos de la tienda:
        public string Nombre { get; } = "La Tiendita";
        private string Cuit { get; } = "00 - 00000000 - 00";
        private string Condicion_IVA { get; } = "Responsable Inscripto";

        ///Nombre:
        ///Cuit
        ///Condicion frente al IVA
        
        public string Nombre_Cliente { get; set; }
        public int Cuit_Cliente { get; set; }
        public int Condicion_IVA_Cliente { get; set; }


    }
}
