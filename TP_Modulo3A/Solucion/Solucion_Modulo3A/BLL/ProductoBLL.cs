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
        /// Devuelve un lista de productos desde la bbdd 
        /// </summary>
        /// <param name="nombre">Nombre del producto</param>
        public static List<Producto> BuscarProducto(string nombre)
        {
            List<Producto> ListaProducto = new List<Producto>();//cero una lista de tipo Producto
            if (ProductoDAL.BuscarProducto(nombre) == null)
            {
                throw new Excepcion_ProductoNoEncontrado();

            }
            System.Data.DataTable objDataTable = ProductoDAL.BuscarProducto(nombre);//guardo el datatable que trajo de la bbdd
            foreach (DataRow row in objDataTable.Rows)//carga lo de data table a row(que es un data row)
            {

                ListaProducto.Add(ConvertirDeDataTableAObjProducto(row));//se agrega a ListaProducto un producto

            }



            return ListaProducto;//devuelve una lista

        }

        

        /// <summary>
        /// Convierte un datarow en un objeto producto
        /// </summary>
        /// <param name="objDatarow">Datarow</param>
        /// <returns>objeto producto </returns>
        private static Producto ConvertirDeDataTableAObjProducto(DataRow objDatarow) //recibe un datarow
        {
            Producto objProducto = new Producto();

            objProducto.Nombre = objDatarow["NOMBRE_PRODUCTO"].ToString();
            objProducto.ID = (int)objDatarow["ID_PRODUCTO"];
            objProducto.Categoria = new Categoria(objDatarow["CATEGORIA"].ToString());
            objProducto.PrecioCompra = Convert.ToSingle(objDatarow["PRECIO_COMPRA"]);
            objProducto.PrecioVenta = Convert.ToSingle(objDatarow["PRECIO_VENTA"]);
            objProducto.Stock = (int)objDatarow["STOCK"];
            return objProducto;
        }
    }
}