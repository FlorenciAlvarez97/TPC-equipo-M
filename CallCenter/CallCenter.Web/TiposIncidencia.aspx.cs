using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Negocio;
using CallCenter.Dominio;

namespace CallCenter.Web
{
    public partial class TiposIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion.ExigirAdministrador();

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
                var lista = negocio.Listar();

                string busqueda = txtBuscarTipo.Text.Trim();
                string estado = ddlEstadoTipo.SelectedValue;

                if (busqueda != "")
                {
                    lista = lista.Where(t => (t.Nombre ?? "").IndexOf( busqueda, StringComparison.OrdinalIgnoreCase) >= 0 || (t.Descripcion ?? "").IndexOf( busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();
                }

                if (estado == "1")
                {
                    lista = lista.Where(t => t.Activo).ToList();
                }
                else if (estado == "0")
                {
                    lista = lista.Where(t => !t.Activo).ToList();
                }

                dgvTiposIncidencia.DataSource = lista;
                dgvTiposIncidencia.DataBind();

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudieron cargar los tipos de incidencia.";
                lblError.Visible = true;
            }

        }


        protected void btnBuscarTipos_Click(object sender, EventArgs e)
        {
            CargarTiposIncidencia();
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


        protected void dgvTiposIncidencia_RowCommand( object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "CambiarEstado")
            {
                return;
            }

            try
            {
                lblError.Visible = false;

                int id = Convert.ToInt32(e.CommandArgument);

                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();

                var tipo = negocio.ObtenerPorId(id);

                if (tipo == null)
                {
                    throw new ArgumentException("No se encontró el tipo de incidencia");
                }

                negocio.CambiarEstado(id, !tipo.Activo);

                CargarTiposIncidencia();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudo cambiar el estado del tipo de incidencia.";

                lblError.Visible = true;
            }
        }

    }
}