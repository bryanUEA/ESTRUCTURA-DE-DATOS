using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    class Program
    {
        static HashSet<string> jugadores = new HashSet<string>();
        static Dictionary<string, HashSet<string>> equipos = new Dictionary<string, HashSet<string>>();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==== TORNEO DE FUTBOL ====");
                Console.WriteLine("1. Registrar Jugador");
                Console.WriteLine("2. Registrar Equipo");
                Console.WriteLine("3. Ver Equipos y Jugadores");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarJugador();
                        break;
                    case 2:
                        RegistrarEquipo();
                        break;
                    case 3:
                        MostrarEquipos();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 4);
        }

        static void RegistrarJugador()
        {
            Console.Write("Ingrese nombre del jugador: ");
            string jugador = Console.ReadLine();

            if (jugadores.Add(jugador))
                Console.WriteLine($"Jugador '{jugador}' registrado exitosamente.");
            else
                Console.WriteLine($"El jugador '{jugador}' ya existe.");
        }

        static void RegistrarEquipo()
        {
            Console.Write("Ingrese nombre del equipo: ");
            string equipo = Console.ReadLine();

            if (!equipos.ContainsKey(equipo))
            {
                equipos[equipo] = new HashSet<string>();
                Console.WriteLine($"Equipo '{equipo}' creado.");
            }
            else
            {
                Console.WriteLine($"El equipo '{equipo}' ya existe.");
            }

            Console.Write("¿Cuántos jugadores desea agregar? ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.Write($"Nombre del jugador #{i + 1}: ");
                string jugador = Console.ReadLine();

                if (jugadores.Contains(jugador))
                {
                    if (equipos[equipo].Add(jugador))
                        Console.WriteLine($"Jugador '{jugador}' añadido al equipo '{equipo}'.");
                    else
                        Console.WriteLine($"El jugador '{jugador}' ya está en el equipo '{equipo}'.");
                }
                else
                {
                    Console.WriteLine($"Jugador '{jugador}' no registrado previamente.");
                }
            }
        }

        static void MostrarEquipos()
        {
            Console.WriteLine("\n--- Equipos y sus Jugadores ---");
            foreach (var equipo in equipos)
            {
                Console.WriteLine($"Equipo: {equipo.Key}");
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine($"  - {jugador}");
                }
            }
        }
    }
}
