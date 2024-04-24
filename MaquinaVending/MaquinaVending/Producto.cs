using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion {  get; set; }

        public Producto (int id)
        {
            id = Id;
        }

        public Producto(int id, string nombre, int unidades, double preciounitario, string descripcion) 
        {
            Id = id;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = preciounitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarInformaciónProducto() {
            return $"ID: {Id}\n Nombre: {Nombre}\nUnidades: {Unidades}\nPrecio: {PrecioUnitario}";
        }

        public virtual string MostrarInformacionExtensa() {
            return $"\n Nombre: {Nombre}\nPrecio: {PrecioUnitario}\nDescripción:{Descripcion}" +
                $"\nCantidad disponible: {Unidades}";
        }

        public virtual void SolicitarDetalles()
        {
            Console.WriteLine("Nombre");
            Nombre = Console.ReadLine();
            Console.WriteLine("Unidades");
            Unidades = int.Parse(Console.ReadLine());
            Console.WriteLine("Precio unitario:");
            PrecioUnitario = int.Parse(Console.ReadLine());
            Console.WriteLine("Descripcion:");
            Descripcion = Console.ReadLine();

        }
    }
}
