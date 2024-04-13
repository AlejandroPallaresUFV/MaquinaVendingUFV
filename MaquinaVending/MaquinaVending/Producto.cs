using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion {  get; set; }

        public Producto(string nombre, int unidades, double preciounitario, string descripcion) 
        {
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = preciounitario;
            Descripcion = descripcion;
        }


    }
}
