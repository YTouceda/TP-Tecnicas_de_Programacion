using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class ManejoDeClientes
    {
        public DAL.ClienteDAL objDAL = new ClienteDAL(); 
        public Cliente LevantarCliente()
        {
            objDAL =
            Cliente objEntity = new Cliente();

            return objEntity;
        }
    }
}
