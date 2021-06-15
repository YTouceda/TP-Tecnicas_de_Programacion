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


namespace ENTITY
{
	public abstract class Persona : EntidadPersistible{

		private string _apellido;
		private Direccion _direccion;
		private int _dni;
		private string _nombre;


        public Persona(int _id_persona ,string apellido, Direccion direccion, int dni, string nombre){
			this.Apellido = apellido;
			this.Direccion = direccion;
			this.DNI = dni;
			this.Nombre = nombre;
		}

		public Persona()
		{

		}


		public string Apellido{
			get;
			set;
		}

		public Direccion Direccion{
			get;
			set;
		}

		public int DNI{
			get;
			set;
		}

		public string Nombre{
			get;
			set;
		}

	}//end Persona

}//end namespace General