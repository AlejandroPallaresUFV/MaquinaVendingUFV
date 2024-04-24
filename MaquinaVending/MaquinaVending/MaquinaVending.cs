using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MaquinaVending
{
    internal class MaquinaVending
    {
        protected List<Producto> listaProductos;
        public string TextoSeleccionado { get; set; } = "example_vending_file_practical_work_i.csv";
        public Usuario Usuario { get; set; }    //Usuario que manejara las funciones
        public List<Producto> Carrito { get; set; }
        public double PrecioTotal { get; set; }

        int Contador {  get; set; }

        public MaquinaVending(Usuario usuario, List <Producto> productos) 
        { 
        
            Carrito = new List<Producto>();
            Contador = 0;

            Usuario = usuario;
            this.listaProductos = productos;
        }


        public void ComprarProductos()
        {
            bool flag = false;

            while (flag == false)
            {
                foreach (Producto p in listaProductos)
                {
                    Console.WriteLine(p.MostrarInformaciónProducto());
                }


                Producto c = Usuario.ElegirProducto();

                if (c != null)
                {
                    Carrito.Add(c); 
                    PrecioTotal = PrecioTotal + c.PrecioUnitario;
                    Console.WriteLine("Elemento Añadido!");
                    Contador++;
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }

                Console.WriteLine("Quiere añadir otro producto? \n 1.Si\n 2.No");
                int decision = int.Parse(Console.ReadLine());

                if (decision == 2)
                {
                    flag = true;
                }
            }

            if(Contador!=0) //!Carrito.Any()
            {
                Pago pago = new Pago();

                pago.Pagar(Carrito);
            }
            else
            {
                Console.WriteLine("No hay elementos en el carrito. Volviendo al menú...");
                Thread.Sleep(1000);
            }
            
        }

        public  void MostrarInformacion() 
        {
            {  
                //Mostrar los productos disponibles(ID, nombre, unidades, precio)
                foreach (Producto prod in listaProductos) {
                    Console.WriteLine(prod.MostrarInformaciónProducto());
                }

                // Buscar el producto por ID
                Producto p = Usuario.ElegirProducto();
                // Mostrar la información del producto si existe
                if (p != null) {
                    Console.WriteLine(p.MostrarInformacionExtensa());
                }
                else {
                    Console.WriteLine("El producto no existe.");
                }
            }

        }

        public void CargaIndividual() 
        {

            int opcion = 0;
            
            do
            {
                Console.WriteLine(" --------------------------");
                Console.WriteLine("|     CARGAR PRODUCTOS     |");
                Console.WriteLine("|--------------------------|");
                Console.WriteLine("|1. Añadir Existencias.    |");
                Console.WriteLine("|2. Añadir Nuevo Producto. |");
                Console.WriteLine("|3. Volver.                |");
                Console.WriteLine(" --------------------------");

                try {
                    Console.WriteLine("Opción: ");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (opcion) {
                        case 1:

                            CambiarCantidades();

                            break;
                        case 2:

                            CargarProducto();

                            break;
                        case 3:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción Incorrecta");
                            break;
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingre un número válido.");
                }
                catch (Exception ex) {
                    Console.WriteLine("Error de E/S: " + ex.Message);
                }

            } while (opcion != 3);

            Console.WriteLine("Volviendo al menú...");
            Thread.Sleep(1000);
        }

        public void CargaCompleta()
        {
            Console.WriteLine("Introduzca la clave de administrador");
            int Clave = int.Parse(Console.ReadLine());
            if (Clave == Usuario.Clave) 
            {
                Console.WriteLine("Desea cambiar el archivo de texto seleccionado?");
                Console.WriteLine($"El actual es {TextoSeleccionado}");

                Console.WriteLine(" 1.Si\n 2.No");
                int opcion = int.Parse(Console.ReadLine());

                if(opcion == 1)
                {
                    TextoSeleccionado =  Usuario.InsertarNombreArchivo();
                }

                CargarProducto();

                Console.WriteLine("Carga Completada!\n Volviendo al menú...");

            }
            else
            {
                Console.WriteLine("Clave incorrecta, volviendo al menú...");
                Thread.Sleep(1000);
                
            }
            Thread.Sleep(1000);
            Console.Clear();

        }

        public void Salir()
        {

        }





        public void CambiarCantidades()
        {
            bool exito = false;
            foreach (Producto p in listaProductos)
            {
                Console.WriteLine(p.MostrarInformaciónProducto());
            }
            Console.Write("Introduzca el Id del producto a añadir: ");
            int id = int.Parse(Console.ReadLine());
            foreach (Producto p in listaProductos)
            {
                if (id == p.Id)
                {
                    Console.WriteLine("Hay " + p.Unidades + " de " + p.Nombre + ".");
                    Console.WriteLine("Cuantas unidades desea añadir?: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    p.Unidades = p.Unidades + cantidad;

                    exito = true;

                    Console.WriteLine("Producto modificado!");

                }

            }
            if (exito == false)
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void CargarProducto() 
        {

            if (Contador <12) {
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
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("Introduciendo Producto Alimenticio...");
                            ProductoAlimenticio pa = new ProductoAlimenticio(listaProductos.Count);
                            pa.SolicitarDetalles();
                            listaProductos.Add(pa);
                            Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Introduciendo Producto Electónico...");
                            ProductoElectronico pe = new ProductoElectronico(listaProductos.Count);
                            pe.SolicitarDetalles();
                            listaProductos.Add(pe);
                            Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                            Thread.Sleep(1000);
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

        public void CargarProductos()
        {
            string separator = ";";
            string path = TextoSeleccionado;
            StreamReader sr = File.OpenText(path);

            string header = sr.ReadLine();

            string[] names = header.Split(char.Parse(separator)); 
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(char.Parse(separator));
                
                int id = listaProductos.Count;
                string nombre; int unidades; double preciounitario; 
                string descripcion; string infoNutricional; string materiales;
                bool pilas; bool precargado; string peso;

                nombre = values[1];
                unidades = int.Parse(values[2]);
                preciounitario = double.Parse(values[3]);
                descripcion = values[4];

                if (Contador < 12)
                {

                    if (int.Parse(values[0]) == 1)
                    {
                        materiales = values[5];
                        peso = values[6];

                        MaterialPrecioso mp = new MaterialPrecioso(id, nombre, unidades, preciounitario, descripcion, peso, materiales);
                        listaProductos.Add(mp);

                    }
                    else if (int.Parse(values[0]) == 2)
                    {
                        infoNutricional = values[7];

                        ProductoAlimenticio pa = new ProductoAlimenticio(id, nombre, unidades, preciounitario, descripcion, infoNutricional);
                        listaProductos.Add(pa);

                    }
                    else
                    {
                        materiales = values[5];

                        if (int.Parse(values[8]) == 1)
                        {
                            pilas = true;
                        }
                        else { pilas = false; }

                        if (int.Parse(values[9]) == 1)
                        {
                            precargado = true;
                        }
                        else { precargado = false; }

                        ProductoElectronico pe = new ProductoElectronico(id, nombre, unidades, preciounitario, descripcion, materiales, pilas, precargado);
                        listaProductos.Add(pe);
                    }
                }

                //Console.ReadLine();
            }

            sr.Close();

        }

    }
}
