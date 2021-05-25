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
        public static bool Alta(Entity.Cliente pCliente)
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

        public static bool QueryModificarCliente(Entity.Cliente mCliente)
        {
            Conexion objconexion = new Conexion();
            string query = string.Format("UPDATE Direccion SET Altura = '{0}', Calle = '{1}', CodPostal = '{2}', Localidad = '{3}', Provincia = '{4}' WHERE Id_direccion = ",mCliente.Direccion.Altura,mCliente.Direccion.Calle,mCliente.Direccion.CodigoPostal,mCliente.Direccion.Localidad,mCliente.Direccion.Provincia) + mCliente.Direccion.Id_Direccion;
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
        public bool ComprobarCliente(int Id_Cliente)
        {
            bool salida=true;
            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT C.Id_Cliente, P.Id_Persona, P.Nombre, P.Apellido, P.Dni, D.Id_direccion, D.Calle, D.Altura, D.CodPostal,	D.Localidad, D.Provincia FROM Cliente C INNER JOIN Persona P ON C.Id_Persona = P.Id_Persona INNER JOIN Direccion D ON P.Id_direccion = D.Id_direccion WHERE P.Nombre = '{0}'", Id_Cliente);
            DataTable objDataTable = objConexion.LeerPorComando(query);
            if (Convert.ToInt32(objDataTable.Rows[0]["Id_Cliente"]) == Id_Cliente) 
            {
                salida = true;
            }
            else
            {
                salida = false;

            }

            return salida;
        }
        public DataTable BuscarClientes(int Id_Cliente) 
        {
            if (ComprobarCliente(Id_Cliente))
            {
                Conexion objConexion = new Conexion(); 

                string query = string.Format("SELECT Id_cliente , Id_Persona FROM Cliente");
                return objConexion.LeerPorComando(query);
                
            }
            return null;
        }



    }


}