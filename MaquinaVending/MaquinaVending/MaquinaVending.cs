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
                    p.MostrarInformación();
                }

                Console.WriteLine("Introduce el Id del producto");
                int id = int.Parse(Console.ReadLine());
                Usuario.InsertarProducto(id);
            }
        }

        public void MostrarInformación() 
        {
            
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
                           p.MostrarInformacion();
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
