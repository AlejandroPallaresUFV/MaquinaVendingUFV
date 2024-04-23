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


        public MaterialPrecioso(int id, string nombre, int unidades, double preciounitario, string descripcion, double peso, string material) : base(id, nombre, unidades, preciounitario, descripcion)
        {
            Peso = peso;
            Material = material;
        }
        public override string MostrarInformacionExtensa() {
            return base.MostrarInformacionExtensa() + $"\nTipo de producto: Material Precioso\nInformacion adicional:\n-Peso (en gramos): {Peso}\n-Material:{Material}";
        }
    }
}
