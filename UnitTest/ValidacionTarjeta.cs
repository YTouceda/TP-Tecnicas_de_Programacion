using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capa_BLL;
using General;
using Entidades;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class ValidacionTarjeta
    {
        /// <summary>
        /// Prueba que la validacion de la tarjeta sea correcta respondiendo a lo pedido (impar aprobada , par desaprobada).
        /// </summary>
        [TestMethod]
        public void ValidacionTarjetaTest()
        {
            bool validacionesperada = true;
            Usuario user = new Usuario();
            OrdenDeVenta unaOrden;
            List<DetalleOrden> detalles = new List<DetalleOrden>();
            Direccion unaDireccion = new Direccion("1300", "Alem", "1842", "Ezeiza", "Buenos Aires");
            Cliente unCliente = new Cliente();
            unCliente = new Cliente(/*"Lopez", unaDireccion, 39999999, "Denis"*/);
            unCliente.Direccion = unaDireccion;
            unCliente.Apellido = "Lopez";
            unCliente.DNI = 39999999;
            unCliente.Nombre = "Denis";
            TarjetaBLL unaTarjeta = new TarjetaBLL();
            unaTarjeta.CVC="123";
            unaTarjeta.FechaVencimiento="3/27";
            unaTarjeta.NombreTarjeta="Visa";
            unaTarjeta.NumeroTarjeta = 5000566598897845;
            unaTarjeta.Validar();

            Assert.AreEqual(validacionesperada,unaTarjeta.Validar());


        }
        /// <summary>
        /// Simula una venta con el cliente instanciado pero no tiene asignado un valor.(nombre)
        /// </summary>
        [TestMethod]
        public void ValidarTarjetaSinCliente()
        {
            
            string nombreesperado = "Denis";
            Usuario user = new Usuario();
            OrdenDeVenta unaOrden = new OrdenDeVenta();

            List<DetalleOrden> detalles = new List<DetalleOrden>();
            Direccion unaDireccion = new Direccion("1300", "Alem", "1842", "Ezeiza", "Buenos Aires");
            Cliente unCliente = new Cliente();
            //unCliente = new Cliente(/*"Lopez", unaDireccion, 39999999, "Denis"*/);
            //unCliente.Direccion = unaDireccion;
            //unCliente.Apellido = "Lopez";
            //unCliente.DNI = 39999999;
            //unCliente.Nombre = "Denis";
            TarjetaBLL unaTarjeta = new TarjetaBLL();
            unaTarjeta.CVC = "123";
            unaTarjeta.FechaVencimiento = "3/27";
            unaTarjeta.NombreTarjeta = "Visa";
            unaTarjeta.NumeroTarjeta = 5000566598897845;
            if (unaTarjeta.Validar())
            {
                unaOrden.MetodoDePago = unaTarjeta;
            }

            Assert.AreEqual(nombreesperado,unCliente.Nombre);



        }
        /// <summary>
        /// Prueba la validacion de tarjeta sin haberle asignado un numero de tarjeta.
        /// </summary>
        [TestMethod]
        public void ValidarTarjetaSinNumeroAsignado()
        {
           
            long numesperado= 5000566598897845;
            Usuario user = new Usuario();
            OrdenDeVenta unaOrden = new OrdenDeVenta();

            List<DetalleOrden> detalles = new List<DetalleOrden>();
            Direccion unaDireccion = new Direccion("1300", "Alem", "1842", "Ezeiza", "Buenos Aires");
            Cliente unCliente = new Cliente();
            unCliente = new Cliente();
            unCliente.Direccion = unaDireccion;
            unCliente.Apellido = "Lopez";
            unCliente.DNI = 39999999;
            unCliente.Nombre = "Denis";
            TarjetaBLL unaTarjeta = new TarjetaBLL();
            unaTarjeta.CVC = "123";
            unaTarjeta.FechaVencimiento = "3/27";
            unaTarjeta.NombreTarjeta = "Visa";
            
            if (unaTarjeta.Validar())
            {
                unaOrden.MetodoDePago = unaTarjeta;
            }

            Assert.AreEqual(numesperado,unaTarjeta.NumeroTarjeta);



        }
        /// <summary>
        /// prueba la validacion de tarjeta sin haber instanciado una tarjeta
        /// </summary>
        [TestMethod]
        public void ValidarTarjetaSinTarjeta()
        {
            bool validacionesperada = true;
            long numesperado = 5000566598897845;
            Usuario user = new Usuario();
            OrdenDeVenta unaOrden = new OrdenDeVenta();

            List<DetalleOrden> detalles = new List<DetalleOrden>();
            Direccion unaDireccion = new Direccion("1300", "Alem", "1842", "Ezeiza", "Buenos Aires");
            Cliente unCliente = new Cliente();
            unCliente = new Cliente();
            unCliente.Direccion = unaDireccion;
            unCliente.Apellido = "Lopez";
            unCliente.DNI = 39999999;
            unCliente.Nombre = "Denis";
            TarjetaBLL unaTarjeta = new TarjetaBLL();
            /*
            unaTarjeta.CVC = "123";
            unaTarjeta.FechaVencimiento = "3/27";
            unaTarjeta.NombreTarjeta = "Visa";
            */

            if (unaTarjeta.Validar())
            {
                unaOrden.MetodoDePago = unaTarjeta;
            }

            Assert.AreEqual(validacionesperada, unaTarjeta.Validar());



        }
    }
}
