using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL;
using System.Data;
using ENTITY;
using DAL;


namespace UNIT_TEST
{
    [TestClass]
    public class UnitTestProducto
    {
        [TestMethod]
        public void TestConvertirDTAObjProducto()
        {
            string nombre_esperado = "Lavandina";
            DataTable objDataTable = BLL.ProductoBLL.BuscarProducto("Lavandina");

            Producto objProducto = BLL.ProductoBLL.ConvertirDeDataTableAObjProducto(objDataTable, 0);

            Assert.AreEqual(nombre_esperado, objProducto.Nombre);

        }
            
            

    }

       


    
}
