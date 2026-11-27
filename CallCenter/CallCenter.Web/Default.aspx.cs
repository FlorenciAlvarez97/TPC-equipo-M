using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool logueado = Sesion.EstaLogueado;
            secClientes.Visible = logueado;
            secIncidencias.Visible = logueado;
            secPrioridades.Visible = Sesion.EsAdministrador;
            secTipos.Visible = Sesion.EsAdministrador;
            secUsuarios.Visible = Sesion.EsAdministrador;
            Sesion.ExigirLogin();
        }
    }
}