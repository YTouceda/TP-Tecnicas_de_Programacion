///////////////////////////////////////////////////////////
//  Tarjeta.cs
//  Implementation of the Class Tarjeta
//  Generated by Enterprise Architect
//  Created on:      30-abr.-2021 19:40:15
//  Original author: Yannick
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace ENTITY
{
	public class Tarjeta : MetodoDePago
	{

		private string _CVC;
		private string _fechaVencimiento;
		private string _nombreTarjeta;
		private long _numeroTarjeta;

		public Tarjeta()
		{

		}

		public Tarjeta(string CVC, string fechaVencimiento, string nombreTarjeta, long numeroTarjeta)
		{
			this.CVC = CVC;
			this.FechaVencimiento = fechaVencimiento;
			this.NombreTarjeta = nombreTarjeta;
			this.NumeroTarjeta = numeroTarjeta;

		}

		public string CVC
		{
			get;
			set;
		}

		public string FechaVencimiento
		{
			get;
			set;
		}

		public string NombreTarjeta
		{
			get;
			set;
		}

		public long NumeroTarjeta
		{
			get;
			set;
		}
	}//end Tarjeta
}