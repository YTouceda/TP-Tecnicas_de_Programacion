using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAL
{
    public class OrdenDeVentaDAL
    {
        

        public static DataTable BuscarVentasPorLegajo(int legajo)
        {
            Conexion objConexion = new Conexion();

            SqlParameter[] parametros =
            {
                new SqlParameter("@LEGAJO",SqlDbType.Int)
                
               };

            parametros[0].Value = legajo;
            
            

            DataTable objDataTable = objConexion.LeerPorStoreProcedure("REPORTEVENTASPORLEGAJO",parametros);
            if ((int)objDataTable.Rows[0]["LEGAJO_VENDEDOR"] == legajo) 
            {
                return objDataTable;
            }
            else
            {
                return null;

            }

        }
        /// <summary>
        /// Busca ventas en la base de datos segun el mes que reciba por parametro usando el store procedure REPORTEVENTASPORMES
        /// </summary>
        /// <param name="mes">Numero de mes</param>
        /// <returns>Devuelve un DataTable con el reporte de ventas.</returns>
        public static DataTable BuscarVentasPorMes(int mes)
        {
            Conexion objConexion = new Conexion();

            SqlParameter[] parametros =
            {
                new SqlParameter("@MES",SqlDbType.Int)

               };

            parametros[0].Value = mes;



            DataTable objDataTable = objConexion.LeerPorStoreProcedure("REPORTEVENTASPORMES", parametros);
            if (Convert.ToDateTime( objDataTable.Rows[0]["FECHA"]).Month == mes)
            {
                return objDataTable;
            }
            else
            {
                return null;

            }

        }

        /// <summary>
        /// Busca Ventas en una semana (falta confirmar parte del funcionamiento)
        /// </summary>
        /// <param name="semana"></param>
        /// <returns></returns>
        public static DataTable BuscarVentasPorSemana(int semana)
        {
            Conexion objConexion = new Conexion();

            SqlParameter[] parametros =
            {
                new SqlParameter("@SEMANA",SqlDbType.Int)

               };

            parametros[0].Value = semana;



            DataTable objDataTable = objConexion.LeerPorStoreProcedure("REPORTEVENTASPORSEMANA", parametros);
            if ((Convert.ToDateTime(objDataTable.Rows[0]["FECHA"]).DayOfYear)/7 == semana)
            {
                return objDataTable;
            }
            else
            {
                return null;

            }

        }

        /// <summary>
        /// Guarda una orden de venta en la base de datos.
        /// </summary>
        /// <param name="unaOrdenDeVenta">Objeto OrdenDeVenta</param>
        /// <returns>True si se persistio la venta. Si no lanza excepcion</returns>
        public static bool PersistirVenta(OrdenDeVenta unaOrdenDeVenta)
        {
            Conexion objConexion = new Conexion();
            SqlParameter[] parametros =
            {
                new SqlParameter("@tipoMetodoDePago" ,SqlDbType.VarChar, 50),
                new SqlParameter("@legajo",SqlDbType.Int),
                new SqlParameter("@fecha",SqlDbType.DateTime),
                new SqlParameter("@cvc" ,SqlDbType.VarChar, 50),
                new SqlParameter("@fechaVencimiento" ,SqlDbType.VarChar, 50),
                new SqlParameter("@nombreTarjeta" ,SqlDbType.VarChar, 50),
                new SqlParameter("@nroTarjeta",SqlDbType.VarChar,16),
            };
            parametros[0].Value = unaOrdenDeVenta.MetodoDePago.TipoMetodoDePago;
            parametros[1].Value = unaOrdenDeVenta.UsuarioCreador.Legajo;
            parametros[2].Value = unaOrdenDeVenta.Fecha;
            Tarjeta unaTarjeta = new Tarjeta();
            if (unaOrdenDeVenta.MetodoDePago.GetType() == unaTarjeta.GetType())
            {
                unaTarjeta = (Tarjeta)unaOrdenDeVenta.MetodoDePago;
                parametros[3].Value = unaTarjeta.CVC;
                parametros[4].Value = unaTarjeta.FechaVencimiento;
                parametros[5].Value = unaTarjeta.NombreTarjeta;
                parametros[6].Value = unaTarjeta.NumeroTarjeta;
            }
            else
            {
                parametros[3].Value = "-";
                parametros[4].Value = "-";
                parametros[5].Value = "-";
                parametros[6].Value = 0;
            }
            int cantFilas = objConexion.EscribirPorStoreProcedure("sp_ALMACENAR_VENTA", parametros);
            string query = "SELECT IDENT_CURRENT ('ORDEN') AS ID_ORDEN";
            DataTable objDataTable = objConexion.LeerPorComando(query);
            int idOrden = Convert.ToInt32(objDataTable.Rows[0]["ID_ORDEN"]);
            if((!DetalleOrdenDAL.GuardarDetalles(unaOrdenDeVenta.Detalles,idOrden))|| cantFilas < 3 || cantFilas > 4) 
            {

                //PREGUNTAR Que pasa si se guarda una orden de venta y no los detalles ( por algun error) 
                return false;
                
                
            }

            return true;
        }

    }

}
