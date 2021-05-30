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

namespace Capa_BLL
{
    class ClienteBLL
    {
        /// <summary>
        /// Devuelve un datatable desde la bbdd 
        /// </summary>
        /// <param name="Id_Cliente">Id del Cliente</param>
        public static DataTable BuscarCliente(int Id_Cliente)
        {
            ClienteDAL objClienteDAL = new ClienteDAL();
            if (objClienteDAL.BuscarClientes(Id_Cliente)!=null) 
            {

                DataTable objDataTable1 = objClienteDAL.BuscarClientes(Id_Cliente);
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
            objCliente.ID = (int)objDataTable.Rows[indice]["C.Id_Cliente"];
            objCliente.IDPersona = (int)objDataTable.Rows[indice]["P.Id_Persona"];
            objCliente.Nombre = (objDataTable.Rows[indice]["P.Nombre"].ToString());
            objCliente.Apellido = objDataTable.Rows[indice]["P.Apellido"].ToString();
            objCliente.DNI = objDataTable.Rows[indice]["P.Dni"].ToString();
            objDireccion.ID = (int)objDataTable.Rows[indice]["D.Id_direccion"];
            objDireccion.Calle = objDataTable.Rows[indice]["D.Calle"].ToString();
            objDireccion.Altura = objDataTable.Rows[indice]["D.Altura"].ToString();
            objDireccion.CodigoPostal = objDataTable.Rows[indice]["D.CodPostal"].ToString();
            objDireccion.Localidad = objDataTable.Rows[indice]["D.Localidad"].ToString();
            objDireccion.Provincia = objDataTable.Rows[indice]["D.Provincia"].ToString();
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
        public bool GuardarCliente(Cliente objCliente)
        {
            return ClienteDAL.Alta(objCliente);
        }
    }

}
