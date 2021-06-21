using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL_Modulo3;
using ENTITY;
using System.Collections.Generic;

namespace UNIT_TEST_Modulo3
{
    [TestClass]
    public class UnitTestOrdenDeVenta
    {
        [TestMethod]
        public void TestGenerarReporteDeVentasPorLegajo()
        {
            string metodopago_esperado = "Tarjeta";
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorLegajo(1);

            Assert.AreEqual(metodopago_esperado, unaVenta[1].MetodoDePago.TipoMetodoDePago);

        }


        [TestMethod]
        public void TestGenerarReporteDeVentasPorMes()
        {
            string metodopago_esperado = "Efectivo";
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorMes(6, 2021);

            Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        }

        [TestMethod]
        public void TestGenerarReporteDeVentasPorSemana()
        {
            string metodopago_esperado = "Efectivo";
            var fechatest = new DateTime(2021, 6, 17, 0, 0, 0);
            List<OrdenDeVenta> unaVenta = VentaBLL.GenerarReporteDeVentasPorSemana(fechatest);

            Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        }

    }
}