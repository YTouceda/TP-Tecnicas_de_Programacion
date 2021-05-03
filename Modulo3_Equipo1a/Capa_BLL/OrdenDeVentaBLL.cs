using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;

namespace Capa_BLL
{
    public class OrdenDeVentaBLL
    {
        private OrdenDeVenta _ordenDeVenta;
            
        public OrdenDeVenta ordenDeVentaBLL
        {
            get { return _ordenDeVenta; }
            set { _ordenDeVenta = value; }
        }


        public OrdenDeVentaBLL()
        {
            _ordenDeVenta = new OrdenDeVenta();
        }



    }
}
