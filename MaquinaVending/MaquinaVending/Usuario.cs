using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Usuario
    {

        public int Clave { get; set; }
        protected List<Producto> listaProductos;
        

        public Usuario() { }

        public Usuario(int clave, List <Producto> productos) 
        {
            this.Clave = clave;
            this.listaProductos = productos;
        }  

        public Producto ElegirProducto() //Funcion usada por el usuario para elegir producto en las opciones 1 y 2. Devuelve la referencia al obejto
        {
            Producto c = null;
            try
            {
                Console.WriteLine("Introduce el Id del producto");
                int id = int.Parse(Console.ReadLine());

                c = listaProductos.Find(x => x.Id == id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Dato no válido. Por favor, ingrese un dato válido.");
            }

            return c;
        }

        public string InsertarNombreArchivo() //Funcion usada para que el usuario escriba el texto del que se quieren añadir productos. Devuelve un string.
        {
            string texto  =null;
            try
            {

                Console.WriteLine("Indique el nombre del archivo:");
                texto = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Dato no válido. Por favor, ingrese un dato válido.");
            }
            

            return texto;
        }

    }
}
