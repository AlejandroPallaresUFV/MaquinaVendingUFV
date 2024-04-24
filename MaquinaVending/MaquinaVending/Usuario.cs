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

        public void InsertarProducto()
        {

            Console.WriteLine("Introduce el Id del producto");
            int id = int.Parse(Console.ReadLine());

            Producto c = listaProductos.Find(x => x.Id == id);

            if (c != null)
            {
                Carrito.Add(c);
                PrecioTotal = PrecioTotal + c.PrecioUnitario;
                Console.WriteLine("Elemento Añadido!");
            }
            else
            {
                Console.WriteLine("Carrito vacío");
            }
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
            Console.WriteLine("De que tipo quiere añadir el producto?\n1.Material Precioso\n2.Producto Alimenticio\n3.Producto Electronico");
            int opcion = int.Parse(Console.ReadLine());

            

            switch (opcion)
            {
                case 1:
                    MaterialPrecioso mp = new MaterialPrecioso(listaProductos.Count);
                    mp.SolicitarDetalles();
                    listaProductos.Add(mp);
                    Console.WriteLine("Se ha añadido el producto!");
                    break;
            }
        }
    }
}
