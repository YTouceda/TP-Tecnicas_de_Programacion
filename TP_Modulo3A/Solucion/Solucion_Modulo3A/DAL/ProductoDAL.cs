using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class ProductoDAL 
    {
        public static DataTable BuscarProducto(string nombre)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("SELECT P.ID_PRODUCTO, P.NOMBRE AS NOMBRE_PRODUCTO, P.PRECIO_COMPRA, P.PRECIO_VENTA, P.STOCK, C.NOMBRE AS CATEGORIA FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA WHERE P.NOMBRE LIKE '%{0}%'", nombre);

            if (objConexion.LeerPorComando(query)!=null)
            {
            DataTable objDataTable = objConexion.LeerPorComando(query);
                return objDataTable;
            }
            return null; //Agregar excepcion (no se encontro el producto)
        }
    }
}
