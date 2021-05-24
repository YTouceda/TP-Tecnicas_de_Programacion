using System;
using System.Collections.Generic;
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
        public bool ComprobarCliente(Entity.Cliente pCliente)
        {
            bool salida=true;
            Conexion objConexion = new Conexion();
            
            string query = string.Format("SELECT Id_cliente , Id_Persona FROM Cliente");//TO DO comprobacion de si está o no el cliente en la bbdd
            if (Convert.ToInt32(query) == pCliente.IDPersona) {
                salida = true;
            }
            else
            {
                salida = false;

            }

            return salida;
        }



    }


}