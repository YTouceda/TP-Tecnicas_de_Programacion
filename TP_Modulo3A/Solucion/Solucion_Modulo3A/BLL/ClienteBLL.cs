using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BLL;
using BLL.EXCEPCIONES;
using ENTITY;
using System.Data;

namespace BLL
{
    public class ClienteBLL
    {
        /// <summary>
        /// Devuelve una lista de clientes
        /// </summary>
        /// <param name="DNI" DNI del Cliente</param>
        public static List<Cliente> BuscarClientesPorDNI(string DNI)
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            DataTable objDataTable = ClienteDAL.BuscarClientesPorDNI(DNI);
            if (objDataTable == null)
            {
                throw new Excepcion_ClienteInexistente();

            }

            else
            {
               
                foreach (DataRow row in objDataTable.Rows)
                {
                    ListaClientes.Add(ConvertirDeDataTableAObjCliente(row));

                }
                return ListaClientes;

            }

        }

        /// <summary>
        /// Convierte una fila del datatable en un objeto Cliente con todos los datos completos.
        /// </summary>
        /// <param name="objDataTable">DataTable</param>
        /// <param name="indice">indice de la fila </param>
        /// <returns>objeto Cliente(segun la fila)</returns>
        public static Cliente ConvertirDeDataTableAObjCliente(DataRow objDataRow)
        {
            Cliente objCliente = new Cliente();
            Direccion objDireccion = new Direccion();
            objCliente.ID = (int)objDataRow["ID_CLIENTE"];
            objCliente.IDPersona = (int)objDataRow["ID_PERSONA"];
            objCliente.Nombre = (objDataRow["NOMBRE"].ToString());
            objCliente.Apellido = objDataRow["APELLIDO"].ToString();
            objCliente.DNI = objDataRow["DNI"].ToString();
            objDireccion.ID = (int)objDataRow["ID_DIRECCION"];
            objDireccion.Calle = objDataRow["CALLE"].ToString();
            objDireccion.Altura = objDataRow["ALTURA"].ToString();
            objDireccion.CodigoPostal = objDataRow["CODIGO_POSTAL"].ToString();
            objDireccion.Localidad = objDataRow["LOCALIDAD"].ToString();
            objDireccion.Provincia = objDataRow["PROVINCIA"].ToString();
            objCliente.Direccion = objDireccion;
            return objCliente;

        }

        /// <summary>
        /// modifica un cliente
        /// </summary>
        /// <param name="objCliente">Cliente a modificar</param>
        /// <param name="objDatosNuevos">objCliente con los datos nuevos</param>
        /// <returns>Cliente modificado</returns>
        public static bool ModificarUnCliente(Cliente objCliente, Cliente objDatosNuevos)
        {


            objCliente.Nombre = objDatosNuevos.Nombre;
            objCliente.Apellido = objDatosNuevos.Apellido;
            objCliente.DNI = objDatosNuevos.DNI;
            objCliente.Direccion.Calle = objDatosNuevos.Direccion.Calle;
            objCliente.Direccion.Altura = objDatosNuevos.Direccion.Altura;
            objCliente.Direccion.CodigoPostal = objDatosNuevos.Direccion.CodigoPostal;
            objCliente.Direccion.Localidad = objDatosNuevos.Direccion.Localidad;
            objCliente.Direccion.Provincia = objDatosNuevos.Direccion.Provincia;


            if(ClienteDAL.QueryModificarCliente(objCliente))
            {
                return true;

            }
            throw new Excepcion_ErrorAlModificarCliente();

        }
        /// <summary>
        /// almacena un Cliente en la base de datos
        /// </summary>
        /// <param name="objCliente">Cliente objCliente</param>
        /// <returns>devuelve true si se pudo guardar en la base de datos</returns>
        public bool GuardarCliente(Cliente objCliente)
        {
            return ClienteDAL.Alta(objCliente);
        }
    }

}