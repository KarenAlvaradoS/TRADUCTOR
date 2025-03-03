using System;
using System.Collections.Generic;

class Traductor
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"},
        {"tiempo", "time"}, {"persona", "person"}, {"año", "year"},
        {"camino", "way"}, {"día", "day"}, {"cosa", "thing"},
        {"hombre", "man"}, {"mundo", "world"}, {"vida", "life"},
        {"mano", "hand"}, {"parte", "part"}, {"niño", "child"},
        {"ojo", "eye"}, {"mujer", "woman"}, {"lugar", "place"},
        {"trabajo", "work"}, {"semana", "week"}, {"caso", "case"},
        {"punto", "point"}, {"gobierno", "government"}, {"empresa", "company"}
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("============================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar más palabras al diccionario");
            Console.WriteLine("3. Mostrar todas las palabras en el diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";
            if (opcion == "0") break;

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la frase: ");
                    string frase = Console.ReadLine()?.Trim() ?? "";
                    Console.WriteLine("Frase traducida: " + TraducirFrase(frase));
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "3":
                    MostrarDiccionario();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static string TraducirFrase(string frase)
    {
        if (string.IsNullOrWhiteSpace(frase)) return "Frase vacía.";

        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraOriginal = palabras[i];
            string palabraMinuscula = palabraOriginal.ToLower();
            
            if (diccionario.ContainsKey(palabraMinuscula))
            {
                palabras[i] = diccionario[palabraMinuscula];
            }
        }
        return string.Join(" ", palabras);
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en un idioma: ");
        string idioma1 = Console.ReadLine()?.Trim().ToLower() ?? "";
        Console.Write("Ingrese la traducción: ");
        string idioma2 = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(idioma1) || string.IsNullOrWhiteSpace(idioma2))
        {
            Console.WriteLine("Entrada inválida. Inténtelo nuevamente.");
            return;
        }

        if (!diccionario.ContainsKey(idioma1))
        {
            diccionario.Add(idioma1, idioma2);
            diccionario.Add(idioma2, idioma1);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    static void MostrarDiccionario()
    {
        Console.WriteLine("\nDiccionario actual:");
        foreach (var palabra in diccionario)
        {
            Console.WriteLine($"{palabra.Key} - {palabra.Value}");
        }
    }
}
