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
        /// <returns></returns>
        public static bool Alta(Cliente pCliente)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("INSERT INTO Direccion(Altura,Calle,CodPostal,Localidad,Provincia)VALUES ('{0}','{1}','{2}','{3}','{4}')", pCliente.Direccion.Altura, pCliente.Direccion.Calle, pCliente.Direccion.CodigoPostal, pCliente.Direccion.Localidad, pCliente.Direccion.Provincia);
            objConexion.EscribirPorComando(query);
            DataTable objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT ('Direccion') AS Id_Direccion;");
            
            query = string.Format("INSERT INTO Persona(Apellido,Dni,Nombre,Id_direccion)VALUES('{0}','{1}','{2}'", pCliente.Apellido, pCliente.DNI, pCliente.Nombre) + "," + (int)(objDataTable.Rows[0]["Id_Direccion"]) + ")";
            objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT('Persona') AS Id_Persona");

            query =string.Format("INSERT INTO Cliente(Id_Persona) VALUES({0})", (int)(objDataTable.Rows[0]["Id_Persona"]));
            objConexion.EscribirPorComando( query );



            return true;
     
        }

        public static bool QueryModificarCliente(Cliente mCliente)
        {
            Conexion objconexion = new Conexion();
            string query = string.Format("UPDATE DIRECCION SET ALTURA = '{0}', CALLE = '{1}', CODIGO_POSTAL = '{2}', LOCALIDAD = '{3}', PROVINCIA = '{4}' WHERE ID_DIRECCION = {0}",mCliente.Direccion.Altura,mCliente.Direccion.Calle,mCliente.Direccion.CodigoPostal,mCliente.Direccion.Localidad,mCliente.Direccion.Provincia) + mCliente.Direccion.ID;
            objconexion.EscribirPorComando(query);
            query = string.Format("UPDATE Persona SET Apellido = '{0}', Dni = '{1}', Nombre = '{2}' WHERE Id_Persona = ",mCliente.Apellido,mCliente.DNI,mCliente.Nombre)+ mCliente.IDPersona;
            objconexion.EscribirPorComando(query);
            return true;
        }
        /// <summary>
        /// Comprueba si un cliente ya se encuentra en la base de datos.
        /// </summary>
        /// <param name="pCliente">objeto cliente</param>
        /// <returns></returns>
        public bool ComprobarCliente(int Id_Cliente) //ESTO SOLO DEBERIA COMPROBAR QUE EL CLIENTE NO ESTÉ EN LA BD , (PODRIA BUSCAR POR DNI).
        {
            bool salida=true;
            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT C.ID_CLIENTE, P.ID_PERSONA, P.NOMBRE, P.APELLIDO, P.DNI, D.ID_DIRECCION, D.CALLE, D.ALTURA, D.CODIGO_POSTAL, D.LOCALIDAD, D.PROVINCIA FROM CLIENTE C INNER JOIN PERSONA P ON C.ID_PERSONA = P.ID_PERSONA INNER JOIN DIRECCION D ON P.ID_DIRECCION = D.ID_DIRECCION WHERE C.ID_CLIENTE = '{0}'", Id_Cliente);
            DataTable objDataTable = objConexion.LeerPorComando(query);
            if (Convert.ToInt32(objDataTable.Rows[0]["ID_CLIENTE"]) == Id_Cliente) 
            {
                salida = true;
            }
            else
            {
                salida = false;

            }

            return salida;
        }
        
        public DataTable BuscarClientes(int Id_Cliente) //le agregamos al select los datos faltantes
        {
            if (ComprobarCliente(Id_Cliente))
            {
                Conexion objConexion = new Conexion(); 

                string query = string.Format("SELECT C.ID_CLIENTE, P.ID_PERSONA, P.NOMBRE, P.APELLIDO, P.DNI, D.ID_DIRECCION, D.CALLE, D.ALTURA, D.CODIGO_POSTAL, D.LOCALIDAD, D.PROVINCIA FROM CLIENTE C INNER JOIN PERSONA P ON C.ID_PERSONA = P.ID_PERSONA INNER JOIN DIRECCION D ON P.ID_DIRECCION = D.ID_DIRECCION WHERE C.ID_CLIENTE = '{0}'", Id_Cliente);
                return objConexion.LeerPorComando(query);
                
            }
            return null;
        }



    }


}