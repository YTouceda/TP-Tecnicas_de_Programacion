using DAL_Modulo3;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL_Modulo3
{
    public class ClienteDAL
    {
        /// <summary>
        /// Da de alta un nuevo cliente
        /// </summary>
        /// <param name="pCliente">Objeto cliente</param>
        /// <returns>Retorna True si fue exitoso, False si hubo un error</returns>
        public static bool PersistirCliente(Cliente pCliente)
        {
            Conexion objConexion = new Conexion();
            //creo todos los parametros que necesita el procedimiento almacenado 
            SqlParameter[] parametros =
            {
                new SqlParameter("@calle",SqlDbType.NVarChar ,50),
                new SqlParameter("@altura",SqlDbType.NVarChar,50),
                new SqlParameter("@localidad",SqlDbType.NVarChar,50),
                new SqlParameter("@codigo_postal",SqlDbType.NVarChar,50),
                new SqlParameter("@provincia",SqlDbType.NVarChar,50),
                new SqlParameter("@apellido",SqlDbType.NVarChar,50),
                new SqlParameter("@nombre",SqlDbType.NVarChar,50),
                new SqlParameter("@dni", SqlDbType.Int)
            };

            //Se le asignan valores a los parametros
            parametros[0].Value = pCliente.Direccion.Calle;
            parametros[1].Value = pCliente.Direccion.Altura;
            parametros[2].Value = pCliente.Direccion.Localidad;
            parametros[3].Value = pCliente.Direccion.CodigoPostal;
            parametros[4].Value = pCliente.Direccion.Provincia;
            parametros[5].Value = pCliente.Apellido;
            parametros[6].Value = pCliente.Nombre;
            parametros[7].Value = pCliente.DNI;

            if (objConexion.EscribirPorStoreProcedure("sp_almacenar_cliente", parametros) != 3)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Recibe un objeto cliente con los datos modificados que se desean actualizar en la base de datos
        /// </summary>
        /// <param name="mCliente"></param>
        /// <returns>Retorna True si fue exitoso, False si hubo un error</returns>
        public static bool QueryModificarCliente(Cliente mCliente)
        {
            Conexion objconexion = new Conexion();
            bool salida = true;


            string query = string.Format("UPDATE direccion SET altura = '{0}', calle = '{1}', codigo_postal = '{2}', localidad = '{3}', provincia = '{4}' WHERE id_dreccion = {5}", mCliente.Direccion.Altura, mCliente.Direccion.Calle, mCliente.Direccion.CodigoPostal, mCliente.Direccion.Localidad, mCliente.Direccion.Provincia, mCliente.Direccion.ID);


            if (objconexion.EscribirPorComando(query) == -1)
            {
                salida = false;
                return salida;
            }

            query = string.Format("UPDATE persona SET apellido = '{0}', dni= '{1}', nombre = '{2}' WHERE id_persona = ", mCliente.Apellido, mCliente.DNI, mCliente.Nombre) + mCliente.ID;


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
            string query = string.Format("SELECT C.id_cliente, P.nombre, P.apellido, P.dni, D.id, D.calle, D.altura, D.codigo_postal, D.localidad, D.provincia FROM cliente C INNER JOIN persona P ON C.id_cliente = P.id INNER JOIN direccion D ON P.id_direccion = D.id WHERE P.dni = {0}", DNI);
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