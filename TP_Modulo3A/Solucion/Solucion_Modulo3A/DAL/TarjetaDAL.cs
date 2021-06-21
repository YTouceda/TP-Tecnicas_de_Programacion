using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class TarjetaDAL
    {
        public static bool GuardarTarjeta(Tarjeta unaTarjeta)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("INSERT INTO METODO_PAGO(TIPO) VALUES({0})", "Tarjeta");

            if (objConexion.EscribirPorComando(query) != 1)
            {
                query = string.Format("SELECT IDENT_CURRENT ('METODO_PAGO') AS ID_METODO_PAGO;");
                DataTable objDataTable = objConexion.LeerPorComando(query);
                unaTarjeta.ID = (int)(objDataTable.Rows[0]["ID_METODO_PAGO"]);

                query = string.Format("INSERT INTO Tarjeta(CVC,FECHA_VENCIMIENTO,NOMBRE_TARJETA,NUMERO_TARJETA,ID_METODO_PAGO) VALUES('{0}','{1}','{2}',{3},{4})", unaTarjeta.CVC, unaTarjeta.FechaVencimiento, unaTarjeta.NombreTarjeta, unaTarjeta.NumeroTarjeta, unaTarjeta.ID);
                if (objConexion.EscribirPorComando(query) != 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
