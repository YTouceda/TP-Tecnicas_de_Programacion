using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;




namespace BLL
{
    public static class MetodoDePagoBLL
    {
        public static MetodoDePago DevolverMetodoDePago(int opcion)
        {
            if (opcion == 0)
            {
                MetodoDePago metodo = new Tarjeta();
                return metodo;
            }
            if (opcion == 1)
            {
                MetodoDePago metodo = new Efectivo();
                return metodo;
            }
            else
            {
                 throw new Exception ("Error: Opcion ingresada no valida");
            }
        }
    }
}
