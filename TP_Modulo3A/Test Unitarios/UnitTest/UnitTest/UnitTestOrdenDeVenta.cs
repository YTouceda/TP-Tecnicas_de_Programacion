using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL_Modulo3;
using System.Collections.Generic;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class UnitTestOrdenDeVenta
    {
        [TestMethod]
        public void TestGenerarReporteDeVentasPorLegajo()
        {
            Efectivo objEfectivo = new Efectivo();
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorLegajo(1);

            Assert.AreEqual(objEfectivo.GetType(), unaVenta[1].MetodoDePago.GetType());

        }


        [TestMethod]
        public void TestGenerarReporteDeVentasPorMes()
        {
            Efectivo objEfectivo = new Efectivo();
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorMes(6, 2021);

            Assert.AreEqual(objEfectivo.GetType(), unaVenta[0].MetodoDePago.GetType());

        }

        [TestMethod]
        public void TestGenerarReporteDeVentasPorSemana()
        {
            Efectivo objEfectivo = new Efectivo();
            var fechatest = new DateTime(2021, 6, 17, 0, 0, 0);
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorSemana(fechatest);

            Assert.AreEqual(objEfectivo.GetType(), unaVenta[0].MetodoDePago.GetType());

        }

    }
}