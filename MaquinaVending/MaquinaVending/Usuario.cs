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

        public Producto[] Carrito { get; set; }

        public Usuario() { }

        public Usuario(int clave) 
        {
            this.Clave = clave;
        }  

        public void InsertarProducto()
        {

        }

        public void InsertarNombreArchivo()
        {

        }

        public void CargarProductos()
        {

        }
    }
}
