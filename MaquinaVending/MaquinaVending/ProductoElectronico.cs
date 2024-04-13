using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class ProductoElectronico : Producto
    {
        public string Materiales {  get; set; }
        public bool Pilas {  get; set; }
        public bool Precargado { get; set; }
        public ProductoElectronico(string nombre, int unidades, double preciounitario, string descripcion, string materiales, bool pilas, bool precargado) : base(nombre, unidades, preciounitario, descripcion)
        {
            Precargado = pilas;
            Materiales = materiales;
            Pilas = pilas;
        }
    }
}
