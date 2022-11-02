using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_2
{
    class ObjList 
    {
        // Atributos 

        int e; // Cantidad de elementos.
        int size;
        Empleado[] matriz;

        // Metodos 
        /* Debo definir los siguientes metodos:

        - Ampliador de la matriz 
        - Agregar un elemento al final
        - Agregar un elemento en alguna posicion de la lista
        - Eliminar un elemento
        - Buscar un elemento
        - Obtener un elemento en la posicion indicada 
        [ Opcional ] Ordenar los elementos de menor a mayor.*/


        public ObjList(int size)
        // Constructor:
        {
            this.size = size;
            matriz = new Empleado [size];
        }

        public Empleado[] Push(Empleado a)
        {
            VerificarEspacio(matriz); // Esta bien pasado el argumento del metodo?
                                        
            matriz[e] = a;
            e++;
            return matriz;            
        }

        public Empleado[] Insert(int posicion, Empleado valor)
        {
            VerificarEspacio(matriz);
            int y = 0;
            int z = 0;
            Empleado[] auxiliar = new Empleado[(e - (posicion))];
            for (int x = (posicion); x < e; x++)
            {
                auxiliar[y] = matriz[x];
                y++;
            }
            matriz[(posicion)] = valor;
            e++;
            for (int x = posicion + 1; x < e; x++)
            {
                matriz[x] = auxiliar[z];
                z++;
            }
            return matriz;
        }

        public void Delete(int ID)
            // Elimina el primer valor igual al pasado por argumento
        {
            int posicion = GetPosicion(ID) - 1;
            for (int x = posicion; x < e; x++)
            {
                matriz[x] = matriz[x + 1];
            }
            e--;
        }

        // Funcion especial [ No elimino datos del array sino que cambio su status y solo imprimo los obj con status = 0 ]
        public void CambiarStatus(int ID)
        {
            /*int posicion = BuscarPorID(ID);
            matriz[posicion].status = 1;*/
            BuscarPorID(ID).status = 1;
        }
        public void BuscarPorNombre(string valor)
            
        {
            int x = 0;
            while (x < e)
            {
                if (matriz[x].GetFullName() == valor & matriz[x].ID!=0)
                {
                    break;
                }
                x++;
            }
            matriz[x].InformacionEmpleado();
        }
        public Empleado BuscarPorID(int ID)
            // Devuelve el valor en la posicion solicitada
        {
            int x = 0;
            while ((ID != matriz[x].ID) & (x < e))
            {
                x++;
            }
            return matriz[x];
        }

        public int GetPosicion(int ID)
        {
            int x = 0;
            while ((x < e))
            {
                if ((ID != matriz[x].ID))
                {
                    x++;
                }
                else
                {
                    break;
                }
            }
            return x+1;
        }
        
        public Empleado GetObjeto(int ID)
        {
            int x = GetPosicion(ID);
            return matriz[x-1];
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
            //Imprime toda la lista
        {
            int x = 0;
            while (x < e & matriz[x].ID != 0)
            {
                matriz[x].MostrarEmpleado();
                x++;
            }
        }
        public void ImprimirActivos()
        {
            int x = 0;
            while (x < e)
            {
                if (matriz[x].status == 0) { matriz[x].MostrarEmpleado(); }
                x++;
            }
        }
        public void ImprimirInactivos()
        {
            int x = 0;
            while (x < e)
            {
                if (matriz[x].status != 0 & matriz[x].ID !=0) { matriz[x].MostrarEmpleado(); }
                x++;
            }

        }

        private Empleado[] VerificarEspacio(Empleado[] aVerificar)
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
                Empleado[] matrizNueva = new Empleado[size];
                for (int x = 0; x < matriz.Length; x++)
                {
                    matrizNueva[x] = matriz[x];
                }
                matriz = matrizNueva;
                return matriz;
            }
        }

        /* ¡Corregir!
        public int[] Ordenar()
        {
            int posOriginal = 0;
            int posNueva;
            int ciclos = 0;

            while (posOriginal < e)
            {

                int c = 0; // contador de posiciones que se movio. 
                for (posNueva = 0; posNueva < e; posNueva++)
                {

                    if ((matriz[posOriginal] >= matriz[posNueva]))
                    {
                        // primer corte de la matriz, eliminacion del dato y movimiento hacia atras.
                        int[] aux1 = new int[e - posOriginal];
                        int posAux1 = 0;
                        for (int x = posOriginal + 1; x < e; x++)
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
                        for (int x = posNueva; x < e; x++)
                        {
                            aux2[posAux2] = matriz[x];
                            posAux2++;
                        }
                        matriz[posNueva] = valor;
                        z = 0;
                        for (int x = posNueva + 1; x < e; x++)
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
        }*/

    }
}
