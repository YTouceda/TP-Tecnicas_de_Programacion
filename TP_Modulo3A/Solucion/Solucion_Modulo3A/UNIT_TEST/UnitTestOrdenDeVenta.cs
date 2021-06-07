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
            string metodopago_esperado = "TARJETA";
            List<OrdenDeVenta> unaVenta = BLL.OrdenDeVentaBLL.GenerarReporteDeVentasPorMes(5);

            Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        }

        //[TestMethod]
        //public void TestGenerarReporteDeVentasPorSemana()
        //{
        //    string metodopago_esperado = "TARJETA";
        //    List<OrdenDeVenta> unaVenta = BLL.OrdenDeVentaBLL.GenerarReporteDeVentasPorSemana(5);

        //    Assert.AreEqual(metodopago_esperado, unaVenta[0].MetodoDePago.TipoMetodoDePago);

        //}

    }
}
