using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class ProductoElectronico : Producto {
        public string Materiales { get; set; }
        public bool Pilas { get; set; }
        public bool Precargado { get; set; }

        public ProductoElectronico(int id) : base(id) { }
        public ProductoElectronico(int id, string nombre, int unidades, double preciounitario, string descripcion, string materiales, bool pilas, bool precargado) : base(id, nombre, unidades, preciounitario, descripcion) {
            Precargado = precargado;
            Materiales = materiales;
            Pilas = pilas;

        }
        public override string MostrarInformacionExtensa() {
            return base.MostrarInformacionExtensa() + $"\nTipo de producto: Electronico\nInformacion adicional:\n-Materiales: {Materiales}\n-Pilas: {Pilas}\n-Precargado: {Precargado}";
        }

        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();
            int variable;
            try
            {
                Console.WriteLine("Tiene Pilas? 1.Si 0.No");
                variable = int.Parse(Console.ReadLine());
                if (variable == 1)
                {
                    Pilas = true;
                }
                else { Pilas = false; }

                Console.WriteLine("Material");
                Materiales = Console.ReadLine();
                Console.WriteLine("Esta Precargado? 1.Si 0.No");
                variable= int.Parse(Console.ReadLine());

                if ( variable == 1)
                {
                    Precargado = true;
                }
                else { Precargado = false; }
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
