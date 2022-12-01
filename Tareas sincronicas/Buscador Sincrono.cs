using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tareas_sincronicas
{
    class Buscador_Sincrono
    {
        public List<int> Numeros;

        public Buscador_Sincrono(int size)
        {
            Numeros = new List<int>(size);
            LlenarList(size);
        }

        public virtual void LlenarList(int CantidadEnteros)
        {
            int contador = 0;
            while (contador < CantidadEnteros)
            {
                Random rnd = new Random();
                int agregar = rnd.Next(11);
                Numeros.Add(agregar);
                contador++;
            }
            Random position = new Random();
            int posicion = position.Next(CantidadEnteros);
            Numeros.Insert(posicion, 11 );
        }

        public virtual void ImprimirList()
        {
            Console.WriteLine("");
            foreach (int numero in Numeros)
            {
                Console.Write($" {numero} ");
            }
            Console.WriteLine("\n");
        }

        public virtual int BuscarMaximoSincrono()
        {
            int[] ArrayEnteros = Numeros.ToArray();
            int Mayor = ArrayEnteros[ArrayEnteros.Length-1];
            int posicion = 0;
            int x = 0;
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();
            foreach (int num in ArrayEnteros)
            {
                if (num >= Mayor)
                {
                    Mayor = num;
                    posicion = x;
                }
                x++;
            }
            /*
            for ( x = 0; x < ArrayEnteros.Length; x++)
            {
                if (Mayor <= ArrayEnteros[x])
                {
                    Mayor = ArrayEnteros[x];
                    posicion = x;
                }
            }*/
            cronometro.Stop();

            Console.WriteLine($"La posicion del maximo es: { posicion +1 } y su valor es: {Mayor}");
            Console.WriteLine($"Tiempo busqueda: {cronometro.Elapsed.TotalMilliseconds}\n " +
                              $"Tiempo espera: no hay\n");
            return Mayor;
        }
            
    }
    
    class Buscador_Asincrono : Buscador_Sincrono
    {
        public Buscador_Asincrono(int size): base(size)
        {
            Numeros = new List<int>(size);
            LlenarList(size);
        }

        public async Task<int> BuscarMaximo()
        {
            int[] ArrayEnteros = Numeros.ToArray();
            int Mayor;
            int posicion=0;
            int Mayor1;
            int posicion1=0;
            Task<int> t1 = Task.Run(() =>
            {
                int mayor=0;
                int x = 0;
                foreach (int num in ArrayEnteros)
                {
                    if (num > mayor)
                    {
                        mayor = num;
                        posicion1 = x;
                    }
                    x++;
                }
                /*
                for (int x = 0; x < mitad; x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion1 = x;
                    }
                }*/

                return (mayor);
            });
            
            
            int Mayor2;
            int posicion2 = 0;
            Task<int> t2 = Task.Run(() => 
            {
                int mayor = 0;
                int x = 0;
                foreach (int num in ArrayEnteros)
                {
                    if (num > mayor)
                    {
                        mayor = num;
                        posicion2 = x;
                    }
                    x++;
                }
                /*
                for (int x = mitad; x < ArrayEnteros.Length; x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion2 = x;
                    }
                }*/

                return mayor;
            });
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();
            Mayor1 = await t1;
            Mayor2 = await t2;
            cronometro.Stop();

            Stopwatch cronometro1 = new Stopwatch();
            cronometro1.Start();
            await Task.WhenAll(t1, t2);
            cronometro1.Stop();

            if (Mayor1 > Mayor2)
            {
                Mayor = Mayor1;
                posicion += posicion1;
            }
            else
            {
                Mayor = Mayor2;
                posicion += posicion2;
            }
            Console.WriteLine($"ASINCRONO: \nEl maximo es: {Mayor} y su posicion es: {posicion + 1}\n");
            Console.WriteLine($"Tiempo busqueda: {cronometro.Elapsed.TotalMilliseconds}\n " +
                              $"Tiempo espera: {cronometro1.Elapsed.TotalMilliseconds}\n");
            return Mayor;
        }
        
        
        //DESCARTAR
        public async Task<int> BuscarMaximo4()
        {
            int[] ArrayEnteros = Numeros.ToArray();
            int Mayor = 0;
            int posicion = 0;
            int cuarto = ArrayEnteros.Length / 4;
            int mitad = ArrayEnteros.Length / 2;
            int trescuartos = (3* ArrayEnteros.Length )/ 4;

            int Mayor1;
            int posicion1 = 0;
            Task<int> t1 = Task.Run(() =>
            {
                int mayor = 0;
                for (int x = 0; x < (cuarto); x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion1 = x;
                    }
                }

                return (mayor);
            });


            int Mayor2;
            int posicion2 = 0;
            Task<int> t2 = Task.Run(() =>
            {
                int mayor = 0;

                for (int x = cuarto; x < mitad; x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion2 = x;
                    }
                }

                return mayor;
            });

            int Mayor3;
            int posicion3 = 0;
            Task<int> t3 = Task.Run(() =>
            {
                int mayor=0;

                for (int x = mitad / 4; x < trescuartos; x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion3 = x;
                    }
                }

                return mayor;
            });
            int Mayor4;
            int posicion4 = 0;
            Task<int> t4 = Task.Run(() =>
            {
                int mayor = 0;

                for (int x = trescuartos; x < ArrayEnteros.Length; x++)
                {
                    if (mayor <= ArrayEnteros[x])
                    {
                        mayor = ArrayEnteros[x];
                        posicion4 = x;
                    }
                }

                return mayor;
            });
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();
            Mayor1 = await t1;
            Mayor2 = await t2;
            Mayor3 = await t3;
            Mayor4 = await t4;
            cronometro.Stop();

            Stopwatch cronometro1 = new Stopwatch();
            cronometro1.Start();
            await Task.WhenAll(t1, t2, t3, t4);
            cronometro1.Stop();

            if ((Mayor1 > Mayor2) & (Mayor1 > Mayor3) & (Mayor1 > Mayor4))
            {
                Mayor = Mayor1;
                posicion += posicion1;
            }
            if ((Mayor2 > Mayor1) & (Mayor2 > Mayor3) & (Mayor2 > Mayor4))
            {
                Mayor = Mayor2;
                posicion += posicion2;
            }
            if ((Mayor3 > Mayor2) & (Mayor3 > Mayor1) & (Mayor3 > Mayor4))
            {
                Mayor = Mayor3;
                posicion += posicion3;
            }
            else
            {
                Mayor = Mayor4;
                posicion += posicion4;
            }
            Console.WriteLine($"ASINCRONO 4:\nEl maximo es: {Mayor} y su posicion es: {posicion + 1}\n");
            Console.WriteLine($"Tiempo busqueda: {cronometro.Elapsed.TotalMilliseconds}\n " +
                              $"Tiempo espera: {cronometro1.Elapsed.TotalMilliseconds}\n");
            return Mayor;
        }
    }








   
}
