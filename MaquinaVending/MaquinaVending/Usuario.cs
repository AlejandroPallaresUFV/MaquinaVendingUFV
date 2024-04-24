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

        public Producto ElegirProducto()
        {

            Console.WriteLine("Introduce el Id del producto");
            int id = int.Parse(Console.ReadLine());

            Producto c = listaProductos.Find(x => x.Id == id);

            return c;
        }

        public string InsertarNombreArchivo()
        {
            string texto;

            Console.WriteLine("Indique el nombre del archivo:");
            texto = Console.ReadLine();

            return texto;
        }

        public void CargarProducto()
        {

        }
    }
}
