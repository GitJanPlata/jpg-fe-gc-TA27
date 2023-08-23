namespace VehiclesMS_2
{
    public class Program
    {
        // Listas para registrar personas y vehículos.
        public static List<Persona> Personas = new List<Persona>();
        public static List<Vehiculo> Vehiculos = new List<Vehiculo>();

        public static void Main()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1. Crear persona.");
                Console.WriteLine("2. Crear vehículo.");
                Console.WriteLine("3. Ver lista de personas.");
                Console.WriteLine("4. Ver lista de vehículos.");
                Console.WriteLine("5. Salir.");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        var persona = Titular.CrearTitular();
                        Personas.Add(persona);
                        break;
                    case 2:

                        if (Personas.Count == 0)
                        {
                            Console.WriteLine("Debes crear al menos una persona antes de crear un vehículo.");
                        }
                        else
                        {
                            Console.WriteLine("Selecciona un titular:");
                            for (int i = 0; i < Personas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {Personas[i].Nombre} {Personas[i].Apellidos}");
                            }

                            int indiceTitular;
                            while (true)
                            {
                                indiceTitular = int.Parse(Console.ReadLine()) - 1;
                                if (indiceTitular >= 0 && indiceTitular < Personas.Count)
                                {
                                    break;
                                }
                                Console.WriteLine("Por favor, elige una opción válida.");
                            }

                            Titular titular = Personas[indiceTitular] as Titular;

                            if (titular == null)
                            {
                                Console.WriteLine("La persona seleccionada no es un titular. Por favor, elige un titular válido.");
                                break;
                            }

                            int eleccion = Vehiculo.SeleccionarVehiculo(titular);
                            Vehiculo vehiculo = Vehiculo.CrearVehiculo(eleccion, Personas);
                            Vehiculos.Add(vehiculo);
                        }
                        break;
                    case 3:
                        MostrarPersonas();
                        break;
                    case 4:
                        MostrarVehiculos();
                        break;
                    case 5:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elige una opción correcta.");
                        break;
                }
            }
        }

        public static void MostrarPersonas()
        {
            if (Personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Console.WriteLine("Lista de personas:");
            foreach (var persona in Personas)
            {
                Console.WriteLine($"- {persona.Nombre} {persona.Apellidos}");
            }
        }

        public static void MostrarVehiculos()
        {
            if (Vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            Console.WriteLine("Lista de vehículos:");
            foreach (var vehiculo in Vehiculos)
            {
                Console.WriteLine($"- Matrícula: {vehiculo.Matricula}, Marca: {vehiculo.Marca}, Color: {vehiculo.Color}");
            }
        }
    }
}