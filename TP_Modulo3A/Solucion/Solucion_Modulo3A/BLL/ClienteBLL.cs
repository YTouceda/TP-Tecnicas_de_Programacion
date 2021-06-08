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

namespace BLL
{
    public class ClienteBLL
    {
        /// <summary>
        /// Devuelve un datatable desde la bbdd 
        /// </summary>
        /// <param name="Id_Cliente">Id del Cliente</param>
        public static DataTable BuscarClientesPorID(int Id_Cliente)
        {
            ClienteDAL objClienteDAL = new ClienteDAL();
            if (objClienteDAL.BuscarClientesPorID(Id_Cliente)!=null) 
            {

                DataTable objDataTable1 = objClienteDAL.BuscarClientesPorID(Id_Cliente);
                return objDataTable1;
            }
             else   
            {
                throw new Excepcion_ClienteInexistente();

            }

        }

        /// <summary>
        /// Busca un Cliente por DNI
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns>Retorna un Datatable si lo encuentra o una excepcion si no</returns>
        public static DataTable BuscarClientesPorDNI(string DNI)
        {
            ClienteDAL objClienteDAL = new ClienteDAL();
            if (objClienteDAL.BuscarClientesPorDNI(DNI) != null)
            {

                DataTable objDataTable1 = objClienteDAL.BuscarClientesPorDNI(DNI);
                return objDataTable1;
            }

            {
                throw new Excepcion_ClienteInexistente();

            }

        }
        /// <summary>
        /// Convierte una fila del datatable en un objeto Cliente con todos los datos completos.
        /// </summary>
        /// <param name="objDataTable">DataTable</param>
        /// <param name="indice">indice de la fila </param>
        /// <returns>objeto Cliente(segun la fila)</returns>
        public static Cliente ConvertirDeDataTableAObjCliente(DataTable objDataTable, int indice)
        {
            Cliente objCliente = new Cliente();
            Direccion objDireccion = new Direccion();
            objCliente.ID = (int)objDataTable.Rows[indice]["ID_CLIENTE"];
            objCliente.IDPersona = (int)objDataTable.Rows[indice]["ID_PERSONA"];
            objCliente.Nombre = (objDataTable.Rows[indice]["NOMBRE"].ToString());
            objCliente.Apellido = objDataTable.Rows[indice]["APELLIDO"].ToString();
            objCliente.DNI = objDataTable.Rows[indice]["DNI"].ToString();
            objDireccion.ID = (int)objDataTable.Rows[indice]["ID_DIRECCION"];
            objDireccion.Calle = objDataTable.Rows[indice]["CALLE"].ToString();
            objDireccion.Altura = objDataTable.Rows[indice]["ALTURA"].ToString();
            objDireccion.CodigoPostal = objDataTable.Rows[indice]["CODIGO_POSTAL"].ToString();
            objDireccion.Localidad = objDataTable.Rows[indice]["LOCALIDAD"].ToString();
            objDireccion.Provincia = objDataTable.Rows[indice]["PROVINCIA"].ToString();
            objCliente.Direccion = objDireccion;
            return objCliente;

        }

        /// <summary>
        /// modifica un cliente
        /// </summary>
        /// <param name="objCliente">Cliente a modificar</param>
        /// <param name="objDatosNuevos">objCliente con los datos nuevos</param>
        /// <returns>Cliente modificado</returns>
        public static Cliente ModificarUnCliente(Cliente objCliente,Cliente objDatosNuevos)
        {
            
            
            objCliente.Nombre = objDatosNuevos.Nombre;
            objCliente.Apellido = objDatosNuevos.Apellido;
            objCliente.DNI = objDatosNuevos.DNI;
            objCliente.Direccion.Calle = objDatosNuevos.Direccion.Calle;
            objCliente.Direccion.Altura = objDatosNuevos.Direccion.Altura;
            objCliente.Direccion.CodigoPostal = objDatosNuevos.Direccion.CodigoPostal;
            objCliente.Direccion.Localidad = objDatosNuevos.Direccion.Localidad;
            objCliente.Direccion.Provincia = objDatosNuevos.Direccion.Provincia;
            ClienteDAL.QueryModificarCliente(objCliente);
            return objCliente;

        }  
        /// <summary>
        /// almacena un Cliente en la base de datos
        /// </summary>
        /// <param name="objCliente">Cliente objCliente</param>
        /// <returns>devuelve true si se pudo guardar en la base de datos</returns>
        public static bool GuardarCliente(Cliente objCliente)
        {
            return ClienteDAL.Alta(objCliente);
        }
    }

}
