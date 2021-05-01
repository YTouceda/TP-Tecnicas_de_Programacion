///////////////////////////////////////////////////////////
//  Orden.cs
//  Implementation of the Class Orden
//  Generated by Enterprise Architect
//  Created on:      30-abr.-2021 19:47:06
//  Original author: AR00111194
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using General;
namespace General {
	public abstract class Orden {

		private List<DetalleOrden> _detalles = new List<DetalleOrden>();
		private DateTime _fecha;
		private Usuario _usuarioCreador;

		public Orden(){

		}

		~Orden(){

		}

		public List<DetalleOrden> Detalles{
			get;
			set;
		}

		public DateTime Fecha{
			get;
			set;
		}

		public Usuario UsuarioCreador{
			get;
			set;
		}

	}//end Orden

}//end namespace General