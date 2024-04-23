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
        public Usuario Usuario;
        public Pago() { }   

        public Pago(Usuario usuario) 
        { 
        
            this.Usuario = usuario;
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
                        Console.WriteLine("Introduce una moneda (valor centimos)");
                        int dinero= int.Parse(Console.ReadLine());
                        switch (dinero)
                        {
                            case 1:
                                
                                break;
                            case 2:

                                break;
                            case 5:

                                break;
                            case 10:

                                break;
                            case 20:

                                break;
                            case 50:

                                break;
                            case 100:

                                break;
                            case 200:

                                break;
                        }
                    }while(opcion == 2);

                    Console.WriteLine("Introduzca las monedas");
                    

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
                    break;
            }
        }


    }
}
