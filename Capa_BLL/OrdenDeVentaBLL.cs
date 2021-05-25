using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace Capa_BLL
{
    public class OrdenDeVentaBLL
    {
        public bool GuardaOrdenVenta(OrdenDeVenta unaOrdendeVenta)
        {


            return OrdenDeVentaDAL.AltaDeVenta(unaOrdendeVenta);
        }



    }
}
