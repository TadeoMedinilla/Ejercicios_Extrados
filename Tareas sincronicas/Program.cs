using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tareas_sincronicas
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Genero la lista de 300 posiciones");
            Stopwatch cronometro = new Stopwatch();
            Buscador_Asincrono Prueba = new Buscador_Asincrono(90000);
            /*
            //Prueba.ImprimirList();

            Console.WriteLine("Inicio el cronometro y busco de manera SINCRONICA el maximo:");
            
            //Inicio cronometro 
            cronometro.Start();
            Prueba.BuscarMaximoSincrono();
            
            //Detengo Cronometro
            cronometro.Stop();
            
            //Muestro resultado
            TimeSpan tiempo1 = cronometro.Elapsed;

            Console.WriteLine($"Tiempo que tomo encontrar el maximo de manera SINCRONICA: {tiempo1}");
            

            Console.WriteLine("Genero la lista de 300 posiciones");
            //Buscador_Asincrono Prueba1 = new Buscador_Asincrono(300);
            //Prueba1.ImprimirList();

            Console.WriteLine("Inicio el cronometro y busco de manera ASINCRONICA el maximo:");
            //Reinicio cronometro
            cronometro.Reset();
            cronometro.Start();
            await Prueba.BuscarMaximo();
            //Detengo cronometro
            cronometro.Stop();

            //Muestro resultado 
            TimeSpan tiempo2 = cronometro.Elapsed;

            Console.WriteLine($"Tiempo que tomo encontrar el maximo de manera ASINCRONICA: {tiempo2}");
            double mejora = (tiempo1.TotalMilliseconds / tiempo2.TotalMilliseconds);
            Console.WriteLine($"\nHubo una mejora de {mejora} veces.");
            */
            Stopwatch cron1 = new Stopwatch();
            Stopwatch cron2 = new Stopwatch();
            Stopwatch cron3 = new Stopwatch();

            /*
            cron1.Start();
            await Prueba.BuscarMaximo4();
            cron1.Stop();
            */
            cron2.Start();
            await Prueba.BuscarMaximo();
            cron2.Stop();
            
            cron3.Start();
            Prueba.BuscarMaximoSincrono();
            cron3.Stop();

            double mejora = (cron3.Elapsed.TotalMilliseconds / cron2.Elapsed.TotalMilliseconds);
            double mejora2 = (cron1.Elapsed.TotalMilliseconds / cron2.Elapsed.TotalMilliseconds);

            Console.WriteLine($"Asincrono 4: {cron1.Elapsed.TotalMilliseconds}\n" +
                              $"Asincrono: {cron2.Elapsed.TotalMilliseconds}\n" +
                              $"Sincrono: {cron3.Elapsed.TotalMilliseconds}\n" +
                              $"Mejora: {mejora}\n"+
                              $"Mejora asincrona: {mejora2}");
            Console.ReadLine();
        }
        
    }
}
