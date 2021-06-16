using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL_Modulo3;
using System.Data;
using ENTITY;
using DAL_Modulo3;
using System.Collections.Generic;

namespace UNIT_TEST_Modulo3
{
    [TestClass]
    public class UnitTestProducto
    {


        /// <summary>
        /// prueba crear una lista de clientes
        /// </summary>
        [TestMethod]
        public void TestBuscarProducto()
        {
            string nombre_esperado = "Lavandina";
            List<Producto> ListaProducto = ProductoBLL.BuscarProducto("vandi");//pasa por parametros el producto a buscar y devuelve una lista de productos

            Producto objProducto = ListaProducto[0];

            Assert.AreEqual(nombre_esperado, objProducto.Nombre);

        }



    }





}