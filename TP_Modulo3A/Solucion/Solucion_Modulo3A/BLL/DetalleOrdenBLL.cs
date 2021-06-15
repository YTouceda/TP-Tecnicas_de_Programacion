using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Modulo3.EXCEPCIONES;
using DAL;
using ENTITY;

namespace BLL_Modulo3
{
    public class DetalleOrdenBLL
    {
    


        public static DetalleOrden ConvertirDeDataTableADetalleOrden(DataRow objDataRow)
        {
            DetalleOrden unDetalle = new DetalleOrden();

            unDetalle.Producto.PrecioVenta = (float)objDataRow["p.precio_venta"];
            unDetalle.Cantidad = Convert.ToInt32(objDataRow["o._usuario_creador"]);
            unDetalle.Producto.Nombre = objDataRow["producto"].ToString();

            return unDetalle;
        }
    }
}
