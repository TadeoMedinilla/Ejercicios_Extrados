using System;

namespace Ejercicio_2
{
    class tadeoList
    {
        // Atributos 

        int e; // Cantidad de elementos.
        int size;
        int[] matriz;

        // Metodos 
        /* Debo definir los siguientes metodos:
        
        - Ampliador de la matriz 
        - Agregar un elemento al final
        - Agregar un elemento en alguna posicion de la lista
        - Eliminar un elemento
        - Buscar un elemento
        - Obtener un elemento en la posicion indicada 
        [ Opcional ] Ordenar los elementos de menor a mayor.*/


        public tadeoList(int size)
        // Constructor:
        {
            this.size = size;
            matriz = new int[size];
        }

        

        public int[] Push(int a)
        {
            VerificarEspacio(matriz); // Esta bien pasado el argumento del metodo?
            if (e == 0)
            {
                matriz[e] = a;
                e++;
                return matriz;
            }
            else
            {
                matriz[e] = a;
                e++;
                return matriz;
            }
        }

        public int[] Insert(int posicion, int valor)
        {
            VerificarEspacio(matriz);
            int y = 0;
            int z = 0;
            int[] auxiliar = new int [(e-(posicion))];
            for (int x = (posicion); x < e; x++)
            {
                auxiliar[y] = matriz[x];
                y++;
            }
            matriz[(posicion)] = valor;
            e++;
            for(int x = posicion+1; x < e; x++)
            {
                matriz[x] = auxiliar[z];
                z++;
            }
            return matriz;
        }
      
        public void Delete(int valor)
        // Elimina el primer valor igual al pasado por argumento
        {
            int posicion = BuscarPorValor(valor) - 1 ;
            for (int x = posicion; x < e; x++)
            {
                matriz[x] = matriz[x + 1];
            }
            e--;
        }

        public int BuscarPorValor(int valor)
        // Devuelve la posicion del valor buscado
        {
            int x = 0;
            while ((valor != matriz[x]) & (x<e))
            {
                x++;
            }
            return (x+1);
        }
        
        public int BuscarPorPosicion(int posicion)
        // Devuelve el valor en la posicion solicitada
        {
            return matriz[posicion-1];
        }

        // ¡Corregir!
        public int[] Ordenar()
        {
            int posOriginal = 0;
            int posNueva ;
            int ciclos=0;

            while (posOriginal<e)
            {
                
                int c = 0; // contador de posiciones que se movio. 
                for (posNueva = 0 ; posNueva < e; posNueva++)
                {
                    
                    if ((matriz[posOriginal] > matriz[posNueva]) & (c!=0))
                    {
                        // primer corte de la matriz, eliminacion del dato y movimiento hacia atras.
                        int[] aux1 = new int[e - posOriginal];
                        int posAux1 = 0;
                        for (int x = posOriginal+1; x < e; x++)
                        {
                            aux1[posAux1] = matriz[x];
                            posAux1++;
                        }
                        int valor = matriz[posOriginal];
                        int z = 0;
                        for (int i = posOriginal; i < e; i++)
                        {
                            matriz[i] = aux1[z];
                            z++;
                        }
                        // segundo corte de la matriz, movimiento hacer adelante e insercion del dato. 
                        int[] aux2 = new int[e - posNueva];
                        int posAux2 = 0;
                        for (int x= posNueva; x < e; x++)
                        {
                            aux2[posAux2] = matriz[x];
                            posAux2++;
                        }
                        matriz[posNueva] = valor;
                        z = 0;
                        for (int x = posNueva+1; x < e; x++)
                        {
                            matriz[x] = aux2[z];
                            z++;
                        }
                        

                    }
                    c++;

                }
                if (ciclos > 10 * e)
                {
                    break;
                }
                else
                {
                    ciclos++;
                }
            }
            return matriz;
        }
        
        // Metodos auxiliares:
        public void Elementos()
        {
            Console.WriteLine($"Numero de elementos: {e}");
        }

        public void Size()
        {
            Console.WriteLine($"El tamaño de la matriz es: {size}");
        }
        
        public void ImprimirLista()
        {
            int x = 0;
            Console.WriteLine("El formato de impresion es: {posicion : valor}");
            while (x < e)
            //for (int x = 0; x < matriz.Length; x++)
            {
                Console.WriteLine($" {x}:{matriz[x]} ");
                x++;
            }
        }

        private int[] VerificarEspacio(int[] aVerificar)
        //Verifico el espacio y si no hay duplico la matriz.
        {
            if ((e) < size)
            {
                return matriz;
            }
            // Duplico el tamaño de la matriz.
            else
            {
                size *= 2;
                int[] matrizNueva = new int[size];
                for (int x = 0; x < matriz.Length; x++)
                {
                    matrizNueva[x] = matriz[x];
                }
                matriz = matrizNueva;
                return matriz;
            }
        }
    }


}
