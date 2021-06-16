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
            Conexion objConexion = new Conexion();
            int cantFilas = 0;

            SqlParameter[] parametros =
                {
                    new SqlParameter("@id_persona" ,SqlDbType.Int),
                    new SqlParameter("@apellido",SqlDbType.NVarChar,50),
                    new SqlParameter("@nombre",SqlDbType.NVarChar,50),
                    new SqlParameter("@dni",SqlDbType.Int),
                    new SqlParameter("@calle" ,SqlDbType.VarChar, 50),
                    new SqlParameter("@altura" ,SqlDbType.VarChar, 50),
                    new SqlParameter("@localidad" ,SqlDbType.VarChar, 50),
                    new SqlParameter("@codigo_postal",SqlDbType.VarChar,50),
                    new SqlParameter("@provincia",SqlDbType.VarChar,50),
                };

            //Asigno los valores
            parametros[0].Value = mCliente.ID;
            parametros[1].Value = mCliente.Apellido;
            parametros[2].Value = mCliente.Nombre;
            parametros[3].Value = Convert.ToInt32(mCliente.DNI);
            parametros[4].Value = mCliente.Direccion.Calle;
            parametros[5].Value = mCliente.Direccion.Altura;
            parametros[6].Value = mCliente.Direccion.Localidad;
            parametros[7].Value = mCliente.Direccion.CodigoPostal;
            parametros[8].Value = mCliente.Direccion.Provincia;
            cantFilas = objConexion.EscribirPorStoreProcedure("sp_editar_cliente", parametros);
            if (cantFilas != 2)
            {
                return true;
            }
            return true;
        }

        /// <summary>
        /// Busca un Cliente por DNI
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns>Retorna un DataTable si lo encontro o un null si no existe</returns>
        public static DataTable BuscarClientesPorDNI(string DNI)
        {

            Conexion objConexion = new Conexion();
            string query = string.Format("SELECT id_cliente ,nombre ,apellido ,dni ,calle ,altura ,localidad ,codigo_postal ,provincia FROM v_Cliente WHERE dni LIKE '{0}%'", DNI);
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