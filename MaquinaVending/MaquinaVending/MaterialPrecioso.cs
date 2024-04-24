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

        public MaterialPrecioso(int id) : base(id) { }  
        public MaterialPrecioso(int id, string nombre, int unidades, double preciounitario, string descripcion, double peso, string material) : base(id, nombre, unidades, preciounitario, descripcion)
        {
            Peso = peso;
            Material = material;
        }
        public override string MostrarInformacionExtensa() {
            return base.MostrarInformacionExtensa() + $"\nTipo de producto: Material Precioso\nInformacion adicional:\n-Peso (en gramos): {Peso}\n-Material:{Material}";
        }

        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();
            try
            {
                Console.WriteLine("Peso");
                Peso = int.Parse(Console.ReadLine());
                Console.WriteLine("Material");
                Material = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Dato no válido. Por favor, ingrese un dato válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
        }

    }
}
