using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BLL
{
	public class TarjetaBLL
	{
		public TarjetaBLL()
        {

        }
		/// <summary>
		/// Valida si se puede utilizar la Tarjeta para realizar una venta.
		/// Numero de tarjeta par (se rechaza)  
		/// Numero de tarjeta impar (se autoriza)
		/// </summary>
		/// <param name="pTarjeta"> Del tipo Entity.Tarjeta</param>
		/// <returns>Devuelve un bool</returns>
		public static bool ValidarTarjeta(Tarjeta pTarjeta)
		{
			if ((pTarjeta.NumeroTarjeta % 2) == 0)
			{
				return false;
			}
			return true;
		}
	}
}
