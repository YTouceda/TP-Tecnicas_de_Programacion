using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_Modulo3
{
    class DetalleOrdenDAL
    {
        /// <summary>
        /// Guarda todos los detalles de una misma orden de venta en la base de datos
        /// </summary>
        /// <param name="detalles">Objeto List<DetalleOrden> </param>
        /// <param name="idOrden">Id de la orden a la que pertenecen los detalles</param>
        /// <returns>True si se pudo guardar. Si no lanza excepcion</returns>
        public static bool GuardarDetalles(List<DetalleOrden> detalles, int idOrden)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@cantidad",SqlDbType.Int),
                new SqlParameter("@idOrden",SqlDbType.Int),
                new SqlParameter("@idProducto",SqlDbType.Int),
            };
            Conexion objConexion = new Conexion();
            foreach (var item in detalles)
            {
                parametros[0].Value = item.Cantidad;
                parametros[1].Value = idOrden;
                parametros[2].Value = item.Producto.ID;
                if (objConexion.EscribirPorStoreProcedure("sp_almacenar_detalle", parametros) != 1)
                {
                    throw new Exception();//Agregar excepcion
                }
            }
            return true;
        }
    }
}