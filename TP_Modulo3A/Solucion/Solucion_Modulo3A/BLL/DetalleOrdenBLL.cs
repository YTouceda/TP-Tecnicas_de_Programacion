using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.EXCEPCIONES;
using DAL;
using ENTITY;

namespace BLL
{
    public class DetalleOrdenBLL
    {
    /// <summary>
    /// Valida que haya stock de un producto.
    /// </summary>
    /// <param name="objProducto">Producto a agregar</param>
    /// <param name="cant">Cantidad</param>
    /// <returns>Retorna un objeto tipo "DetalleOrden"</returns>
        public DetalleOrden AgregarProducto(Producto objProducto, int cant)
        {
            if (objProducto.Stock >= cant)
            {
                DetalleOrden objDetalleOrden = new DetalleOrden();
                objDetalleOrden.Producto = objProducto;
                objDetalleOrden.Cantidad = cant;
                return objDetalleOrden;
            }
            throw new Excepcion_StockInsuficiente();
        }
    }
}
