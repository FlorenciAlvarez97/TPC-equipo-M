using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Negocio;

namespace CallCenter.Web
{
    partial class Prioridades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    PrioridadNegocio negocio = new PrioridadNegocio();
                    dgvPrioridades.DataSource = negocio.Listar();
                    dgvPrioridades.DataBind();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "ERROR AL CARGAR PRIORIDADES:");

                    System.Diagnostics.Debug.WriteLine(ex.ToString());

                    lblError.Text = "No se pudieron cargar las prioridades.";
                    lblError.Visible = true;
                }
            }
        }
    }
}