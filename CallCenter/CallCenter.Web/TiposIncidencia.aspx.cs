using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Negocio;

namespace CallCenter.Web
{
    public partial class TiposIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposIncidencia();
            }
        }
        private void CargarTiposIncidencia()
        {
            try
            {
                lblError.Visible = false;

                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
                dgvTiposIncidencia.DataSource = negocio.Listar();
                dgvTiposIncidencia.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudieron cargar los tipo de incidencia";
                lblError.Visible = true;
            }
        }
    }
}