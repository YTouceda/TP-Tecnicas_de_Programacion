using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BLL.Excepciones
{
    class Excepcion_StockInsuficiente : ExcepcionesNegocio
    {
        public Excepcion_StockInsuficiente(){
           this.Descripcion = "No hay stock suficiente del producto seleccionado"; 
        }
    }
}
