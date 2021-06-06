using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ENTITY;
using BLL;
using System.Data;

namespace UNIT_TEST
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
            List<Producto> ListaProducto = BLL.ProductoBLL.BuscarProducto("Lavandina");

            Producto objProducto = ListaProducto[0];
            unDetalleOrden.Producto = objProducto;
            unDetalleOrden.Cantidad = 2;
            objOrdenDeVenta.Detalles.Add(unDetalleOrden);
            
            objOrdenDeVenta.MetodoDePago.TipoMetodoDePago = "Efectivo";
            DataTable DTCliente = ClienteBLL.BuscarClientesPorID(1);
            
            Cliente ObjCliente = ClienteBLL.ConvertirDeDataTableAObjCliente(DTCliente, 0);
            objOrdenDeVenta.Cliente = ObjCliente;


            Assert.AreEqual(datoEsperado, OrdenDeVentaBLL.GuardaOrdenVenta(objOrdenDeVenta));
        }
    }
}
