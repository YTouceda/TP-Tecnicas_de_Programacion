using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BLL.Excepciones
{
    class Excepcion_ProductoNoEncontrado : ExcepcionesNegocio
    {
        public Excepcion_ProductoNoEncontrado(){
        this.Descripcion = "No se encontró el producto";
         }
    }
}
