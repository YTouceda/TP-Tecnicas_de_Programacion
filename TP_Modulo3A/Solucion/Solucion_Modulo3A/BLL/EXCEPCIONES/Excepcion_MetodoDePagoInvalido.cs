using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EXCEPCIONES
{
    class Excepcion_MetodoDePagoInvalido : ExcepcionesNegocio
    {
        public Excepcion_MetodoDePagoInvalido()
        {
            this.Descripcion = "Error : Metodo de pago invalido";
        }
    }
}
