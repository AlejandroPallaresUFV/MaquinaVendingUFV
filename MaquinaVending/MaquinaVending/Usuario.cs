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

        public List<Producto> Carrito { get; set; }

        public double PrecioTotal { get; set; }

        public Usuario() { }

        public Usuario(int clave, List <Producto> productos) 
        {
            this.Clave = clave;
            this.listaProductos = productos;
        }  

        public void InsertarProducto(int id)
        {


            Producto c = listaProductos.Find(x => x.Id == id);

            if (c != null)
            {
                Carrito.Add(c);
                PrecioTotal = PrecioTotal + c.PrecioUnitario;
                Console.WriteLine("Elemento Añadido!");
            }
            else
            {
                Console.WriteLine("Elemento no encontrado.");
            }
        }

        public void InsertarNombreArchivo()
        {

        }

        public void CargarProductos()
        {

        }
    }
}
