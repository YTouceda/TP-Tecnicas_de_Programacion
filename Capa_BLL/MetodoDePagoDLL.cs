using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;



namespace Capa_BLL
{
    public abstract class MetodoDePagoDLL : MetodoDePago
    {
        private MetodoDePago _metodo;
        
        public MetodoDePagoDLL()
        {
            _metodo = new Tarjeta();
        }

        public MetodoDePago DevolverMetodoDePago(MetodoDePago unMetodo)
        {
            Tarjeta unaTarjeta=new Tarjeta();
            Efectivo efectivo = new Efectivo();
            if(unMetodo == unaTarjeta){
                return unMetodo;
            }
            else
            {
                return unMetodo;
            }
        }
        
    }
}
