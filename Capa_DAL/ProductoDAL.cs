using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class ProductoDAL
    {
        public static DataTable BuscarProducto(string nombre)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("SELECT P.Id_producto, P.Nombre AS Nombre_Producto, P.PrecioCompra, P.PrecioVenta, P.Stock , C.Nombre AS Nombre_Categoria FROM Producto P INNER JOIN Categoria C ON P.Id_Categoria = C.Id_Categoria WHERE P.Nombre = '{0}'", nombre);

            if (objConexion.LeerPorComando(query)!=null)
            {
            DataTable objDataTable = objConexion.LeerPorComando(query);
                return objDataTable;
            }
            return null; //Agregar excepcion (no se encontro el producto)
        }
    }
}
