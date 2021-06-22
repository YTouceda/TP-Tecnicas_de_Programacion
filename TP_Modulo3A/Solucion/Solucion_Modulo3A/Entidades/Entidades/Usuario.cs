using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Usuario : Persona
    {
        private int _legajo;
        private DateTime? _deshabilitado;
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        public DateTime? Deshabilitado
        {
            get { return _deshabilitado; }
            set { _deshabilitado = value; }
        }

        private Rol _rol;

        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }


    }
}