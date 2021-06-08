using BLL.EXCEPCIONES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EXCEPCIONES
{
    public class Excepcion_VentaNoGuardada : ExcepcionesNegocio
    {
        public Excepcion_VentaNoGuardada()
        {
            this.Descripcion = "No se pudo dar de alta la venta";
        }
    }
}
