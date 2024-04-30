using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        //Funciones Principales


        public void ComprarProductos()
        {
            bool flag = false; //Se define un flag para que le bucle se repita y se puedan añadir mas de un objeto
            PrecioTotal = 0;

            while (flag == false) 
            {
                foreach (Producto p in listaProductos) //Se muestran todos los productos de la maquina
                {
                    Console.WriteLine(p.MostrarInformaciónProducto());
                }


                Producto c = Usuario.ElegirProducto();

                Console.Clear();

                if (c != null) //Si el objeto se recoje correctamente...
                {
                    if (ComprobarUnidades(c)) //Se comprueba si aun se pueden meter mas unidades de ese articulo
                    {
                        Carrito.Add(c); //se añade el producto y se suma su precio al total
                        PrecioTotal = PrecioTotal + c.PrecioUnitario;
                        Console.WriteLine("Elemento Añadido!");
                    }
                                     
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }

                Console.WriteLine("\nCARRITO");
                Console.WriteLine("--------");
                foreach (Producto p in Carrito) //Se muestra el carrito completo
                {
                    Console.WriteLine(p.MostrarInformaciónProducto());
                }
                Console.WriteLine($"Precio Total: {PrecioTotal}");

                Console.WriteLine("\n\nQuiere añadir otro producto? \n 1.Si\n 2.No");
                int decision = int.Parse(Console.ReadLine());

                Console.Clear();

                if (decision == 2) //En caso de que el usuario diga "no", se pone la flag a true y se sale del bucle
                {
                    flag = true;
                }
            }

            if(Carrito.Any())  //Si el carrrito tiene productos, se crea una instancia de pago y se paga
            {
                Pago pago = new Pago(PrecioTotal, Carrito);

                pago.Pagar(Carrito);

                PrecioTotal = 0;
            
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

                Console.Clear();

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
            try
            {

                Console.WriteLine("Introduzca la clave de administrador");
                int Clave = int.Parse(Console.ReadLine());
                Console.Clear();


                if (Clave == Usuario.Clave)
                {

                    do
                    {
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine("|     CARGAR PRODUCTOS     |");
                        Console.WriteLine("|--------------------------|");
                        Console.WriteLine("|1. Añadir Existencias.    |");
                        Console.WriteLine("|2. Añadir Nuevo Producto. |");
                        Console.WriteLine("|3. Volver.                |");
                        Console.WriteLine(" --------------------------");

                        try
                        {
                            Console.WriteLine("Opción: ");
                            opcion = int.Parse(Console.ReadLine());
                            Console.Clear();

                            switch (opcion)
                            {
                                case 1: //Opcion para cambiar las uniadades de un producto

                                    CambiarCantidades();
                                    Console.Clear();

                                    break;
                                case 2: //Opcion para cargar un producto nuevo

                                    CargarProducto();
                                    Console.Clear();

                                    break;
                                case 3:
                                    Console.WriteLine("Saliendo...");
                                    break;
                                default:
                                    Console.WriteLine("Opción Incorrecta");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: Opción inválida. Por favor, ingre un número válido.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error de E/S: " + ex.Message);
                        }

                    } while (opcion != 3);
                }
                else
                {
                    Console.WriteLine("Clave incorrecta.");
                    Thread.Sleep(1000);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Dato no válido. Por favor, ingrese un dato válido.");
            }

            Console.WriteLine("Volviendo al menú...");
            Thread.Sleep(1000);
        }

        public void CargaCompleta()
        {
            try
            {
                Console.WriteLine("Introduzca la clave de administrador");
                int Clave = int.Parse(Console.ReadLine());
                Console.Clear();

                if (Clave == Usuario.Clave)
                {
                    Console.WriteLine("Desea cambiar el archivo de texto seleccionado?"); //Se da la opción de cambiar el tetxo predeterminado
                    Console.WriteLine($"El actual es {TextoSeleccionado}");

                    Console.WriteLine(" 1.Si\n 2.No");
                    int opcion = int.Parse(Console.ReadLine());

                    if (opcion == 1) //En caso de que así sea, se altera la variable
                    {
                        TextoSeleccionado = Usuario.InsertarNombreArchivo();
                    }

                    CargarProductos(); //se ejecuta la funcion de carga completa

                    Console.WriteLine("Carga Completada!\n Volviendo al menú...");

                }
                else
                {
                    Console.WriteLine("Clave incorrecta, volviendo al menú...");
                    Thread.Sleep(1000);

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
            Thread.Sleep(1000);
            Console.Clear();

        }

        public void Salir()
        {

        }


        //Funciones de apoyo


        public void CambiarCantidades()
        {
            bool exito = false;
            try
            {
                foreach (Producto p in listaProductos)
                {
                    Console.WriteLine(p.MostrarInformaciónProducto());
                }
                Console.Write("Introduzca el Id del producto a añadir: ");
                int id = int.Parse(Console.ReadLine());
                foreach (Producto p in listaProductos) //Se busca el producto que se desea cambiar
                {
                    if (id == p.Id)
                    {
                        Console.WriteLine("Hay " + p.Unidades + " de " + p.Nombre + ".");
                        Console.WriteLine("Cuantas unidades desea añadir?: ");
                        int cantidad = int.Parse(Console.ReadLine());

                        p.Unidades = p.Unidades + cantidad; //Se le suman las unidades indicadas

                        exito = true; //El producto se ha encontrado y cambiado con exito

                        Console.WriteLine("Producto modificado!");

                    }

                }
                if (exito == false) //Si ha surgido un error, salta el mensaje
                {
                    Console.WriteLine("Producto no encontrado.");
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

                    int id = listaProductos.Count;

                    switch (opcion) //Se añade el producto y se suma al contador para no superar el limite
                    {


                        case 1://Añadir Material Precioso
                            Console.WriteLine("Introduciendo Material Precioso...");
                            MaterialPrecioso mp = new MaterialPrecioso(id);
                            mp.SolicitarDetalles(); //Los detalles se solicitan en cada clase
                            listaProductos.Add(mp);
                            Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                            Contador++;
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        case 2://Añadir Producto Alimenticio
                            Console.WriteLine("Introduciendo Producto Alimenticio...");
                            ProductoAlimenticio pa = new ProductoAlimenticio(id);
                            pa.SolicitarDetalles();
                            listaProductos.Add(pa);
                            Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                            Contador++;
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        case 3://Añadir Producto Electronico
                            Console.WriteLine("Introduciendo Producto Electónico...");
                            ProductoElectronico pe = new ProductoElectronico(id);
                            pe.SolicitarDetalles();
                            listaProductos.Add(pe);
                            Console.WriteLine("SE HA AÑADIDO EL PRODUCTO!!!");
                            Contador++;
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

        public void CargarProductos() //Carga de texto a través de documento de texto
        {
            string separator = ";";
            string path = TextoSeleccionado;

            try
            {
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

                    //Se cubren las variables comunes
                    nombre = values[1];
                    unidades = int.Parse(values[2]);
                    preciounitario = double.Parse(values[3]);
                    descripcion = values[4];

                    if (Contador < 12) //En caso de llegar al limite, no añade más productos
                    {
                        //Y luego se cubren las especificas

                        if (int.Parse(values[0]) == 1) //Caso de que sea un material precioso 
                        {
                            materiales = values[5];
                            peso = values[6];

                            MaterialPrecioso mp = new MaterialPrecioso(id, nombre, unidades, preciounitario, descripcion, peso, materiales);
                            listaProductos.Add(mp);

                        }
                        else if (int.Parse(values[0]) == 2) //Caso de que se un producto alimentico
                        {
                            infoNutricional = values[7];

                            ProductoAlimenticio pa = new ProductoAlimenticio(id, nombre, unidades, preciounitario, descripcion, infoNutricional);
                            listaProductos.Add(pa);

                        }
                        else //Caso de que sea un producto electronico
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encuentra el archivo de contenidos: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }

        }

        public bool ComprobarUnidades(Producto c) //Comprueba si se pueden añadir más unidades
        {
            int contador = 0;
            bool retorno = true;

            foreach (Producto p in Carrito) //Recorre el carrito y busca todos los productos con el mismo id del producto añadir
            {
                if (p.Id == c.Id) // Si encuentra uno, suma la contador
                {
                    contador++;
                }
            }

            if(contador >= c.Unidades) //En caso de que en el carrito haya tantos productos como en la maquina, devuelve false
            {
                Console.WriteLine("Se ha excedido el limite de unidades de este producto, imposible añadirlo al carrito");
                retorno = false;
            }

            return retorno;

            
        }

    }
}
