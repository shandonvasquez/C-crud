using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Program
    {
        private static string filePath = "Examen.txt";

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Programa de ingreso de alumnos");
                Console.WriteLine("1.Grabar registro alumnos");
                Console.WriteLine("2. Monstrar registro de alumnos");
                Console.WriteLine("3. Moodificar Registro de alumnos ");
                Console.WriteLine("4. Eliminar registro de alumnos");
                Console.WriteLine("5. Salir");

                Console.WriteLine("Ingrese una opcion");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Opcion de ingresar datos activada");
                          Ingresar();
                        break;
                    case 2:
                        LeerListado();
                        
                        break;
                    case 3:
                        Modificar();
                        break;
                    case 4:
                        Eliminar();
                        break;
                    case 5:
                        
                        Console.WriteLine("Gracias por usar el programa");
                   
                        Environment.Exit(0);
                      
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcion != 6);
        }

        static void Guardar(string nombre, string id, string numero)
        {
            StreamWriter escribir = new StreamWriter(filePath, true);
            escribir.WriteLine(nombre + "," + id + "," + numero);
            escribir.Close();
        }

        static void Leer()
        {
            StreamReader leer = new StreamReader(filePath, true);
            string linea = "";
            while (linea != null)
            {
                linea = leer.ReadLine();
                if (linea != null)
                {
                    string[] datos = linea.Split(',');
                    Console.WriteLine("Nombre: " + datos[0]);
                    Console.WriteLine("ID: " + datos[1]);
                    Console.WriteLine("Numero: " + datos[2]);
                    Console.WriteLine(" ");
                }
            }
            leer.Close();
        }

        static void Ingresar()
        {

            Console.WriteLine("Ingrese el nombre del alumno");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del alumno");
            string id = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del alumno");
            string numero = Console.ReadLine();
            Console.WriteLine("");

            Guardar(nombre, id, numero);
            if (nombre == "" || id == "" || numero == "")
            {
                Console.WriteLine("No puede dejar ningun campo vacio");
                Console.WriteLine("");
                Ingresar();
            }
            else
            {
                Console.WriteLine("Datos del alumno guardados con éxito.");
                Console.WriteLine("");
            }


        }

        static void Eliminar()
        {
            Console.WriteLine("Ingresse el Nombre del alumno que desea eliminar");
            string nombre = Console.ReadLine();
            string[] lineas = File.ReadAllLines(filePath);
            File.WriteAllText(filePath, "");

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');
                if (datos[0] != nombre)
                {
                    Guardar(datos[0], datos[1], datos[2]);
                }
            }

            Console.WriteLine("Datos del alumno eliminados con éxito.");
            Console.WriteLine("");
        }

        static void Modificar()
        {
        
            Console.WriteLine("Ingrese el ID del alumno que desea modificar");
            string id = Console.ReadLine();
            string[] lineas = File.ReadAllLines(filePath);
            File.WriteAllText(filePath, "");

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');
                if (datos[1] == id)
                {
                    Console.WriteLine("Ingrese el nuevo ID del alumno");
                    string nuevoid = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre del alumno");
                    string nuevonombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el numero de Celular del alumno");
                    string nuevocelular = Console.ReadLine();
                    Console.WriteLine("");
                    Guardar(nuevonombre, nuevoid, nuevocelular);
                }
                else
                {
                    Guardar(datos[0], datos[1], datos[2]);
                }
            }

            Console.WriteLine("Datos del alumno con ID " + id + " modificados con éxito.");
        }

        static void LeerListado()
        {
            StreamReader leer = new StreamReader(filePath);
            string linea = "";
            while (linea != null)
            {
                linea = leer.ReadLine();
                if (linea != null)
                {
                    string[] datos = linea.Split(',');
                    Console.WriteLine("Nombre: " + datos[0]);
                    Console.WriteLine("ID: " + datos[1]);
                    Console.WriteLine("Numero: " + datos[2]);
                    Console.WriteLine(" ");
                }
            }
            leer.Close();
        }
    }
}