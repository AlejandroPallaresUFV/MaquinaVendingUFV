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
        public ProductoElectronico(int id, string nombre, int unidades, double preciounitario, string descripcion, string materiales, bool pilas, bool precargado) : base(id, nombre, unidades, preciounitario, descripcion) {
            Precargado = precargado;
            Materiales = materiales;
            Pilas = pilas;

        }
        public override string MostrarInformacionExtensa() {
            return base.MostrarInformacionExtensa() + $"\nTipo de producto: Electronico\nInformacion adicional:\n-Materiales: {Materiales}\n-Pilas: {Pilas}\n-Precargado: {Precargado}";



        }
    }
}
