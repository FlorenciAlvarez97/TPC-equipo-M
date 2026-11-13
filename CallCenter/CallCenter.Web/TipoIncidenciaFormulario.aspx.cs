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
    public partial class TipoIncidenciaFormulario : System.Web.UI.Page
    {
        private void MostrarError(string mensaje)
        {
            lblError.Text = Server.HtmlEncode(mensaje);
            lblError.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string idTexto = Request.QueryString["id"];

                    if (string.IsNullOrEmpty(idTexto))
                    {
                        return;
                    }

                    int id;

                    if (!int.TryParse(idTexto, out id) || id <= 0)
                    {
                        throw new ArgumentException("El ID no es válido");
                    }

                    TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();

                    TipoIncidencia tipo = negocio.ObtenerPorId(id);

                    if (tipo == null)
                    {
                        throw new ArgumentException(
                            "No se encontró el tipo de incidencia");
                    }

                    txtNombre.Text = tipo.Nombre;
                    txtDescripcion.Text = tipo.Descripcion;
                    chkActivo.Checked = tipo.Activo;

                    btnGuardar.Text = "Guardar cambios";
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                    btnGuardar.Enabled = false;
                }
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                return;
            }

            try
            {
                lblError.Visible = false;

                int id = 0;
                string idTexto = Request.QueryString["id"];

                if (idTexto != null)
                {
                    if (!int.TryParse(idTexto, out id) || id <= 0)
                    {
                        throw new ArgumentException("El ID no es válido");
                    }
                }

                TipoIncidencia tipo = new TipoIncidencia();

                tipo.Id = id;
                tipo.Nombre = txtNombre.Text.Trim();
                tipo.Descripcion = txtDescripcion.Text.Trim();
                tipo.Activo = chkActivo.Checked;

                TipoIncidenciaNegocio negocio =
                    new TipoIncidenciaNegocio();

                if (id == 0)
                {
                    negocio.Agregar(tipo);
                }
                else
                {
                    negocio.Modificar(tipo);
                }

                Response.Redirect("~/TiposIncidencia.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                MostrarError("No se pudo guardar el tipo de incidencia");
            }
        }

    }
}