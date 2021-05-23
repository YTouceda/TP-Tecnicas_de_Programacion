using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    class ManejoDeClientes
    {
        public DAL.ClienteDAL objDAL = new ClienteDAL(); 
        public Cliente LevantarCliente()
        {
            ClienteDAL objClienteDAL = new ClienteDAL();
            Cliente objCliente = new Cliente();

            objDAL.Alta(objCliente);
            return objCliente;

        }


    }
}
