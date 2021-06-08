using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EXCEPCIONES
{
    public class Excepcion_ClienteInexistente: ExcepcionesNegocio
    {
        public Excepcion_ClienteInexistente() 
        {
            this.Descripcion = "No se encontro el Cliente";
        }
    }
}
