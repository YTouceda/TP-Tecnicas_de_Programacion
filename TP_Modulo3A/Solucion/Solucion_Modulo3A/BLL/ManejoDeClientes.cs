using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Modulo3;
using ENTITY;

namespace BLL_Modulo3
{
    class ManejoDeClientes
    {
        public ClienteDAL objDAL = new ClienteDAL(); 
        public Cliente LevantarCliente()
        {
            Cliente objCliente = new Cliente();

            ClienteDAL.PersistirCliente(objCliente);
            return objCliente;

        }


    }
}
