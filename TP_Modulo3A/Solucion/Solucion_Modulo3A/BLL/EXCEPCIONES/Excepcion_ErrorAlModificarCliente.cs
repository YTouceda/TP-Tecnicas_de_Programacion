using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_ErrorAlModificarCliente :ExcepcionesNegocio
    {
        public Excepcion_ErrorAlModificarCliente()
        {
            this.Descripcion ="Error : No se pudo modificar el cliente.";
        }
    }
}
