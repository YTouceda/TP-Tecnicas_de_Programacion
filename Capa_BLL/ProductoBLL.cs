using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_BLL.Excepciones;
using DAL;
using Entity;

namespace Capa_BLL
{
    class ProductoBLL
    {
        /// <summary>
        /// Devuelve un datatable desde la bbdd 
        /// </summary>
        /// <param name="nombre">Nombre del producto</param>
        public static DataTable BuscarProducto(string nombre)
        {
            if (ProductoDAL.BuscarProducto(nombre) == null)
            {
                throw new Excepcion_ProductoNoEncontrado();

            }

            System.Data.DataTable objDataTable = ProductoDAL.BuscarProducto(nombre);
            

            return objDataTable;

        }
        /// <summary>
        /// Convierte una fila del datatable en un objeto producto
        /// </summary>
        /// <param name="objDataTable">DataTable</param>
        /// <param name="indice">indice de la fila </param>
        /// <returns>objeto producto (segun la fila)</returns>
        public static Producto ConvertirDeDataTableAObjProducto(DataTable objDataTable, int indice)
        {
            Producto objProducto = new Producto();

            objProducto.Nombre = objDataTable.Rows[indice]["Nombre_Producto"].ToString();
            objProducto.ID = (int)objDataTable.Rows[indice]["P.Id_Producto"];
            objProducto.Categoria = new Categoria(objDataTable.Rows[indice]["Nombre_Categoria"].ToString());
            objProducto.PrecioCompra = (float)objDataTable.Rows[indice]["P.PrecioCompra"];
            objProducto.PrecioVenta = (float)objDataTable.Rows[indice]["P.PrecioVenta"];
            objProducto.Stock = (int)objDataTable.Rows[indice]["P.Stock"];
            return objProducto;
        }
    }
}
