using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Modulo3.EXCEPCIONES;
using DAL_Modulo3;
using ENTITY;

namespace BLL_Modulo3
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

            objProducto.Nombre = objDatarow["nombre_producto"].ToString();
            objProducto.ID = (int)objDatarow["id_producto"];
            objProducto.Categoria = new Categoria(objDatarow["categoria"].ToString());
            objProducto.PrecioCompra = Convert.ToSingle(objDatarow["precio_compra"]);
            objProducto.PrecioVenta = Convert.ToSingle(objDatarow["precio_venta"]);
            objProducto.Stock = (int)objDatarow["stock"];
            return objProducto;
        }
    }
}