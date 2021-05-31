using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    class ManejoDeClientes
    {
        public ClienteDAL objDAL = new ClienteDAL(); 
        public Cliente LevantarCliente()
        {
            Cliente objCliente = new Cliente();

            ClienteDAL.Alta(objCliente);
            return objCliente;

        }


    }
}
