﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class ProductoDAL 
    {
        public static DataTable BuscarProducto(string nombre)
        {
            Conexion objConexion = new Conexion();

            string query = string.Format("SELECT p.id_producto,p.nombre AS nombre_producto,p.precio_compra,p.precio_venta, s.cantidad, c.descripcion AS categoria FROM producto p INNER JOIN categoria c ON p.id_categoria = c.id_categoria INNER JOIN stock s ON p.id_producto = s.id_producto WHERE p.nombre LIKE '%{0}%'", nombre);

            DataTable objDataTable = objConexion.LeerPorComando(query);

            if (objDataTable != null)
            {
                return objDataTable;
            }
            return null;
        }
    }
}
