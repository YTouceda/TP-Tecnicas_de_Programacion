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
            string query = string.Format("INSERT INTO ORDEN(FECHA) VALUES("+ unaOrdendeVenta.Fecha + ", " + unaOrdendeVenta.UsuarioCreador.Legajo + ")");
            
        }
    }
}
