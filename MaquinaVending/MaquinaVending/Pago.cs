using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Pago
    {
        double PrecioTotal;
        public List<Producto> Carrito { get; set; }
        public Pago() { }   

        public Pago(double preciototal, List <Producto> carrito) 
        {

            Carrito = carrito;
            PrecioTotal = preciototal;
     
        }

        public void Pagar(List <Producto> carrito)
        {
            try
            {
                Console.WriteLine("Desea Pagar en efectivo o con tarjeta?\n 1.Efectivo\n 2.Tarjeta \n 3.Salir");
                int opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion) //Se elige el metodo de pago o, si el usuario así lo desea, salir de este
                {
                    case 1: //Pago en efectivo
                        do
                        {

                            Console.WriteLine($"Pago restante:{PrecioTotal} euros");
                            Console.WriteLine("Introduce una moneda (valor en euros) | Pulse 0 para cancelar el pago:");
                            double dinero = int.Parse(Console.ReadLine());
                            switch (dinero) //Se mete una moneda del valor indicado por el ususario. El programa tambien permite salir la pulsar 0.
                            {
                                case 0:
                                    Console.WriteLine("Pago cancelado");
                                    PrecioTotal = -3;
                                    break;
                                case 0.01:
                                    PrecioTotal = PrecioTotal - 0.01;
                                    break;
                                case 0.02:
                                    PrecioTotal = PrecioTotal - 0.02;
                                    break;
                                case 0.05:
                                    PrecioTotal = PrecioTotal - 0.05;
                                    break;
                                case 0.10:
                                    PrecioTotal = PrecioTotal - 0.10;
                                    break;
                                case 0.20:
                                    PrecioTotal = PrecioTotal - 0.20;
                                    break;
                                case 0.50:
                                    PrecioTotal = PrecioTotal - 0.50;
                                    break;
                                case 1.00:
                                    PrecioTotal = PrecioTotal - 1;
                                    break;
                                case 2.00:
                                    PrecioTotal = PrecioTotal - 2;
                                    break;
                                default:
                                    Console.WriteLine("Introduce una moneda válida.");
                                    break;
                            }
                            Console.WriteLine("Calculando...");
                            Thread.Sleep(1000);
                            Console.Clear();

                        } while (PrecioTotal > 0);


                        if(PrecioTotal !=(-3)) //En caso de que el usuario haya completa el pago, se muestra el mensaje y se actualizan las unidades
                        {
                            Console.WriteLine($"Cambio: {(-1) * PrecioTotal}\n Gracias por su compra!");
                            RestarProductos();
                            Thread.Sleep(3000);
                        }
                        

                        break;

                    case 2: //Pago con tarjeta
                        Console.WriteLine($"Precio Total: {PrecioTotal}\n");
                        Console.WriteLine("Introduza el numero de tarjeta:");
                        Console.ReadLine();
                        Console.WriteLine("Fecha:");
                        Console.ReadLine();
                        Console.WriteLine("CVV:");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Espere un momento...");
                        Thread.Sleep(5000);

                        Console.Clear();
                        Console.WriteLine("Gracias por su compra!");
                        RestarProductos();
                        Thread.Sleep(3000);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Cancelando pago...");
                        Carrito.Clear();

                        break;
                    default:
                        Console.WriteLine("Pulse una opcion valida.");
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
  
        }

        public void RestarProductos() //Funcion usada para restar unidades de cada producto que hay en el carro
        {
            foreach(Producto p in Carrito)
            {
                p.Unidades--;
            }

            Carrito.Clear(); //Al terminar, se liberan las direcciones de memoria del carrito para una nueva compra
        }
    }
}
