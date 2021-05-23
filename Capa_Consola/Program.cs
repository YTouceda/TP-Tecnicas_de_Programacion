using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion=1;
            Entity.Usuario user = new Entity.Usuario();
            Entity.Cliente unCliente = new Entity.Cliente();
            Entity.OrdenDeVenta unaOrden = new Entity.OrdenDeVenta();
            List<Entity.DetalleOrden> detalles = new List<Entity.DetalleOrden>();
            Entity.Tarjeta unaTarjeta;
            BLL.TarjetaBLL objBLL = new BLL.TarjetaBLL();
            //Console.WriteLine("Eligir una opcion: \n\n1) Realizar una venta.\n\n0)Salir.\n\n");
            //opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Entity.Direccion dire = new Entity.Direccion("123", "calle", "1234", "Localidad", "provincia");
                unCliente.Direccion = dire;
                unCliente.Apellido = "perez";
                unCliente.DNI = 11111111;
                unCliente.Nombre = "Juan";
                unaOrden.Cliente = unCliente;
                unaOrden.UsuarioCreador = user;
                unaOrden.Detalles = detalles;
                //Console.WriteLine("\n\ningrese Metodo De Pago\n\n1)Tarjeta\n\n2)Efectivo\n\n");
                //opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    unaTarjeta = new Entity.Tarjeta("CVC", "fechaVencimiento", "nombreTarjeta", 1111111111);
                    if (objBLL.ValidarTarjeta(unaTarjeta))
                    {
                    unaOrden.MetodoDePago = unaTarjeta;
                    }
                }
            }

        }
    }
}
