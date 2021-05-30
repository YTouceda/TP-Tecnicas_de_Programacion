///////////////////////////////////////////////////////////
//  DetalleOrden.cs
//  Implementation of the Class DetalleOrden
//  Generated by Enterprise Architect
//  Created on:      30-abr.-2021 19:47:26
//  Original author: AR00111194
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ENTITY{
	public class DetalleOrden : EntidadPersistible
	{

		private int _cantidad;
		private Producto _producto;

		public DetalleOrden(){

		}

		public int Cantidad{
			get;
			set;
		}

		public Producto Producto{
			get;
			set;
		}

	}//end DetalleOrden

}//end namespace General