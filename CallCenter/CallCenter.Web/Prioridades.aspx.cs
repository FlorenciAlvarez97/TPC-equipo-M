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
                CargarPrioridades();   
            }
        }
        private void CargarPrioridades()
        {
            try
            {
                lblError.Visible = false;
           
                PrioridadNegocio negocio = new PrioridadNegocio();
                dgvPrioridades.DataSource = negocio.Listar();
                dgvPrioridades.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudieron cargar las prioridades.";
                lblError.Visible = true;
            }
        }

        protected void dgvPrioridades_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (dgvPrioridades.SelectedDataKey == null)
            {
                lblError.Text = "No se puedo identificar la prioridad seleccionada";
                lblError.Visible = true;
                return;
            }

            int id = Convert.ToInt32(dgvPrioridades.SelectedDataKey.Value);

            Response.Redirect("~/PrioridadFormulario.aspx?id=" + id, false);
            Context.ApplicationInstance.CompleteRequest();
            return;
        }
        protected void dgvPrioridades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Desactivar" && e.CommandName != "Reactivar")
            {
                return;
            }

            lblError.Visible = false;

            try
            {
                int id;

                if (!int.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
                {
                    throw new ArgumentException("No se pudo identificar la prioridad seleccionada");
                }

                bool activo = e.CommandName == "Reactivar";

                PrioridadNegocio negocio = new PrioridadNegocio();
                negocio.CambiarEstado(id, activo);

                CargarPrioridades();
            }

            catch (ArgumentException ex)
            {
                lblError.Text = Server.HtmlEncode(ex.Message);
                lblError.Visible = true;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se puedo realizar el cambio de estado";
                lblError.Visible = true;
            }
        }
    }
}