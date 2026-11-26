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
            lnkIngresar.Visible = !logueado;
            btnCerrarSesion.Visible = logueado;
            liClientes.Visible = logueado;
            liIncidencias.Visible = logueado;
            liTipos.Visible = Sesion.EsAdministrador;
            liPrioridades.Visible = Sesion.EsAdministrador;
            liUsuarios.Visible = Sesion.EsAdministrador;
            string rol = Sesion.EsAdministrador ? "Administrador" : (Sesion.EsSupervisor ? "Supervisor" : "Telefonista");
            lblUsuarioActual.Text = logueado ? "Rol: " + rol : "";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();
            Response.Redirect("~/Login.aspx", false);
        }
    }
}