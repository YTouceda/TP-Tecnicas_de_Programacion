using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_Modulo3;
using BLL_Modulo3;
using BLL_Modulo3.EXCEPCIONES;
using ENTITY;

namespace BLL_Modulo3
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
            objCliente.ID = (int)objDataRow["id_cliente"];
            objCliente.IDPersona = (int)objDataRow["id_persona"];
            objCliente.Nombre = (objDataRow["nombre"].ToString());
            objCliente.Apellido = objDataRow["apellido"].ToString();
            objCliente.DNI = objDataRow["dni"].ToString();
            objDireccion.ID = (int)objDataRow["id_direccion"];
            objDireccion.Calle = objDataRow["calle"].ToString();
            objDireccion.Altura = objDataRow["altura"].ToString();
            objDireccion.CodigoPostal = objDataRow["codigo_postal"].ToString();
            objDireccion.Localidad = objDataRow["localidad"].ToString();
            objDireccion.Provincia = objDataRow["provincia"].ToString();
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
        public static bool GuardarCliente(Cliente objCliente)
        {
            return ClienteDAL.PersistirCliente(objCliente);
        }
    }

}