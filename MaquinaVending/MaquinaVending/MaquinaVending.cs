using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class MaquinaVending
    {
        protected List<Producto> listaProductos;
        public Usuario Usuario { get; set; }    //Usuario que manejara las funciones
        public MaquinaVending(Usuario usuario, List <Producto> productos) 
        { 
        
            Usuario = usuario;
            this.listaProductos = productos;
        }

        public void ComprarProductos()
        {
            bool flag = false;

            while (flag == false)
            {
                foreach (Producto p in listaProductos)
                {
                    p.MostrarInformaciónProducto();
                }

                Console.WriteLine("Introduce el Id del producto");
                int id = int.Parse(Console.ReadLine());
                Usuario.InsertarProducto(id);

                Console.WriteLine("Quiere añadir otro producto? \n 1.Si\n 2.No");
                int decision = int.Parse(Console.ReadLine());

                if (decision == 0)
                {
                    flag = true;
                }
            }

            Pago pago = new Pago();

            pago.Pagar();
        }

        public  void MostrarInformacion() 
        {
            {  
                //Mostrar los productos disponibles(ID, nombre, unidades, precio)
                foreach (Producto prod in listaProductos) {
                    prod.MostrarInformaciónProducto();
                }
                // Pedir al usuario que ingrese el ID del producto
                Console.WriteLine("Ingrese el ID del producto:");
                int id = int.Parse(Console.ReadLine());

                // Buscar el producto por ID
                Producto p = listaProductos.Find(x => x.Id == id);

                // Mostrar la información del producto si existe
                if (p != null) {
                    Console.WriteLine($"Nombre: {p.Id}");
                    Console.WriteLine($"Nombre: {p.Nombre}");
                    Console.WriteLine($"Cantidad disponible: {p.Unidades}");
                    Console.WriteLine($"Precio: {p.PrecioUnitario}");
                }
                else {
                    Console.WriteLine("El producto no existe.");
                }
            }

        }

        public void CargaIndividual() 
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Qué desea hacer?");
                Console.WriteLine("1. Añadir Existencias.");
                Console.WriteLine("2. Añadir Nuevo Producto.");
                Console.WriteLine("3. Volver.");
                opcion = int.Parse(Console.ReadLine());

                switch(opcion) 
                {
                    case 1:
                        foreach( Producto p in listaProductos)
                        {
                           p.MostrarInformaciónProducto();
                        }
                        Console.Write("Introduzca el Id del producto a añadir: ");
                        int id = int.Parse(Console.ReadLine());
                        foreach (Producto p in listaProductos)
                        {
                            if (id == p.Id)
                            {
                                Console.WriteLine("Hay " + p.Unidades + " de " + p.Nombre + ".");
                            }
                        }
                        
                        break;
                    case 2:

                        break;
                    case 3: 
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción Incorrecta");
                        break;
                }

            }while (opcion != 3);
        }

        public void CargaCompleta()
        {
            
        }

        public void Salir()
        {

        }

    }
}
