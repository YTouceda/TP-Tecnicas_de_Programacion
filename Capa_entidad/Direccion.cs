///////////////////////////////////////////////////////////
//  Direccion.cs
//  Implementation of the Class Direccion
//  Generated by Enterprise Architect
//  Created on:      30-abr.-2021 19:47:55
//  Original author: AR00111194
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Entity {
	public class Direccion {

		private string _altura;
		private string _calle;
		private string _codigoPostal;
		private string _localidad;
		private string _provincia;

		public Direccion(string altura, string calle, string codigoPostal, string localidad, string provincia){
			this.Altura = altura;
			this.Calle = calle;
			this.CodigoPostal = codigoPostal;
			this.Localidad = localidad;
			this.Provincia = provincia;
		}
		public Direccion()
		{

		}

		public string Altura{
			get;
			set;
		}

		public string Calle{
			get;
			set;
		}

		public string CodigoPostal{
			get;
			set;
		}

		public string Localidad{
			get;
			set;
		}

		public string Provincia{
			get;
			set;
		}

	}//end Direccion

}//end namespace General