using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class OrdenDeVentaDAL
    {
        public static bool AltaDeVenta(OrdenDeVenta unaOrdendeVenta)
        {

            Conexion objConexion = new Conexion();
            string query = string.Format("INSERT INTO ORDEN(FECHA) VALUES("+ unaOrdendeVenta.Fecha + ")");
            

            if (objConexion.EscribirPorComando(query)!=1)
            {
                query = string.Format("SELECT IDENT_CURRENT ('ORDEN') AS ID_ORDEN;");
                DataTable objDataTable = objConexion.LeerPorComando(query);
                unaOrdendeVenta.ID = (int)(objDataTable.Rows[0]["ID_ORDEN"]);

                //Guardamos la lista de detalles
                foreach (DetalleOrden item in unaOrdendeVenta.Detalles)
                {
                        query = string.Format("INSERT INTO DETALLE_ORDEN(ID_PRODUCTO,CANTIDAD,ID_ORDEN) VALUES(" + item.Producto.ID + ","+item.Cantidad + unaOrdendeVenta.ID + ")");

                        objConexion.EscribirPorComando(query);
                }
            

            }
            if (unaOrdendeVenta.MetodoDePago.GetType() is ENTITY.Efectivo)
            {
                query = string.Format("INSERT INTO METODO_PAGO(TIPO) VALUES({0})", unaOrdendeVenta.MetodoDePago.TipoMetodoDePago);
                if (objConexion.EscribirPorComando(query) != 1)
                {
                    query = string.Format("SELECT IDENT_CURRENT ('METODO_PAGO') AS ID_METODO_PAGO;");
                    DataTable objDataTable = objConexion.LeerPorComando(query);
                }
            }

            query = string.Format("INSERT INTO ORDEN_VENTA (ID_ORDEN,ID_METODO_PAGO) VALUES({0},{1}) ",unaOrdendeVenta.ID,unaOrdendeVenta.MetodoDePago.ID);

            if(objConexion.EscribirPorComando(query)!=1)
            {
                return true;
            }

            return false;//agregar excpecion
                    

        }
    }
}
