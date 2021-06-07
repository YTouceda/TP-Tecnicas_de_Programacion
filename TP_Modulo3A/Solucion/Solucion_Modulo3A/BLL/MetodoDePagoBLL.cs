using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;




namespace BLL
{
    public static class MetodoDePagoBLL
    {
        /// <summary>
        /// Devulve un metodo de pago ingresando una opcion numerica
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns>Retorna 0 Tarjeta de Credito, 1 Efectivo, sino arroja un Excepcion controlada</returns>
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
