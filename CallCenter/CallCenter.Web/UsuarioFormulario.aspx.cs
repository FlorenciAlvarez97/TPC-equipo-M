using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Negocio;

namespace CallCenter.Web
{
    public partial class UsuarioFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    RolNegocio negocio = new RolNegocio();
                    ddlRol.DataSource = negocio.Listar();
                    ddlRol.DataTextField = "Nombre";
                    ddlRol.DataValueField = "Id";
                    ddlRol.DataBind();


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudieron cargar los roles.";
                    lblError.Visible = true;
                }
            }




        }
    }
}