using System;

namespace Ejercicio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*tadeoList prueba1 = new tadeoList(1);
            prueba1.Push(5);
            prueba1.Size();
            prueba1.Push(7);
            prueba1.Size();
            prueba1.Push(8);
            prueba1.Insert(1, 3);
            prueba1.Size();
            prueba1.Insert(0, 15);
            prueba1.Size();
            prueba1.ImprimirLista();
            int posicion = prueba1.BuscarPorValor(5);
            Console.WriteLine($"El valor buscado esta en la posicion {posicion}.");
            Console.WriteLine($"El valor en la posicion solicitada es {prueba1.BuscarPorPosicion(2)}");
            prueba1.Elementos();
            prueba1.Delete(3);
            prueba1.Elementos();
            prueba1.ImprimirLista();
            prueba1.Ordenar();
            prueba1.ImprimirLista();*/

            tadeoList prueba2 = new tadeoList(1);
            prueba2.Push(5);
            prueba2.Push(2);
            prueba2.Push(1);
            prueba2.Push(4);
            prueba2.Push(2);
            prueba2.Push(5);
            prueba2.Push(2);
            prueba2.Push(7);
            prueba2.Push(1);
            prueba2.ImprimirLista();
            prueba2.Ordenar();
            prueba2.ImprimirLista();
            Console.Read();
        }
    }
}
