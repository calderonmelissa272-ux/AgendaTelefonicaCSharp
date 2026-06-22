using System;
using System.Collections.Generic;

namespace AgendaTelefonica
{
    class Program
    {
        static List<Contacto> agenda = new List<Contacto>();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\n=== AGENDA TELEFÓNICA ===");
                Console.WriteLine("1. Registrar contacto");
                Console.WriteLine("2. Mostrar contactos");
                Console.WriteLine("3. Buscar contacto");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarContacto();
                        break;

                    case 2:
                        MostrarContactos();
                        break;

                    case 3:
                        BuscarContacto();
                        break;

                    case 4:
                        EliminarContacto();
                        break;

                    case 5:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 5);
        }

        static void RegistrarContacto()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            agenda.Add(new Contacto(nombre, telefono, correo));

            Console.WriteLine("Contacto registrado correctamente.");
        }

        static void MostrarContactos()
        {
            if (agenda.Count == 0)
            {
                Console.WriteLine("No existen contactos.");
                return;
            }

            foreach (Contacto c in agenda)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Nombre: " + c.Nombre);
                Console.WriteLine("Teléfono: " + c.Telefono);
                Console.WriteLine("Correo: " + c.Correo);
            }
        }

        static void BuscarContacto()
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            foreach (Contacto c in agenda)
            {
                if (c.Nombre.ToLower() == nombre.ToLower())
                {
                    Console.WriteLine("Contacto encontrado");
                    Console.WriteLine("Teléfono: " + c.Telefono);
                    Console.WriteLine("Correo: " + c.Correo);
                    return;
                }
            }

            Console.WriteLine("Contacto no encontrado.");
        }

        static void EliminarContacto()
        {
            Console.Write("Nombre del contacto a eliminar: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Nombre.ToLower() == nombre.ToLower())
                {
                    agenda.RemoveAt(i);
                    Console.WriteLine("Contacto eliminado.");
                    return;
                }
            }

            Console.WriteLine("Contacto no encontrado.");
        }
    }
}
