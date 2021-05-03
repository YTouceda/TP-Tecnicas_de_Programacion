using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;
using Entidades;
using Capa_BLL;

namespace Capa_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion=1;
            Usuario user = new Usuario();
            Cliente unCliente = new Cliente();
            OrdenDeVentaBLL unaOrden;
            List<DetalleOrden> detalles = new List<DetalleOrden>();
            TarjetaBLL unaTarjeta;
            //Console.WriteLine("Eligir una opcion: \n\n1) Realizar una venta.\n\n0)Salir.\n\n");
            //opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Direccion dire = new Direccion("123", "calle", "1234", "Localidad", "provincia");
                unCliente.Direccion = dire;
                unCliente.Apellido = "perez";
                unCliente.DNI = 11111111;
                unCliente.Nombre = "Juan";
                unaOrden = new OrdenDeVentaBLL();
                unaOrden.ordenDeVentaBLL.Cliente = unCliente;
                unaOrden.ordenDeVentaBLL.UsuarioCreador = user;
                unaOrden.ordenDeVentaBLL.Detalles = detalles;
                //Console.WriteLine("\n\ningrese Metodo De Pago\n\n1)Tarjeta\n\n2)Efectivo\n\n");
                //opcion = int.Parse(Console.ReadLine());
                if (opcion==1)
                {
                    unaTarjeta = new TarjetaBLL("CVC", "fechaVencimiento", "nombreTarjeta", 1111111112);
                    if (unaTarjeta.Validar()) 
                    {
                    unaOrden.ordenDeVentaBLL.MetodoDePago = unaTarjeta.tarjetaBLL ;
                    }
                }
            }

        }
    }
}
