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
    


        public static DetalleOrden ConvertirDeDataTableADetalleOrden(DataRow objDataRow)
        {
            DetalleOrden unDetalle = new DetalleOrden();

            unDetalle.Producto.PrecioVenta = (float)objDataRow["P.PRECIO_VENTA"];
            unDetalle.Cantidad = Convert.ToInt32(objDataRow["O.USUARIO_CREADOR"]);
            unDetalle.Producto.Nombre = objDataRow["PRODUCTO"].ToString();

            return unDetalle;
        }
    }
}
