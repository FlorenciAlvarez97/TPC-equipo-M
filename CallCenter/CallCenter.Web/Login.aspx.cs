using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Dominio;
using CallCenter.Negocio;

namespace CallCenter.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(Object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = usuarioNegocio.login(txtUsuario.Text, txtContrasena.Text);
                if (usuario == null)
                {
                lblError.Text = "Usuario o contraseña incorrectos. Por favor, inténtelo nuevamente.";
                lblError.Visible = true;
                    return;
                }

                Session["UsuarioId"] = usuario.Id;
                Session["RolId"] = usuario.Rol.Id;
                Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al intentar iniciar sesión. Por favor, inténtelo nuevamente.";
                lblError.Visible = true;
            }
        }
    }
}