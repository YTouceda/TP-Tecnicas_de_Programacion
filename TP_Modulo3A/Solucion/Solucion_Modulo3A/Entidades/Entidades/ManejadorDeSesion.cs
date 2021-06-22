using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class ManejadorDeSesion
    {
        static Sesion _sesion;

        public static Sesion Sesion
        {
            get
            {
                return _sesion;
            }
        }

        public static void Login(Sesion sesion)
        {
            _sesion = sesion;
        }

        public static void Logout()
        {
            _sesion = null;
        }
    }
}
