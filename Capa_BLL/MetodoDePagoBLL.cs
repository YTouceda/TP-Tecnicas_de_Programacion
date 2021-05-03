using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;



namespace Capa_BLL
{
    public abstract class MetodoDePagoBLL
    {
        
        public MetodoDePagoBLL()
        {

        }

        public MetodoDePagoBLL DevolverMetodoDePago(Object metodo)
        {
            TarjetaBLL unaTarjeta = new TarjetaBLL();
            Efectivo efectivo = new Efectivo();
            if (metodo == unaTarjeta)
            {
                
                unaTarjeta.ValidarTarjeta();
                return metodo;
            }
            else
            {
                return unMetodo;
            }
        }
        public virtual bool Validar()
        {
            return false;
        }

    }
}
