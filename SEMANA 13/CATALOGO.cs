using System;

class CatalogoRevistas
{
    static void Main(string[] args)
    {
        string[] catalogo = new string[10];

        Console.WriteLine("Ingrese 10 títulos al catálogo de revistas:");
        for (int i = 0; i < catalogo.Length; i++)
        {
            Console.Write($"Título {i + 1}: ");
            catalogo[i] = Console.ReadLine();
        }

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Buscar título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloBuscar = Console.ReadLine();
                    bool encontrado = BusquedaIterativa(catalogo, tituloBuscar);

                    if (encontrado)
                        Console.WriteLine($"'{tituloBuscar}' encontrado en el catálogo.");
                    else
                        Console.WriteLine($"'{tituloBuscar}' no encontrado en el catálogo.");
                    break;

                case "2":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }

    static bool BusquedaIterativa(string[] catalogo, string titulo)
    {
        foreach (string item in catalogo)
        {
            if (item.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}
