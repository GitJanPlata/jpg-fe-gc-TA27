using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesMS_2
{

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class Conductor : Persona
    {
        public Licencia LicenciaConducir { get; set; }

        public static void VerificarYCrearConductor(int eleccion)
        {
            Console.WriteLine("¿El titular será también el conductor? (S/N)");
            if (Console.ReadLine().ToUpper() != "S")
            {
                Conductor conductor = new Conductor();
                Console.WriteLine("Introduce el nombre del conductor:");
                conductor.Nombre = Console.ReadLine();

                Console.WriteLine("Introduce los apellidos del conductor:");
                conductor.Apellidos = Console.ReadLine();

                Console.WriteLine("Introduce la fecha de nacimiento del conductor (dd/mm/aaaa):");
                conductor.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                conductor.LicenciaConducir = new Licencia();

                Console.WriteLine("Introduce el ID de la licencia de conducir del conductor:");
                conductor.LicenciaConducir.ID = Console.ReadLine();

                Console.WriteLine("Introduce el tipo de licencia (ejemplo: Coche, Moto, Camión):");
                conductor.LicenciaConducir.Tipo = Console.ReadLine();

                Console.WriteLine("Introduce la fecha de caducidad de la licencia (dd/mm/aaaa):");
                conductor.LicenciaConducir.FechaCaducidad = DateTime.Parse(Console.ReadLine());

                if (eleccion == 1 && conductor.LicenciaConducir.Tipo != "Coche")
                {
                    throw new Exception("El conductor no tiene licencia para conducir un coche.");
                }
                else if (eleccion == 2 && conductor.LicenciaConducir.Tipo != "Moto")
                {
                    throw new Exception("El conductor no tiene licencia para conducir una moto.");
                }
                else if (eleccion == 3 && conductor.LicenciaConducir.Tipo != "camion")
                {
                    throw new Exception("El conductor no tiene licencia para conducir un camion.");
                }
            }
        }
    }

    public class Titular : Conductor
    {
        public bool TieneSeguro { get; set; }
        public bool TieneGarajePropio { get; set; }
        public static Titular CrearTitular()
        {
            Titular titular = new Titular();

            Console.WriteLine("Introduce el nombre del titular:");
            titular.Nombre = Console.ReadLine();

            Console.WriteLine("Introduce los apellidos del titular:");
            titular.Apellidos = Console.ReadLine();

            Console.WriteLine("Introduce la fecha de nacimiento del titular (dd/mm/aaaa):");
            titular.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            titular.LicenciaConducir = new Licencia();

            Console.WriteLine("Introduce el ID de la licencia de conducir del titular:");
            titular.LicenciaConducir.ID = Console.ReadLine();

            Console.WriteLine("Introduce el tipo de licencia (ejemplo: Coche, Moto, Camión):");
            titular.LicenciaConducir.Tipo = Console.ReadLine();

            Console.WriteLine("Introduce la fecha de caducidad de la licencia (dd/mm/aaaa):");
            titular.LicenciaConducir.FechaCaducidad = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("¿El titular tiene seguro? (S/N):");
            titular.TieneSeguro = Console.ReadLine().ToUpper() == "S";

            Console.WriteLine("¿El titular tiene garaje propio? (S/N):");
            titular.TieneGarajePropio = Console.ReadLine().ToUpper() == "S";
            return titular;
        }
    }



}
