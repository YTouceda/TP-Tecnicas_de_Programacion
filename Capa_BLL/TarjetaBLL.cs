using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			if ((this._tarjeta.NumeroTarjeta % 2) == 0)
			{
				return false;
			}
			return true;
		}
		public override bool Validar()
		{
			base.Validar();
			return this.ValidarTarjeta();
		}

	}
}
