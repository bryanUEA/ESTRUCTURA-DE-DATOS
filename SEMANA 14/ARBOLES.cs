using System;

class Nodo
{
    public int dato;
    public Nodo izq;
    public Nodo der;

    public Nodo(int valor)
    {
        dato = valor;
        izq = der = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Insertar(int dato)
    {
        raiz = InsertarRec(raiz, dato);
    }

    Nodo InsertarRec(Nodo raiz, int dato)
    {
        if (raiz == null)
        {
            raiz = new Nodo(dato);
            return raiz;
        }
        if (dato < raiz.dato)
            raiz.izq = InsertarRec(raiz.izq, dato);
        else if (dato > raiz.dato)
            raiz.der = InsertarRec(raiz.der, dato);

        return raiz;
    }

    public bool Buscar(int dato)
    {
        return BuscarRec(raiz, dato);
    }

    bool BuscarRec(Nodo raiz, int dato)
    {
        if (raiz == null)
            return false;

        if (raiz.dato == dato)
            return true;

        if (dato < raiz.dato)
            return BuscarRec(raiz.izq, dato);
        else
            return BuscarRec(raiz.der, dato);
    }

    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.dato + " ");
            PreOrden(nodo.izq);
            PreOrden(nodo.der);
        }
    }

    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.izq);
            Console.Write(nodo.dato + " ");
            InOrden(nodo.der);
        }
    }

    public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.izq);
            PostOrden(nodo.der);
            Console.Write(nodo.dato + " ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, dato;

        do
        {
            Console.WriteLine("\n--- Árbol Binario ---");
            Console.WriteLine("1. Insertar dato");
            Console.WriteLine("2. Buscar dato");
            Console.WriteLine("3. Mostrar PreOrden");
            Console.WriteLine("4. Mostrar InOrden");
            Console.WriteLine("5. Mostrar PostOrden");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el dato a insertar: ");
                    dato = Convert.ToInt32(Console.ReadLine());
                    arbol.Insertar(dato);
                    Console.WriteLine("Dato insertado.");
                    break;

                case 2:
                    Console.Write("Ingrese el dato a buscar: ");
                    dato = Convert.ToInt32(Console.ReadLine());
                    bool encontrado = arbol.Buscar(dato);
                    Console.WriteLine(encontrado ? "Dato encontrado." : "Dato NO encontrado.");
                    break;

                case 3:
                    Console.Write("PreOrden: ");
                    arbol.PreOrden(arbol.raiz);
                    Console.WriteLine();
                    break;

                case 4:
                    Console.Write("InOrden: ");
                    arbol.InOrden(arbol.raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.Write("PostOrden: ");
                    arbol.PostOrden(arbol.raiz);
                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 6);
    }
}
