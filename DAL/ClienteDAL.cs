using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL
{
    public class ClienteDAL
    {
        public bool Alta(Entity.Cliente pCliente)
        {
            Conexion objConexion = new Conexion();
            string query = string.Format("INSERT INTO Cliente(Id_cliente,Id_Persona)VALUES({0},{1})",pCliente.);
            objConexion.EscribirPorComando( query );



            return true;
        }
    }
}