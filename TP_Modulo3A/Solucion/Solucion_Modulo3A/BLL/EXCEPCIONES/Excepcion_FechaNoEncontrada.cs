using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_FechaNoEncontrada :ExcepcionesNegocio
    {
        public Excepcion_FechaNoEncontrada()
        {
            this.Descripcion ="No se encontraron ventas en la fecha proporcionada.";
        }
    }
}
