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
                        Console.WriteLine("Introduce una moneda (valor centimos)");
                        int dinero= int.Parse(Console.ReadLine());
                        switch (dinero)
                        {
                            case 1:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.01;
                                break;
                            case 2:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.02;
                                break;
                            case 5:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.05;
                                break;
                            case 10:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.10;
                                break;
                            case 20:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.20;
                                break;
                            case 50:
                                usuario.PrecioTotal = usuario.PrecioTotal - 0.50;
                                break;
                            case 100:
                                usuario.PrecioTotal = usuario.PrecioTotal - 1;
                                break;
                            case 200:
                                usuario.PrecioTotal = usuario.PrecioTotal - 2;
                                break;
                        }
                        Console.WriteLine("Calculando...");
                        Thread.Sleep(1000);
                        Console.Clear();

                    } while(usuario.PrecioTotal > 0);

                    Console.WriteLine($"Cambio: {usuario.PrecioTotal}\n Gracias por su compra!");
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
