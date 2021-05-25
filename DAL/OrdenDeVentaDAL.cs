using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdenDeVentaDAL
    {
        public static bool AltaDeVenta(OrdenDeVenta unaOrdendeVenta)
        {

            Conexion unConexion = new Conexion();

            //Guardamos la lista de detalles
            foreach (DetalleOrden item in unaOrdendeVenta.Detalles)
            {
                 string query = string.Format("INSERT INTO Detalle_De_Orden(Id_producto,Cantidad) VALUES("+ item.Producto.ID+","+item.Cantidad+")");

                 unConexion.EscribirPorComando(query);
            }
            
           
            




           if(unConexion.EscribirPorComando(query)!=1)
            {

                return true;
            }

            return false;//agregar excpecion
                    

        }
    }
}
