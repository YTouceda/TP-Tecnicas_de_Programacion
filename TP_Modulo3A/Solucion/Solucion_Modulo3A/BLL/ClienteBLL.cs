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
using BLL.EXCEPCIONES;

namespace BLL_Modulo3
{
    public class ClienteBLL
    {
        /// <summary>
        /// Trae desde la base de datos el o los clientes que tengan el numero de DNI o parte del numero del DNI que se esta buscando
        /// </summary>
        /// <param name="DNI">Numero de DNI completo o el comienzo del numero que se desea buscar</param>
        /// <returns>devuelve una lista con los clientes que cumplan con el parametro de busqueda</returns>
        public static List<Cliente> BuscarClientesPorDNI(string DNI)
        {
            List<Cliente> ListaClientes = new List<Cliente>();//instancio la lista
            DataTable objDataTable = ClienteDAL.BuscarClientesPorDNI(DNI);//Busco el o los clientes
            if (objDataTable == null)//Verifico que devuelva un cliente
            {
                throw new Excepcion_ClienteInexistente();//En caso de que sea null lanzo una excepcion
            }
            else//caso contrario
            {
                foreach (DataRow row in objDataTable.Rows)
                {
                    ListaClientes.Add(ConvertirDeDataTableAObjCliente(row));//paso todos los clientes a objeto cliente y los agrego a la lista
                }
                return ListaClientes;//devuelvo la lista de clientes
            }

        }

        /// <summary>
        /// Convierte un DataRow en un objeto Cliente.
        /// </summary>
        /// <param name="objDataRow">DataRow</param>
        /// <returns>devuelve un objeto clientes</returns>
        public static Cliente ConvertirDeDataTableAObjCliente(DataRow objDataRow)
        {
            Cliente objCliente = new Cliente();//instancio un objeto cliente
            objCliente.Direccion = new Direccion();//instancio un objeto direccion dentro de cliente, para poder pasar los datos

            //le paso los datos del DataRow al objeto cliente
            objCliente.ID = (int)objDataRow["id_cliente"];
            objCliente.Nombre = (objDataRow["nombre"].ToString());
            objCliente.Apellido = objDataRow["apellido"].ToString();
            objCliente.DNI = objDataRow["dni"].ToString();
            objCliente.Direccion.Calle = objDataRow["calle"].ToString();
            objCliente.Direccion.Altura = objDataRow["altura"].ToString();
            objCliente.Direccion.CodigoPostal = objDataRow["codigo_postal"].ToString();
            objCliente.Direccion.Localidad = objDataRow["localidad"].ToString();
            objCliente.Direccion.Provincia = objDataRow["provincia"].ToString();

            return objCliente;//devuelvo un objeto cliente

        }

        /// <summary>
        /// Modifica un cliente existente y lo guarda los cambios dentro de la base de datos
        /// </summary>
        /// <param name="objCliente">objeto Cliente el cual se requiere modificar</param>
        /// <param name="objDatosNuevos">objeto Cliente con los datos modificados</param>
        /// <returns>True si se realizo de forma correcta la modificacion</returns>
        public static bool ModificarUnCliente(Cliente objCliente, Cliente objDatosNuevos)
        {
                                                                                                     ////
            objCliente.Nombre = objDatosNuevos.Nombre;                                                 //
            objCliente.Apellido = objDatosNuevos.Apellido;                                             //
            objCliente.DNI = objDatosNuevos.DNI;                                                       //
            objCliente.Direccion.Calle = objDatosNuevos.Direccion.Calle;                               //Preguntar: Por que pasa los datos al pedo, puede 
            objCliente.Direccion.Altura = objDatosNuevos.Direccion.Altura;                             //hacer el update directamente desde el objDatosNuevos
            objCliente.Direccion.CodigoPostal = objDatosNuevos.Direccion.CodigoPostal;                 //
            objCliente.Direccion.Localidad = objDatosNuevos.Direccion.Localidad;                       //
            objCliente.Direccion.Provincia = objDatosNuevos.Direccion.Provincia;                       //
                                                                                                     ////

            if(!(ClienteDAL.QueryModificarCliente(objCliente))) //Verifico si se pudo modificar el cliente
            {
                throw new Excepcion_ErrorAlModificarCliente();
            }
            return true;
        }

        /// <summary>
        /// Almacena un Cliente en la base de datos
        /// </summary>
        /// <param name="objCliente">Objeto Cliente que se desea almacenar en la base de datos</param>
        /// <returns>Devuelve true si se pudo guardar en la base de datos</returns>
        public static bool GuardarCliente(Cliente objCliente)
        {
            if (!(ClienteDAL.PersistirCliente(objCliente)))
            {
                throw new Excepcion_NoSePudoGuardarCliente();
            }
            return true;
        }
    }

}