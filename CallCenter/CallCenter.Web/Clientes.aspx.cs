using CallCenter.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    dgvClientes.DataSource = negocio.Listar();
                    dgvClientes.DataBind();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudieron cargar los clientes.";
                    lblError.Visible = true;
                }
            }

        }
    }
}