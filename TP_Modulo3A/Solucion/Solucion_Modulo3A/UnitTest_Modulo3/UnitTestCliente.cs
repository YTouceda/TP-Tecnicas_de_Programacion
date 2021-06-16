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
    public class UnitTestCliente
    {
        [TestMethod]
        public void TestConvertirDTAOBJCliente()
        {
            string apellido_esperado = "Perez";
            string nombre_esperado = "Damian";
            string calle_esperada = "Rosales";

            List<Cliente> ListaClientes = ClienteBLL.BuscarClientesPorDNI("3856");

            Assert.AreEqual(apellido_esperado, ListaClientes[0].Apellido);
            Assert.AreEqual(nombre_esperado, ListaClientes[0].Nombre);
            Assert.AreEqual(calle_esperada, ListaClientes[0].Direccion.Calle);
        }

        [TestMethod]
        public void TestModificarCliente()
        {

            bool bool_esperado = true;

            List<Cliente> Clientes = ClienteBLL.BuscarClientesPorDNI("38567566");

            Cliente objClienteNvo = Clientes[0];
            objClienteNvo.Nombre = "Damian";

            Assert.AreEqual(bool_esperado, ClienteBLL.ModificarUnCliente(Clientes[0], objClienteNvo));

        }
        [TestMethod]
        public void TestBuscarCliente()
        {
            string nombreEsperado = "Adrian";
            List<Cliente> Clientes = ClienteBLL.BuscarClientesPorDNI("22464657");
            Assert.AreEqual(nombreEsperado, Clientes[0].Nombre);
        }


    }
}