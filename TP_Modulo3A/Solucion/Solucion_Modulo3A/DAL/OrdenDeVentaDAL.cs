using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class OrdenDeVentaDAL
    {
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
                new SqlParameter("@nroTarjeta",SqlDbType.Int),
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
                parametros[3].Value = null;
                parametros[4].Value = null;
                parametros[5].Value = null;
                parametros[6].Value = null;
            }
            int cantFilas = objConexion.EscribirPorStoreProcedure("sp_ALMACENAR_VENTA", parametros);
            string query = "SELECT IDENT_CURRENT ('ORDEN') AS ID_ORDEN";
            DataTable objDataTable = objConexion.LeerPorComando(query);
            DetalleOrdenDAL.GuardarDetalles(unaOrdenDeVenta.Detalles, (int)objDataTable.Rows[0]["ID_ORDEN"]);
            if ( cantFilas < 3 || cantFilas > 4)
            {
                throw new Exception();//Agregar Excepcion
            }
            return true;
        }
    }
}
