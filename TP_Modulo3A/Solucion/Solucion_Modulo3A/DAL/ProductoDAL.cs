using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL_Modulo3
{
    public class ProductoDAL
    {
        public static DataTable BuscarProducto(string nombre)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("SELECT P.id_producto, P.nombre AS nombre_producto, P.precio_compra, P.precio_venta, P.stock, C.nombre AS categoria FROM producto P INNER JOIN categoria C ON P.id_categoria = C.ID_CATEGORIA WHERE P.NOMBRE LIKE '%{0}%'", nombre);

            if (objConexion.LeerPorComando(query) != null)
            {
                DataTable objDataTable = objConexion.LeerPorComando(query);
                return objDataTable;
            }
            return null; //Agregar excepcion (no se encontro el producto)
        }
    }
}