using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL;
using System.Data;
using ENTITY;
using DAL;


namespace UNIT_TEST
{
    //[TestClass]
    //public class UnitTestCliente
    //{
    //    [TestMethod]
    //    public void TestConvertirDTAOBJCliente()
    //    {
    //        string apellido_esperado = "Fulanito";
    //        string nombre_esperado = "Cosme";
    //        string calle_esperada = "Calle Falsa";
           
    //        DataTable DTCliente = ClienteBLL.BuscarClientesPorDNI("36933120");

    //        Cliente ObjCliente = ClienteBLL.ConvertirDeDataTableAObjCliente(DTCliente, 0);


    //        Assert.AreEqual(apellido_esperado,ObjCliente.Apellido);
    //        Assert.AreEqual(nombre_esperado, ObjCliente.Nombre);
    //        Assert.AreEqual(calle_esperada, ObjCliente.Direccion.Calle);


    //    }

    //    [TestMethod]
    //    public void TestModificarCliente()
    //    {

           
    //        DataTable DTCliente = ClienteBLL.BuscarClientesPorID(1);

    //        Cliente ObjCliente = ClienteBLL.ConvertirDeDataTableAObjCliente(DTCliente, 0);

            
    //        Cliente AuxCliente = ObjCliente;
    //        AuxCliente.Nombre = "Cosme";

    //        ClienteBLL.ModificarUnCliente(ObjCliente, AuxCliente);


    //    }

      
    //}
}
