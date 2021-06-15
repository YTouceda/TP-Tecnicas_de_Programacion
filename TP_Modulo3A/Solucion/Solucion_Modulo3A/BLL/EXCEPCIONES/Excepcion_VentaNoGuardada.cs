using BLL_Modulo3.EXCEPCIONES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_VentaNoGuardada : ExcepcionesNegocio
    {
        public Excepcion_VentaNoGuardada()
        {
            this.Descripcion = "No se pudo dar de alta la venta";
        }
    }
}
