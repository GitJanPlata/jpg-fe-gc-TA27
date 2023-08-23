using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Rueda
    {
        public string Marca { get; set; }
        public double Diametro { get; set; }

    public static Rueda CrearRueda(string posicion)
    {
        Console.WriteLine($"Introduce la marca de la rueda {posicion}:");
        string marcaRueda = Console.ReadLine();

        Console.WriteLine($"Introduce el diámetro de la rueda {posicion}:");
        double diametroRueda = double.Parse(Console.ReadLine());

        while (diametroRueda <= 0.4 || diametroRueda >= 4)
        {
            Console.WriteLine("El diámetro de la rueda no es válido. Debe ser superior a 0.4 y inferior a 4.");
            diametroRueda = double.Parse(Console.ReadLine());
        }

        return new Rueda { Marca = marcaRueda, Diametro = diametroRueda };
    }   
}

    

