using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL;
using ENTITY;
using System.Collections.Generic;

namespace UNIT_TEST
{
    [TestClass]
    public class UnitTestOrdenDeVenta
    {
        [TestMethod]
        public void TestGenerarReporteDeVentasPorLegajo()
        {
            string metodopago_esperado = "TARJETA";
            List<OrdenDeVenta> unaVenta = BLL.OrdenDeVentaBLL.GenerarReporteDeVentasPorLegajo(1);

            Assert.AreEqual(metodopago_esperado, unaVenta[1].MetodoDePago.TipoMetodoDePago);

        }


        [TestMethod]
        public void TestGenerarReporteDeVentasPorMes()
        {
            string metodopago_esperado = "EFECTIVO";
            List<OrdenDeVenta> unaVenta = BLL.OrdenDeVentaBLL.GenerarReporteDeVentasPorMes(6,2005);

            Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        }

        [TestMethod]
        public void TestGenerarReporteDeVentasPorSemana()
        {
            string metodopago_esperado = "EFECTIVO";
            var fechatest = new DateTime(2005, 6, 5, 7, 0, 0);
            List<OrdenDeVenta> unaVenta = BLL.OrdenDeVentaBLL.GenerarReporteDeVentasPorSemana(fechatest);

            Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        }

    }
}
