using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using System.Data;
using ENTITY;

namespace UNIT_TEST
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestAgregarCliente
    {
       
      
        [TestMethod]
        public void TestMethod1()
        {
            //Agregar cliente

    
            Direccion unaDireccion = new Direccion("1234", "Calle Falsa", "123", "esprinfield", "sasara");

            Cliente unCliente = new Cliente();
            unCliente.Nombre = "Homero";
            unCliente.Apellido = "Simpson";
            unCliente.DNI = "14852741";
            unCliente.Direccion = unaDireccion;
           

            Assert.AreEqual(true, ClienteBLL.GuardarCliente(unCliente));


        }
    }
}
