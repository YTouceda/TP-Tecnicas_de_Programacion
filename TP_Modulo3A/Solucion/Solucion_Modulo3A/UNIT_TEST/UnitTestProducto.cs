using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL_Modulo3;
using System.Data;
using ENTITY;
using DAL_Modulo3;
using System.Collections.Generic;
using Xunit.Sdk;

namespace UNIT_TEST
{
    [TestClass]
    public class UnitTestProducto
    {


        /// <summary>
        /// prueba crear una lista de clientes
        /// </summary>
        [TestMethod]
        public void TestConvertirDTAObjProducto()
        {
            string nombre_esperado = "Lavandina";
            List<Producto> ListaProducto = ProductoBLL.BuscarProducto("Lavandina");//pasa por parametros el producto a buscar y devuelve una lista de productos

            Producto objProducto = ListaProducto[0];

            Assert.AreEqual(nombre_esperado, objProducto.Nombre);

        }



    }





}