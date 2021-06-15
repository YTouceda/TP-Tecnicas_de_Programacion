using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Modulo3.EXCEPCIONES
{
    class Excepcion_ProductoNoEncontrado : ExcepcionesNegocio
    {
        public Excepcion_ProductoNoEncontrado()
        {
        
            
            this.Descripcion = "No se encontró el producto";
         
        
        }
    }
}
