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
    public class UnitTestCliente
    {
        [TestMethod]
        public void TestConvertirDTAOBJCliente()
        {
            string apellido_esperado = "Fulanito";
            string nombre_esperado = "Cosme";
            string calle_esperada = "Calle Falsa";

            List<Cliente> ListaClientes = BLL.ClienteBLL.BuscarClientesPorDNI("36933120");

            Assert.AreEqual(apellido_esperado, ListaClientes[0].Apellido);
            Assert.AreEqual(nombre_esperado, ListaClientes[0].Nombre);
            Assert.AreEqual(calle_esperada, ListaClientes[0].Direccion);


        }

        //[TestMethod]
        //public void TestModificarCliente()
        //{

           
        //    DataTable DTCliente = ClienteBLL.BuscarClientesPorID(1);

        //    Cliente ObjCliente = ClienteBLL.ConvertirDeDataTableAObjCliente(DTCliente, 0);

            
        //    Cliente AuxCliente = ObjCliente;
        //    AuxCliente.Nombre = "Cosme";

        //    ClienteBLL.ModificarUnCliente(ObjCliente, AuxCliente);


        //}

      
    }
}
