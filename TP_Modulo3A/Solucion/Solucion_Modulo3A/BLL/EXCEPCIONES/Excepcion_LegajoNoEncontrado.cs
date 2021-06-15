using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_LegajoNoEncontrado : ExcepcionesNegocio
    {
        public Excepcion_LegajoNoEncontrado()
            {
            this.Descripcion = "No se encontro el Legajo solicitado";
            }
    }
}
