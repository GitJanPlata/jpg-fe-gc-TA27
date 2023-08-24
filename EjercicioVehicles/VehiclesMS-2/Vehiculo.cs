using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VehiclesMS_2
{
    public abstract class Vehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public Titular Titular { get; set; }
        public List<Persona> Conductores { get; set; } = new List<Persona>();

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Color: {Color}");
        }
        public abstract void AgregarRuedaTrasera(Rueda rueda);
        public abstract void AgregarRuedaDelantera(Rueda rueda);

        public static int SeleccionarVehiculo(Titular titular)
        {
            int eleccion;
            bool licenciaValida = false;
            do
            {
                Console.WriteLine("¿Qué vehículo deseas crear? (1 = Coche, 2 = Moto, 3 = Camion)");
                eleccion = int.Parse(Console.ReadLine());

                if (eleccion == 1)
                {
                    if (titular.LicenciaConducir.Tipo == "Coche")
                    {
                        licenciaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("No tienes licencia para conducir un coche.");
                    }
                }
                else if (eleccion == 2)
                {
                    if (titular.LicenciaConducir.Tipo == "Moto")
                    {
                        licenciaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("No tienes licencia para conducir una moto.");
                    }
                }
                else if (eleccion == 3)
                {
                    if (titular.LicenciaConducir.Tipo == "Camion")
                    {
                        licenciaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("No tienes licencia para conducir un camion.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, elige una opción correcta.");
                }
            } while (!licenciaValida);

            return eleccion;
        }

        

        public static Vehiculo CrearVehiculo(int eleccion, List<Persona> personas)
        {
            Vehiculo vehiculo;

            switch (eleccion)
            {
                case 1:
                    vehiculo = new Coche();
                    break;
                case 2:
                    vehiculo = new Moto();
                    break;
                case 3:
                    vehiculo = new Camion();
                    break;
                default:
                    throw new Exception("Opción de vehículo no válida.");
            }

            Console.WriteLine("Introduce la matrícula del vehículo:");
            vehiculo.Matricula = Console.ReadLine().ToUpper();
            while (!Regex.IsMatch(vehiculo.Matricula, @"^\d{4}[A-Z]{2,3}$"))
            {
                Console.WriteLine("Matrícula no válida. El formato debe tener 4 números seguidos de 2 o 3 letras.");
                vehiculo.Matricula = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Introduce la marca del vehículo:");
            vehiculo.Marca = Console.ReadLine();

            Console.WriteLine("Introduce el color del vehículo:");
            vehiculo.Color = Console.ReadLine();

            Rueda ruedaTrasera = Rueda.CrearRueda("trasera");
            vehiculo.AgregarRuedaTrasera(ruedaTrasera);

            Rueda ruedaDelantera = Rueda.CrearRueda("delantera");
            vehiculo.AgregarRuedaDelantera(ruedaDelantera);

            // Asignar titular:
            Console.WriteLine("Elige un titular de la lista:");
            for (int i = 0; i < personas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personas[i].Nombre} {personas[i].Apellidos}");
            }
            int indice = int.Parse(Console.ReadLine()) - 1;
            vehiculo.Titular = (Titular)personas[indice];

            // Opcionalmente agregar conductores:
            Console.WriteLine("¿Deseas agregar conductores? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                do
                {
                    Console.WriteLine("Elige un conductor de la lista:");
                    for (int i = 0; i < personas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {personas[i].Nombre} {personas[i].Apellidos}");
                    }
                    indice = int.Parse(Console.ReadLine()) - 1;
                    vehiculo.Conductores.Add(personas[indice]);

                    Console.WriteLine("¿Deseas agregar otro conductor? (S/N)");
                } while (Console.ReadLine().ToUpper() == "S");
            }

            return vehiculo;
        }
    }
    public class Camion : Vehiculo
    {
        public Rueda[] Ruedas = new Rueda[6];
        public override void AgregarRuedaTrasera(Rueda rueda)
        {
            Ruedas[3] = rueda;
            Ruedas[4] = rueda;
            Ruedas[5] = rueda;
        }
        public override void AgregarRuedaDelantera(Rueda rueda)
        {
            Ruedas[0] = rueda;
            Ruedas[1] = rueda;
            Ruedas[2] = rueda;
        }
    }
    public class Coche : Vehiculo
    {
        public Rueda[] Ruedas = new Rueda[4];

        public override void AgregarRuedaTrasera(Rueda rueda)
        {
            Ruedas[2] = rueda;
            Ruedas[3] = rueda;
        }

        public override void AgregarRuedaDelantera(Rueda rueda)
        {
            Ruedas[0] = rueda;
            Ruedas[1] = rueda;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Tipo: Coche");
            Console.WriteLine($"Rueda Delantera - Marca: {Ruedas[0].Marca}, Diámetro: {Ruedas[0].Diametro}");
            Console.WriteLine($"Rueda Trasera - Marca: {Ruedas[2].Marca}, Diámetro: {Ruedas[2].Diametro}");
        }

    }

    public class Moto : Vehiculo
    {
        public Rueda[] Ruedas = new Rueda[2];

        public override void AgregarRuedaTrasera(Rueda rueda)
        {
            Ruedas[1] = rueda;
        }

        public override void AgregarRuedaDelantera(Rueda rueda)
        {
            Ruedas[0] = rueda;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Tipo: Moto");
            Console.WriteLine($"Rueda Delantera - Marca: {Ruedas[0].Marca}, Diámetro: {Ruedas[0].Diametro}");
            Console.WriteLine($"Rueda Trasera - Marca: {Ruedas[1].Marca}, Diámetro: {Ruedas[1].Diametro}");
        }
    }
}
