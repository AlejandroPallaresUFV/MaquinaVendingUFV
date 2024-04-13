using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class MaterialPrecioso : Producto
    {
        
        public double Peso {  get; set; }  
        public string Material {  get; set; }


        public MaterialPrecioso(string nombre, int unidades, double preciounitario, string descripcion, double peso, string material) : base(nombre, unidades, preciounitario, descripcion)
        {
            Peso = peso;
            Material = material;
        }

    }
}
