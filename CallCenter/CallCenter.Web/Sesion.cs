using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenter.Web
{
    public class Sesion
    {
        public static bool EstaLogueado
        {
            get { return HttpContext.Current.Session["UsuarioId"] != null; }
        }
        public static int UsuarioId
        {
            get { return (int)HttpContext.Current.Session["UsuarioId"]; }
        }
        public static int RolId
        {
            get { return (int)HttpContext.Current.Session["RolId"]; }
        }
        public static bool EsAdministrador
        {
            get { return EstaLogueado && RolId == 1; }
        }
        public static bool EsTelefonista
        {
            get { return EstaLogueado && RolId == 2; }
        }
        public static bool EsSupervisor
        {
            get { return EstaLogueado && RolId == 3; }
        }
        public static void Cerrar()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        public static void ExigirLogin()
        {
            if (!EstaLogueado)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }

        public static void ExigirAdministrador()
        {
            ExigirLogin();
            if (!EsAdministrador)
            {
                HttpContext.Current.Response.Redirect("~/Default.aspx", true);
            }


        }

    }
}