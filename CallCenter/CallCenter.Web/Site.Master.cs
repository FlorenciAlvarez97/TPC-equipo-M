using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool logueado = Sesion.EstaLogueado;
            menuLateral.Visible = logueado;
            encabezadoGeneral.Visible = logueado;
            separadorPie.Visible = logueado;
            pieGeneral.Visible = logueado;
            lnkIngresar.Visible = !logueado;
            btnCerrarSesion.Visible = logueado;
            liClientes.Visible = logueado;
            liIncidencias.Visible = logueado;
            liTipos.Visible = Sesion.EsAdministrador;
            liPrioridades.Visible = Sesion.EsAdministrador;
            liUsuarios.Visible = Sesion.EsAdministrador;
            lblUsuarioActual.Text = logueado ? Server.HtmlEncode(Convert.ToString(Session["UsuarioNombre"])) : "";

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();
            Response.Redirect("~/Login.aspx", false);
        }
    }
}




