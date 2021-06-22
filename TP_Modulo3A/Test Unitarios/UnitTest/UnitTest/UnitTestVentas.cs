using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades;
using BLL_Modulo3;

namespace UnitTest
{
    /// <summary>
    /// Descripción resumida de UnitTestVentas
    /// </summary>
    [TestClass]
    public class UnitTestVentas
    {


        [TestMethod]
        public void TestGuardarVenta()

        {
            bool datoEsperado = true;
            DetalleOrden unDetalleOrden = new DetalleOrden();
            OrdenDeVenta objOrdenDeVenta = new OrdenDeVenta();
            List<Producto> ListaProducto = ProductoBLL.BuscarProducto("Vino");
            List<DetalleOrden> ListaDetalles = new List<DetalleOrden>();
            Efectivo objEfectivo = new Efectivo();
            Usuario unUSuario = new Usuario();
            Producto objProducto = ListaProducto[0];
            unDetalleOrden.Producto = objProducto;
            unDetalleOrden.Cantidad = 2;
            ListaDetalles.Add(unDetalleOrden);
            objOrdenDeVenta.Detalles = ListaDetalles;

            objOrdenDeVenta.MetodoDePago = objEfectivo;
            List<Cliente> Clientes = ClienteBLL.BuscarClientesPorDNI("38567566");

            Cliente ObjCliente = Clientes[0];
            objOrdenDeVenta.Cliente = ObjCliente;

            unUSuario.ID = 1;
            objOrdenDeVenta.UsuarioCreador = unUSuario;
            Assert.AreEqual(datoEsperado, VentaBLL.GuardaOrdenVenta(objOrdenDeVenta));
        }

        [TestMethod]
        public void TestGuardarVenta2()

        {
            bool datoEsperado = true;
            DetalleOrden unDetalleOrden = new DetalleOrden();
            OrdenDeVenta objOrdenDeVenta = new OrdenDeVenta();
            List<Producto> ListaProducto = ProductoBLL.BuscarProducto("Vino");
            List<DetalleOrden> ListaDetalles = new List<DetalleOrden>();
            Tarjeta objTarjeta = new Tarjeta();
            Usuario unUSuario = new Usuario();

            objTarjeta.CVC = "121";
            objTarjeta.FechaVencimiento = "1/1/2022";
            objTarjeta.NumeroTarjeta = "9898989898989899";
            objTarjeta.NombreTarjeta = "Denis Lemes";
            Producto objProducto = ListaProducto[0];
            unDetalleOrden.Producto = objProducto;
            unDetalleOrden.Cantidad = 2;

            ListaDetalles.Add(unDetalleOrden);
            objOrdenDeVenta.Detalles = ListaDetalles;

            objOrdenDeVenta.MetodoDePago = objTarjeta;
            List<Cliente> Clientes = ClienteBLL.BuscarClientesPorDNI("23564500");

            Cliente ObjCliente = Clientes[0];
            objOrdenDeVenta.Cliente = ObjCliente;

            unUSuario.ID = 1;
            objOrdenDeVenta.UsuarioCreador = unUSuario;
            Assert.AreEqual(datoEsperado, VentaBLL.GuardaOrdenVenta(objOrdenDeVenta));
        }



    }
}