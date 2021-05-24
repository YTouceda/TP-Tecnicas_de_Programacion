using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BLL;
using Capa_BLL.Excepciones;
using Entity;

namespace Capa_BLL
{
    class ClienteBLL
    {
        /// <summary>
        /// Devuelve un datatable desde la bbdd 
        /// </summary>
        /// <param name="Id_Cliente">Id del Cliente</param>
        public static DataTable BuscarCliente(int Id_Cliente)
        {
            ClienteDAL objClienteDAL = new ClienteDAL();
            if (objClienteDAL.BuscarClientes(Id_Cliente)!=null) 
            {

                DataTable objDataTable1 = objClienteDAL.BuscarClientes(Id_Cliente);
                return objDataTable1;
            }
                
            {
                throw new Excepcion_ClienteInexistente();

            }

        }
        /// <summary>
        /// Convierte una fila del datatable en un objeto Cliente con todos los datos completos.
        /// </summary>
        /// <param name="objDataTable">DataTable</param>
        /// <param name="indice">indice de la fila </param>
        /// <returns>objeto Cliente(segun la fila)</returns>
        public static Cliente ConvertirDeDataTableAObjCliente(DataTable objDataTable, int indice)
        {
            Cliente objCliente = new Cliente();
            Direccion objDireccion = new Direccion();
            objCliente.ID_Cliente = (int)objDataTable.Rows[indice]["C.Id_Cliente"];
            objCliente.IDPersona= (int)objDataTable.Rows[indice]["P.Id_Persona"];
            objCliente.Nombre = (objDataTable.Rows[indice]["P.Nombre"].ToString());
            objCliente.Apellido = objDataTable.Rows[indice]["P.Apellido"].ToString();
            objCliente.DNI = objDataTable.Rows[indice]["P.Dni"].ToString();
            objDireccion.Id_Direccion = (int)objDataTable.Rows[indice]["D.Id_direccion"];
            objDireccion.Calle = objDataTable.Rows[indice]["D.Calle"].ToString();
            objDireccion.Altura = objDataTable.Rows[indice]["D.Altura"].ToString();
            objDireccion.CodigoPostal = objDataTable.Rows[indice]["D.CodPostal"].ToString();
            objDireccion.Localidad = objDataTable.Rows[indice]["D.Localidad"].ToString();
            objDireccion.Provincia = objDataTable.Rows[indice]["D.Provincia"].ToString();
            return objCliente;
        }
    }
}
