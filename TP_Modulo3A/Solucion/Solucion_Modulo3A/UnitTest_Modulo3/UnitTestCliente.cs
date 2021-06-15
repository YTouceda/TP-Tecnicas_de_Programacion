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
            string apellido_esperado = "Fulanito";
            string nombre_esperado = "Cosme";
            string calle_esperada = "Calle Falsa";

            List<Cliente> ListaClientes = ClienteBLL.BuscarClientesPorDNI("36933120");

            Assert.AreEqual(apellido_esperado, ListaClientes[0].Apellido);
            Assert.AreEqual(nombre_esperado, ListaClientes[0].Nombre);
            Assert.AreEqual(calle_esperada, ListaClientes[0].Direccion);


        }

        [TestMethod]
        public void TestModificarCliente()
        {
            int clientes_esperados = 3;
            bool bool_esperado = true;

            List<Cliente> Clientes = ClienteBLL.BuscarClientesPorDNI("3");

            Cliente objClientenvo = Clientes[1];
            objClientenvo.Nombre = "Pepe";
            objClientenvo.Apellido = "Rodriguez";




            Assert.AreEqual(clientes_esperados, Clientes.Count);
            Assert.AreEqual(bool_esperado, ClienteBLL.ModificarUnCliente(Clientes[1], objClientenvo));

        }


    }
}