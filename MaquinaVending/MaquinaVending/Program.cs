using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Program
    {
        static List <Producto> listaProductos;

        static Usuario usuario;
        static void Main(string[] args)
        {
            listaProductos = new List <Producto>();
            
            int clave = 1234;
            usuario = new Usuario(clave, listaProductos);
            MaquinaVending maquinaVending = new MaquinaVending(usuario,listaProductos);



            Menu(maquinaVending);
           
        }

        public static void Menu(MaquinaVending maquinaVending) //Menu principal de la Maquina de Vending
        
        {
            int opcion = 0;

            do
            {
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine("|        MÁQUINA DE VENDING           |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. Comprar Productos.                |");
                Console.WriteLine("|2. Mostrar información del producto. |");
                Console.WriteLine("|3. Carga individual de productos.    |");
                Console.WriteLine("|4. Carga completa de productos.      |");
                Console.WriteLine("|5. Salir.                            |");
                Console.WriteLine(" -------------------------------------");
                

                try {

                    Console.Write("Opción: ");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1: // Comprar productos
                            maquinaVending.ComprarProductos();
                            break;
                        case 2: // Mostrar información del producto
                            maquinaVending.MostrarInformacion();
                            break;
                        case 3: // Carga individual de productos
                            maquinaVending.CargaIndividual();
                            break;
                        case 4://Carga completa de productos
                            maquinaVending.CargaCompleta();
                            break;
                        case 5: // Salir
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Dato no válido. Por favor, ingrese un dato válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();



            } while (opcion != 5);

            maquinaVending.Salir(); 
        }
    }
}
