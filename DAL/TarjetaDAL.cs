using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class TarjetaDAL
    {
        public static MetodoDePago GuardarTarjeta(Tarjeta unaTarjeta)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("INSERT INTO Tarjeta(CVC,FechaVecimiento,NombreDeTarjeta,NroDeTarjeta,Id_MetodoDePago) VALUES('{0}','{1}','{2}',{3},{4})",unaTarjeta);


            return unaTarjeta;
        }
    }
}
