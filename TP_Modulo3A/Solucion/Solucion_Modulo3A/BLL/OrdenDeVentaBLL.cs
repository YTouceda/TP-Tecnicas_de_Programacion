﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;
using System.Data;
using BLL.EXCEPCIONES;

namespace BLL
{
    public class OrdenDeVentaBLL
    {

        /// <summary>
        /// Persiste una venta llamando al metodo PersistirVenta de DAL
        /// </summary>
        /// <param name="unaOrdendeVenta">Orden de venta</param>
        /// <returns>True si se persistio , caso contrario arroja una excepcion.</returns>
        public static bool GuardaOrdenVenta(OrdenDeVenta unaOrdenDeVenta)
        {
            Tarjeta unaTarjeta = new Tarjeta();

            if (unaOrdenDeVenta.MetodoDePago.GetType() == unaTarjeta.GetType())
            {
                unaTarjeta = (Tarjeta)unaOrdenDeVenta.MetodoDePago;
                if (TarjetaBLL.ValidarTarjeta(unaTarjeta))
                {
                if (OrdenDeVentaDAL.PersistirVenta(unaOrdenDeVenta))
                    {
                    return true;
                    }

                }

            }
            
            throw new Excepcion_VentaNoGuardada();
        }

        /// <summary>
        /// Genera un reporte de venta pasando por parametro el legajo del usuario VENDEDOR
        /// </summary>
        /// <param name="legajo">Legajo del vendedor</param>
        /// <returns>Devuelve una lista de orden venta</returns>
        public static List<OrdenDeVenta> GenerarReporteDeVentasPorLegajo(int legajo)
        {
            List<OrdenDeVenta> listaVentas = new List<OrdenDeVenta>();
            if (OrdenDeVentaDAL.BuscarVentasPorLegajo(legajo) == null)
            {
                throw new Excepcion_LegajoNoEncontrado();//LEGAJO NO ENCONTRADO

            }

            System.Data.DataTable objDataTable = DAL.OrdenDeVentaDAL.BuscarVentasPorLegajo(legajo);          //guardo el datatable que trajo de la bbdd
            foreach (DataRow row in objDataTable.Rows) //carga lo de data table a row(que es un data row)
            {

                listaVentas.Add(ConvertirDeDataTableAOrdenDeVenta(row));//se agrega a ListaVentas una venta

            }

            return listaVentas; 

        }



        /// <summary>
        /// Genera un reporte de venta pasando por parametro el mes en el que desea buscar.
        /// </summary>
        /// <param name="mes">Numero del mes a buscar.</param>
        /// <returns>Devuelve una lista de orden venta</returns>
        public static List<OrdenDeVenta> GenerarReporteDeVentasPorMes(int mes,int año)
        {
            List<OrdenDeVenta> listaVentas = new List<OrdenDeVenta>();
            if (OrdenDeVentaDAL.BuscarVentasPorMes(mes,año) == null)
            {
                throw new Excepcion_FechaNoEncontrada();//Fecha Incorrecta

            }

            System.Data.DataTable objDataTable = DAL.OrdenDeVentaDAL.BuscarVentasPorMes(mes , año);          //guardo el datatable que trajo de la bbdd
            foreach (DataRow row in objDataTable.Rows) //carga lo de data table a row(que es un data row)
            {

                listaVentas.Add(ConvertirDeDataTableAOrdenDeVenta(row));//se agrega a ListaVentas una venta

            }

            return listaVentas;

        }


        /// <summary>
        /// Convierte un datatable obtenido desde la base de datos en un objeto OrdenDeVenta
        /// </summary>
        /// <param name="objDataRow">DataRow Obtenido desde la base de datos con lo solicitado.</param>
        /// <returns>Devuelve un objeto OrdenDeVenta</returns>
        private static OrdenDeVenta ConvertirDeDataTableAOrdenDeVenta(DataRow objDataRow)
        {

            List<DetalleOrden> listaDetalles = new List<DetalleOrden>();
            OrdenDeVenta unaVenta = new OrdenDeVenta();
            Usuario unUsuario = new Usuario();
            Tarjeta objTarjeta = new Tarjeta();
            Efectivo objEfectivo = new Efectivo();
            

            unaVenta.ID = (int)objDataRow["ID_ORDEN"];
            unaVenta.Fecha = Convert.ToDateTime(objDataRow["FECHA"]);
            unUsuario.Legajo = (int)objDataRow["LEGAJO_VENDEDOR"];

            if (objDataRow["metodo_pago"].ToString() == "EFECTIVO")
            {
                objEfectivo.TipoMetodoDePago = "EFECTIVO";
                unaVenta.MetodoDePago = objEfectivo;
            }
            else if (objDataRow["metodo_pago"].ToString() == "TARJETA")
            {
                objTarjeta.TipoMetodoDePago = "TARJETA";
                unaVenta.MetodoDePago = objTarjeta;
            }
            else
            {
                throw new Excepcion_MetodoDePagoInvalido();
            }

            unaVenta.UsuarioCreador = unUsuario;
            foreach (DetalleOrden unDetalle in listaDetalles)
            {
                listaDetalles.Add(DetalleOrdenBLL.ConvertirDeDataTableADetalleOrden(objDataRow));
            }
            unaVenta.Detalles = listaDetalles;

            return unaVenta;

        }

        /// <summary>
        /// Genera un reporte de venta pasando por parametro la fecha de un dia , a la cual se le suman 7 dias y se mostraran los datos de ventas de esa semana. 
        /// </summary>
        /// <param name="mes">Numero del mes a buscar.</param>
        /// <returns>Devuelve una lista de orden venta</returns>
        public static List<OrdenDeVenta> GenerarReporteDeVentasPorSemana(DateTime fecha)
        {
            DateTime fecha2;
            fecha2 = fecha.AddDays(7);
            List<OrdenDeVenta> listaVentas = new List<OrdenDeVenta>();
            if (OrdenDeVentaDAL.BuscarVentasPorSemana(fecha , fecha2) == null)
            {
                throw new Excepcion_FechaNoEncontrada();//Fecha Incorrecta

            }

            System.Data.DataTable objDataTable = DAL.OrdenDeVentaDAL.BuscarVentasPorSemana(fecha,fecha2);          //guardo el datatable que trajo de la bbdd
            foreach (DataRow row in objDataTable.Rows) //carga lo de data table a row(que es un data row)
            {

                listaVentas.Add(ConvertirDeDataTableAOrdenDeVenta(row));//se agrega a ListaVentas una venta

            }

            return listaVentas;

        }


    }
}
