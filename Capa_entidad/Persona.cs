///////////////////////////////////////////////////////////
//  Persona.cs
//  Implementation of the Class Persona
//  Generated by Enterprise Architect
//  Created on:      30-abr.-2021 19:48:03
//  Original author: AR00111194
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Entity {
	public abstract class Persona {

		private string _apellido;
		private Direccion _direccion;
		private string _dni;
		private string _nombre;
        private int _id_persona;


        public Persona(int _id_persona ,string apellido, Direccion direccion, string dni, string nombre){
			this.Apellido = apellido;
			this.Direccion = direccion;
			this.DNI = dni;
			this.Nombre = nombre;
			this.IDPersona = _id_persona;
		}

		public Persona()
		{

		}

        public int IDPersona
        {
            get { return _id_persona; }
            set { _id_persona = value; }
        }

		public string Apellido{
			get;
			set;
		}

		public Direccion Direccion{
			get;
			set;
		}

		public string DNI{
			get;
			set;
		}

		public string Nombre{
			get;
			set;
		}

	}//end Persona

}//end namespace General