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
        public bool Alta(Entity.Cliente pCliente)
        {
            Conexion objConexion = new Conexion();
            string query = string.Format("INSERT INTO Cliente(Id_Persona) VALUES({0})", pCliente.IDPersona);
            objConexion.EscribirPorComando( query );



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