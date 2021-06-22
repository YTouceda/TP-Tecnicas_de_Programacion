using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL_Modulo3;
using System.Data;
using System.Collections.Generic;
using Entidades;

namespace UnitTest
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
            List<Producto> ListaProducto = ProductoBLL.BuscarProducto("Lavan");//pasa por parametros el producto a buscar y devuelve una lista de productos

            Producto objProducto = ListaProducto[0];

            Assert.AreEqual(nombre_esperado, objProducto.Nombre);

        }



    }





}