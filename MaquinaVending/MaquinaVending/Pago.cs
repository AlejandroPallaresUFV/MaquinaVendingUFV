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
        public Usuario usuario;

        public enum Moneda {diez}
        public Pago() { }   

        public Pago(Usuario usuario) 
        { 
        
            this.usuario = usuario;
        }

        public void Pagar()
        {
            Console.WriteLine("Desea Pagar en efectivo o con tarjeta?\n 1.Efectivo\n 2.Tarjeta");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    do 
                    {
                        Console.WriteLine($"Pago restante:{usuario.PrecioTotal} euros");
                        Console.WriteLine("Introduce una moneda (valor en euros)");
                        double dinero= int.Parse(Console.ReadLine());
                        switch (dinero)
                        {
                            case 0.01:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.01;
                                break;
                            case 0.02:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.02;
                                break;
                            case 0.05:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.05;
                                break;
                            case 0.10:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.10;
                                break;
                            case 0.20:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.20;
                                break;
                            case 0.50:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.50;
                                break;
                            case 1.00:
                                usuario.PrecioTotal = usuario.PrecioTotal - 1;
                                break;
                            case 2.00:
                                usuario.PrecioTotal = usuario.PrecioTotal - 2;
                                break;
                            default:
                                Console.WriteLine("Introduce una moneda válida.");
                                break;
                        }
                        Console.WriteLine("Calculando...");
                        Thread.Sleep(1000);
                        Console.Clear();

                    } while(usuario.PrecioTotal > 0);

                    Console.WriteLine($"Cambio: {(-1)*usuario.PrecioTotal}\n Gracias por su compra!");
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
                    usuario.PrecioTotal = 0;

                    Console.WriteLine("Gracias por su compra!");
                    Thread.Sleep(3000);
                    break;
            }
        }


    }
}
