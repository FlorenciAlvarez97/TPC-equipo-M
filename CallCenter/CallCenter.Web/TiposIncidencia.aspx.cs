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

                lblError.Text = Server.HtmlEncode(ex.ToString());
                lblError.Visible = true;
            }
        }

        protected void dgvTiposIncidencia_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (dgvTiposIncidencia.SelectedDataKey == null)
            {
                lblError.Text = "No se puedo identificar el tipo de incidencia seleccionado";
                lblError.Visible = true;
                return;
            }

            int id = Convert.ToInt32(dgvTiposIncidencia.SelectedDataKey.Value);

            Response.Redirect("~/TipoIncidenciaFormulario.aspx?id=" + id, false);
            Context.ApplicationInstance.CompleteRequest();
            return;
        }
    }
}