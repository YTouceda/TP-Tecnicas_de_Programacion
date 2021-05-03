using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Capa_BLL
{
	public class TarjetaBLL : MetodoDePagoBLL
	{
		private Tarjeta _tarjeta;
		public TarjetaBLL(string CVC, string fechaVencimiento, string nombreTarjeta, long numeroTarjeta)
		{
			_tarjeta = new Tarjeta(CVC, fechaVencimiento, nombreTarjeta, numeroTarjeta);
		}
		public TarjetaBLL()
        {
			_tarjeta = new Tarjeta();

		}

		public Tarjeta tarjetaBLL { get; set; }

		public virtual bool ValidarTarjeta()
		{
			if (this._tarjeta.CVC != null)
			{
				if ((this._tarjeta.NumeroTarjeta % 2) == 0)
				{
					return false;
				}
				return true;
			}
			else
			{
				return false;
			}
			
		}
		public override bool Validar()
		{
			base.Validar();
			return this.ValidarTarjeta();
		}

		public string ValidarVencimiento()
		{
			DateTime dt = DateTime.Now;
			String format = "M/yy";
			String date;
			date = dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
            dt.ToString(format, DateTimeFormatInfo.InvariantInfo);

			return date;


		}
	}
}
