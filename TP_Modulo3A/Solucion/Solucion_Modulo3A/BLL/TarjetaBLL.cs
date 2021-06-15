using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.EXCEPCIONES;

namespace BLL
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
		public static bool ValidarTarjeta(ENTITY.Tarjeta pTarjeta)
		{
			long numTarj=Convert.ToInt64(pTarjeta.NumeroTarjeta);
			if ((numTarj % 2) == 0)
			{
				throw new Excepcion_TarjetaInvalida();
			}
			return true;
		}
	}
}
