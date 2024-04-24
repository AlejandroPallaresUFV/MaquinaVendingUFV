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

        public Pago(double preciototal ) 
        { 
        
            PrecioTotal = preciototal;
     
        }

        public void Pagar(List <Producto> carrito)
        {
            try
            {
                Console.WriteLine("Desea Pagar en efectivo o con tarjeta?\n 1.Efectivo\n 2.Tarjeta");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine($"Pago restante:{PrecioTotal} euros");
                            Console.WriteLine("Introduce una moneda (valor en euros)");
                            double dinero = int.Parse(Console.ReadLine());
                            switch (dinero)
                            {
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

                        Console.WriteLine($"Cambio: {(-1) * PrecioTotal}\n Gracias por su compra!");
                        Thread.Sleep(3000);

                        break;
                    case 2:
                        Console.WriteLine("Introduza el numero de tarjeta:");
                        Console.ReadLine();
                        Console.WriteLine("Fecha:");
                        Console.ReadLine();
                        Console.WriteLine("CVV:");
                        Console.ReadLine();

                        Console.WriteLine("Espere un momento...");
                        Thread.Sleep(5000);
                        PrecioTotal = 0;

                        Console.WriteLine("Gracias por su compra!");
                        Thread.Sleep(3000);
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
    }
}
