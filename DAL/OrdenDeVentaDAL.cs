using Entity;
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
            string query = string.Format("INSERT INTO Orden(Fecha) VALUES("+ unaOrdendeVenta.Fecha + ")");
            objConexion.EscribirPorComando(query);
            query = string.Format("SELECT IDENT_CURRENT ('Orden') AS Id_Orden;");
            DataTable objDataTable = objConexion.LeerPorComando(query);


            //Guardamos la lista de detalles
            foreach (DetalleOrden item in unaOrdendeVenta.Detalles)
            {
                 query = string.Format("INSERT INTO Detalle_De_Orden(Id_producto,Cantidad,Id_Orden) VALUES("+ item.Producto.ID+","+item.Cantidad+(int)(objDataTable.Rows[0]["Id_Orden"])+")");

                 objConexion.EscribirPorComando(query);
            }
            
           
            




           if(objConexion.EscribirPorComando(query)!=1)
            {

                return true;
            }

            return false;//agregar excpecion
                    

        }
    }
}
