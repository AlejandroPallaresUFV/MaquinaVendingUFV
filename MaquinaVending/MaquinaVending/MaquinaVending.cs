using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class MaquinaVending
    {
        protected List<Producto> listaProducto;
        public Usuario Usuario { get; set; }    //Usuario que manejara las funciones
        public MaquinaVending(Usuario usuario, List <Producto> productos) 
        { 
        
            Usuario = usuario;
            this.listaProducto = productos;
        }

        public void ComprarProductos() 
        {
            bool flag = false;

            while (flag ==  false)
            {
                foreach (Producto p in listaProducto)
                {
                    p.MostrarInformación();
                }

                Console.WriteLine("Introduce el Id del producto");
                int id = int.Parse(Console.ReadLine());
                Usuario.InsertarProducto(id);

                Console.WriteLine("Quiere introducir otro producto? \n Si = 1, No = 0");
                int flagDecision = int.Parse(Console.ReadLine());

                if(flagDecision == 0)
                {
                    flag = true;
                }
            }

            Pago pago = new Pago(Usuario);

            
            
        }

        public void MostrarInformación() 
        {
            
        }

        public void CargaIndividual() 
        {
            
        }

        public void CargaCompleta()
        {
            
        }

        public void Salir()
        {

        }

    }
}
