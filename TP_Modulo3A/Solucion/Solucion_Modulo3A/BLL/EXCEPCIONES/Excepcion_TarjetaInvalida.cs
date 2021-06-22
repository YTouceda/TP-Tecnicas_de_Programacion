using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_TarjetaInvalida : ExcepcionesNegocio
    {
        public Excepcion_TarjetaInvalida()
        {
            this.Descripcion = "La tarjeta ingresada es invalida.";
        }
    }
}
