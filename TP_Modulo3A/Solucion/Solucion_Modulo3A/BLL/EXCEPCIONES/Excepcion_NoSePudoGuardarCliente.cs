using BLL_Modulo3.EXCEPCIONES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EXCEPCIONES
{
    class Excepcion_NoSePudoGuardarCliente : ExcepcionesNegocio
    {
        public Excepcion_NoSePudoGuardarCliente()
        {
            this.Descripcion = "Error: No se pudo guardar el cliente";
        }
    }
}
