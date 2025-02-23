using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Conjunto total de ciudadanos (ficticio)
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano" + i);
        }

        // Conjunto de ciudadanos vacunados con Pfizer (ficticio)
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add("Ciudadano" + i);
        }

        // Conjunto de ciudadanos vacunados con AstraZeneca (ficticio)
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        for (int i = 76; i <= 150; i++)
        {
            vacunadosAstrazeneca.Add("Ciudadano" + i);
        }

        // Conjunto de ciudadanos vacunados con ambas dosis (intersección de conjuntos)
        HashSet<string> vacunadosAmbasDosis = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstrazeneca));

        // Conjunto de ciudadanos que no se han vacunado (Diferencia de conjuntos)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstrazeneca)));

        // Ciudadanos vacunados solo con Pfizer (Diferencia)
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstrazeneca));

        // Ciudadanos vacunados solo con AstraZeneca (Diferencia)
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca.Except(vacunadosPfizer));

        // Generar reporte en archivo de texto
        string reporte = "Reporte de Vacunación COVID\n" +
                         "---------------------------------\n" +
                         "Ciudadanos no vacunados: " + noVacunados.Count + "\n" +
                         "Ciudadanos vacunados con ambas dosis: " + vacunadosAmbasDosis.Count + "\n" +
                         "Ciudadanos vacunados solo con Pfizer: " + soloPfizer.Count + "\n" +
                         "Ciudadanos vacunados solo con AstraZeneca: " + soloAstrazeneca.Count + "\n";

        File.WriteAllText("reporte_vacunacion.txt", reporte);
        Console.WriteLine("Reporte generado exitosamente.");
    }
}
