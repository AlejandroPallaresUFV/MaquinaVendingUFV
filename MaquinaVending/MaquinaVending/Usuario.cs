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
        protected List<Producto> listaProductos;
        public List<Producto> Carrito { get; set; }
        public double PrecioTotal { get; set; }

        public Usuario() { }

        public Usuario(int clave, List <Producto> productos) 
        {
            this.Clave = clave;
            this.listaProductos = productos;
        }  

        public void InsertarProducto()
        {

            Console.WriteLine("Introduce el Id del producto");
            int id = int.Parse(Console.ReadLine());

            Producto c = listaProductos.Find(x => x.Id == id);

            if (c != null)
            {
                Carrito.Add(c);
                PrecioTotal = PrecioTotal + c.PrecioUnitario;
                Console.WriteLine("Elemento Añadido!");
            }
            else
            {
                Console.WriteLine("Carrito vacío");
            }
        }

        public string InsertarNombreArchivo()
        {
            string texto;

            Console.WriteLine("Indique el nombre del archivo:");
            texto = Console.ReadLine();

            return texto;
        }

        public void CargarProducto()
        {

            Console.WriteLine(" -------------------------");
            Console.WriteLine("|     CARGAR PRODUCTO     |");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|1. Material Precioso.    |");
            Console.WriteLine("|2. Producto Alimenticio. |");
            Console.WriteLine("|3. Producto Electrónico. |");
            Console.WriteLine("|4. Salir.                |");
            Console.WriteLine(" -------------------------");

            try
            {
                Console.WriteLine("Opción: ");
                int opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {


                    case 1:
                        Console.WriteLine("Introduciendo Material Precioso...");
                        MaterialPrecioso mp = new MaterialPrecioso(listaProductos.Count);
                        mp.SolicitarDetalles();
                        listaProductos.Add(mp);
                        Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Introduciendo Producto Alimenticio...");
                        ProductoAlimenticio pa = new ProductoAlimenticio(listaProductos.Count);
                        pa.SolicitarDetalles();
                        listaProductos.Add(pa);
                        Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Introduciendo Producto Electónico...");
                        ProductoElectronico pe = new ProductoElectronico(listaProductos.Count);
                        pe.SolicitarDetalles();
                        listaProductos.Add(pe);
                        Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opción Inválida");
                        break;
                }
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
