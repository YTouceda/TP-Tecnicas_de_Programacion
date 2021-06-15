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

            string query = string.Format("INSERT INTO direccion(calle,altura,localidad,codigo_postal,provincia)VALUES ('{0}','{1}','{2}','{3}','{4}')", pCliente.Direccion.Calle, pCliente.Direccion.Altura, pCliente.Direccion.Localidad, pCliente.Direccion.CodigoPostal, pCliente.Direccion.Provincia);

            if (objConexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }


            DataTable objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT ('direccion') AS id_direccion;");

            query = string.Format("INSERT INTO persona(apellido,nombre,dni,id_direccion)VALUES('{0}','{1}','{2}',{3})", pCliente.Apellido, pCliente.Nombre, pCliente.DNI, (objDataTable.Rows[0]["id_direccion"]));


            if (objConexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }

            objDataTable = objConexion.LeerPorComando("SELECT IDENT_CURRENT('persona') AS id_persona");

            query = string.Format("INSERT INTO cliente(id_persona) VALUES({0})", (objDataTable.Rows[0]["id_persona"]));


            if (objConexion.EscribirPorComando(query) == -1)
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


            string query = string.Format("UPDATE direccion SET calle = '{0}', altura = '{1}', localidad = '{2}', codigo_postal = '{3}', provincia = '{4}' WHERE id_dreccion = {5}", mCliente.Direccion.Calle, mCliente.Direccion.Altura, mCliente.Direccion.Localidad, mCliente.Direccion.CodigoPostal, mCliente.Direccion.Provincia, mCliente.Direccion.ID);

            if (objconexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }

 
            query = string.Format("UPDATE persona SET apellido = '{0}', nombre= '{1}', dni = '{2}' WHERE id_persona = ", mCliente.Apellido, mCliente.Nombre, mCliente.DNI) + mCliente.IDPersona;
          
            if (objconexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }

            return salida;
        }

        /// <summary>
        /// Busca un Cliente por DNI
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns>Retorna un DataTable si lo encontro o un null si no existe</returns>
        public static DataTable BuscarClientesPorDNI(string DNI)
        {

            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT C.id_cliente, P.id, P.nombre, P.apellido, P.dni, D.id, D.calle, D.altura, D.codigo_postal, D.localidad, D.provincia FROM cliente C INNER JOIN persona P ON C.id_cliente = P.id INNER JOIN direccion D ON P.id_direccion = D.id WHERE P.dni LIKE '%{0}%'", DNI);
            DataTable objDataTable = objConexion.LeerPorComando(query);
            if (objDataTable != null)
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