using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL;
using System.Data;
using ENTITY;
using DAL;
using System.Collections.Generic;

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
            List<Producto> ListaProducto= BLL.ProductoBLL.BuscarProducto("Lavandina");//pasa por parametros el producto a buscar y devuelve una lista de productos

            Producto objProducto = ListaProducto[0];

            Assert.AreEqual(nombre_esperado, objProducto.Nombre);

        }
            
            

    }

       


    
}
