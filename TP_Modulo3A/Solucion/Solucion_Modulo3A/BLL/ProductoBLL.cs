using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.EXCEPCIONES;
using DAL;
using ENTITY;

namespace BLL
{
    public class ProductoBLL
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

            objProducto.Nombre = objDataTable.Rows[indice]["NOMBRE_PRODUCTO"].ToString();
            objProducto.ID = (int)objDataTable.Rows[indice]["ID_PRODUCTO"];
            objProducto.Categoria = new Categoria(objDataTable.Rows[indice]["CATEGORIA"].ToString());
            objProducto.PrecioCompra = Convert.ToSingle( objDataTable.Rows[indice]["PRECIO_COMPRA"]);
            objProducto.PrecioVenta = Convert.ToSingle(objDataTable.Rows[indice]["PRECIO_VENTA"]);
            //objProducto.Stock = (int)objDataTable.Rows[indice]["P.Stock"]; //REVISAR ESTO 
            return objProducto;
        }
    }
}
