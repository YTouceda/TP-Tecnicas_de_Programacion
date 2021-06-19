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
        /// Devuelve una lista de productos desde la base de datos
        /// </summary>
        /// <param name="nombre">nombre del producto que se desee buscar</param>
        /// <returns>lista de productos que cumplen con el parametro de busqueda</returns>
        public static List<Producto> BuscarProducto(string nombre)
        {
            List<Producto> ListaProducto = new List<Producto>();//cero una lista de tipo Producto
            DataTable objDataTable = ProductoDAL.BuscarProducto(nombre);
            if ( objDataTable == null)
            {
                throw new Excepcion_ProductoNoEncontrado();

            }
            foreach (DataRow row in objDataTable.Rows)//carga lo de data table a row(que es un data row)
            {
                ListaProducto.Add(ConvertirDeDataTableAObjProducto(row));//se agrega a ListaProducto un producto
            }



            return ListaProducto;//devuelve una lista

        }

        

        /// <summary>
        /// Convierte un datarow en un objeto producto
        /// </summary>
        /// <param name="objDatarow">Datarow con los datos del producto</param>
        /// <returns>objeto producto </returns>
        private static Producto ConvertirDeDataTableAObjProducto(DataRow objDatarow) //recibe un datarow
        {
            Producto objProducto = new Producto();//instancio un objeto producto

            //Paso el datarow a objeto producto
            objProducto.Nombre = objDatarow["nombre_producto"].ToString();
            objProducto.ID = (int)objDatarow["id_producto"];
            objProducto.Categoria = new Categoria(objDatarow["categoria"].ToString());
            objProducto.PrecioCompra = Convert.ToSingle(objDatarow["precio_compra"]);
            objProducto.PrecioVenta = Convert.ToSingle(objDatarow["precio_venta"]);
            objProducto.Stock = (int)objDatarow["cantidad"];

            return objProducto;//devuelvo el objeto producto
        }
    }
}