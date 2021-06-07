using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL
{
    public class ClienteDAL
    {
        /// <summary>
        /// Da de alta un nuevo cliente
        /// </summary>
        /// <param name="pCliente">Objeto cliente</param>
        /// <returns>Retorna True si fue exitoso, False si hubo un error</returns>
        public static bool Alta(Cliente pCliente)
        {
            //ToDo:las funciones deben retornar true o false
            Conexion objConexion = new Conexion();
            bool salida = true;

            string query = string.Format("INSERT INTO DIRECCION(ALTURA,CALLE,CODIGO_POSTAL,LOCALIDAD,PROVINCIA)VALUES ('{0}','{1}','{2}','{3}','{4}')", pCliente.Direccion.Altura, pCliente.Direccion.Calle, pCliente.Direccion.CodigoPostal, pCliente.Direccion.Localidad, pCliente.Direccion.Provincia);

            if ( objConexion.EscribirPorComando(query)==-1)
            {
                salida = false;
                return salida;
            }
            
           
            DataTable objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT ('DIRECCION') AS ID_DIRECCION;");

            query = string.Format("INSERT INTO PERSONA(APELLIDO,DNI,NOMBRE,ID_DIRECCION)VALUES('{0}','{1}','{2}',{3})", pCliente.Apellido, pCliente.DNI, pCliente.Nombre, (objDataTable.Rows[0]["ID_DIRECCION"]));
            
            
            if (objConexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }

            objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT('PERSONA') AS ID_PERSONA");

            query =string.Format("INSERT INTO CLIENTE(ID_PERSONA) VALUES({0})", (objDataTable.Rows[0]["ID_PERSONA"]));
           
                      
            if (objConexion.EscribirPorComando( query ) == -1)
            {
                salida = false;
                return salida;
            }

            return salida;
     
        }

        /// <summary>
        /// Modifica un Cliente
        /// </summary>
        /// <param name="mCliente"></param>
        /// <returns>Retorna True si fue exitoso, False si hubo un error</returns>
        public static bool QueryModificarCliente(Cliente mCliente)
        {
            Conexion objconexion = new Conexion();
            bool salida = true;


            string query = string.Format("UPDATE DIRECCION SET ALTURA = '{0}', CALLE = '{1}', CODIGO_POSTAL = '{2}', LOCALIDAD = '{3}', PROVINCIA = '{4}' WHERE ID_DIRECCION = {0}",mCliente.Direccion.Altura,mCliente.Direccion.Calle,mCliente.Direccion.CodigoPostal,mCliente.Direccion.Localidad,mCliente.Direccion.Provincia) + mCliente.Direccion.ID;
            
            
            if (objconexion.EscribirPorComando(query)==-1)
            {
                salida = false;
                return salida;
            }

            query = string.Format("UPDATE Persona SET Apellido = '{0}', Dni = '{1}', Nombre = '{2}' WHERE Id_Persona = ",mCliente.Apellido,mCliente.DNI,mCliente.Nombre)+ mCliente.IDPersona;
           
            
            if (objconexion.EscribirPorComando(query)==-1)
            {
                salida = false;
                return salida;
            }

            return salida;
        }
        /// <summary>
        /// Comprueba si un cliente ya se encuentra en la base de datos.
        /// </summary>
        /// <param name="pCliente">objeto cliente</param>
        /// <returns></returns>
        public DataTable BuscarClientesPorID(int Id_Cliente) //ESTO SOLO DEBERIA COMPROBAR QUE EL CLIENTE NO ESTÉ EN LA BD , (PODRIA BUSCAR POR DNI).
        {
            
            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT C.ID_CLIENTE, P.ID_PERSONA, P.NOMBRE, P.APELLIDO, P.DNI, D.ID_DIRECCION, D.CALLE, D.ALTURA, D.CODIGO_POSTAL, D.LOCALIDAD, D.PROVINCIA FROM CLIENTE C INNER JOIN PERSONA P ON C.ID_PERSONA = P.ID_PERSONA INNER JOIN DIRECCION D ON P.ID_DIRECCION = D.ID_DIRECCION WHERE C.ID_CLIENTE = {0}", Id_Cliente);
            DataTable objDataTable = objConexion.LeerPorComando(query);
            if (Convert.ToInt32(objDataTable.Rows[0]["ID_CLIENTE"]) == Id_Cliente) 
            {
                return objDataTable;
            }
            else
            {
                return null;

            }

            
        }

        /// <summary>
        /// Busca un Cliente por DNI
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns>Retorna un DataTable si lo encontro o un null si no existe</returns>
        public DataTable BuscarClientesPorDNI(string DNI) //ESTO SOLO DEBERIA COMPROBAR QUE EL CLIENTE NO ESTÉ EN LA BD , (PODRIA BUSCAR POR DNI).
        {

            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT C.ID_CLIENTE, P.ID_PERSONA, P.NOMBRE, P.APELLIDO, P.DNI, D.ID_DIRECCION, D.CALLE, D.ALTURA, D.CODIGO_POSTAL, D.LOCALIDAD, D.PROVINCIA FROM CLIENTE C INNER JOIN PERSONA P ON C.ID_PERSONA = P.ID_PERSONA INNER JOIN DIRECCION D ON P.ID_DIRECCION = D.ID_DIRECCION WHERE P.DNI = '{0}'", DNI);
            DataTable objDataTable = objConexion.LeerPorComando(query);
            if ((objDataTable.Rows[0]["DNI"]).ToString() == DNI)
            {
                return objDataTable;
            }
            else
            {
                return null;

            }


        }



    }


}