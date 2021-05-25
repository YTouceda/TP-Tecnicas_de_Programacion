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
            

            if (objConexion.EscribirPorComando(query)!=1)
            {
                 query = string.Format("SELECT IDENT_CURRENT ('Orden') AS Id_Orden;");
                 DataTable objDataTable = objConexion.LeerPorComando(query);
                unaOrdendeVenta.ID_Orden = (int)(objDataTable.Rows[0]["Id_Orden"]);

                //Guardamos la lista de detalles
                foreach (DetalleOrden item in unaOrdendeVenta.Detalles)
                {
                        query = string.Format("INSERT INTO Detalle_De_Orden(Id_producto,Cantidad,Id_Orden) VALUES("+ item.Producto.ID+","+item.Cantidad+unaOrdendeVenta.ID_Orden+")");

                        objConexion.EscribirPorComando(query);
                }
            

            }


            query = string.Format("INSERT INTO Metodo_De_Pago(Tipo) VALUES({0})",unaOrdendeVenta.MetodoDePago.TipoMetodoDePago);

           if(objConexion.EscribirPorComando(query)!=1)
            {
                query = string.Format("SELECT IDENT_CURRENT ('Metodo_De_Pago') AS Id_MetodoDePago;");
                DataTable objDataTable = objConexion.LeerPorComando(query);
                unaOrdendeVenta.MetodoDePago.ID_MetodoDePago = (int)(objDataTable.Rows[0]["Id_MetodoDePago"]);
                if (unaOrdendeVenta.MetodoDePago.TipoMetodoDePago=="Tarjeta" )
                    {
                                                       
                    query = string.Format("INSERT INTO Tarjeta(CVC,FechaVecimiento,NombreDeTarjeta,NroDeTarjeta,Id_MetodoDePago) VALUES('{0}','{1}','{2}',{3},{4} ) ","Tarjeta","12/26","Visa",544545,1);//hard code para luego implementar
                    

                    }

            }



            query = string.Format("INSERT INTO [OrdenDe Venta](Id_Orden,Id_MetodoDePago,Id_Cliente) VALUES({0},{1},{2}) ",unaOrdendeVenta.ID_Orden,);



           if(objConexion.EscribirPorComando(query)!=1)
            {

                return true;
            }

            return false;//agregar excpecion
                    

        }
    }
}
