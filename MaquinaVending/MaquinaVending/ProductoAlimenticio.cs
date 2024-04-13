using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class ProductoAlimenticio : Producto
    {
        string InfoNutricional {  get; set; }
        public ProductoAlimenticio(string nombre, int unidades, double preciounitario, string descripcion, string infoNutricional) : base(nombre, unidades, preciounitario, descripcion)
        {
            InfoNutricional = infoNutricional;
        }
    }
}
