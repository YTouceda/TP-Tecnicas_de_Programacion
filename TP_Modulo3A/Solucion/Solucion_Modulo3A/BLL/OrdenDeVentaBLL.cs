using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;

namespace BLL
{
    public class OrdenDeVentaBLL
    {
        /// <summary>
        /// Guarda una Venta se debe ingresar un Orden de Venta
        /// </summary>
        /// <param name="unaOrdendeVenta"></param>
        /// <returns>Retorna un Objeto OrdenDeVentaDAL</returns>
        public static bool GuardaOrdenVenta(OrdenDeVenta unaOrdendeVenta)
        {
            return OrdenDeVentaDAL.AltaDeVenta(unaOrdendeVenta);
        }



    }
}
