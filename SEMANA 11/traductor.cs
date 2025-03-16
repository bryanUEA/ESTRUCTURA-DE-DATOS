using System;
using System.Collections.Generic;

class Traductor
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine().ToLower(); // Convertir todo a minúsculas
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].Trim(',', '.', ';', ':', '!', '?'); // Eliminar signos de puntuación
            if (diccionario.ContainsKey(palabraLimpia))
            {
                palabras[i] = diccionario[palabraLimpia];
            }
        }

        Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIngles = Console.ReadLine().ToLower();

        if (diccionario.ContainsKey(palabraIngles))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
            return;
        }

        Console.Write("Ingrese su traducción en español: ");
        string palabraEspanol = Console.ReadLine().ToLower();
        diccionario.Add(palabraIngles, palabraEspanol);
        Console.WriteLine("Palabra agregada correctamente.");
    }
}
