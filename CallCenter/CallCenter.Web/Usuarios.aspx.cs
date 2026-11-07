using CallCenter.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    dgvUsuarios.DataSource = negocio.Listar();
                    dgvUsuarios.DataBind();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudieron cargar los usuarios.";
                    lblError.Visible = true;
                }
            }


        }
    }
}