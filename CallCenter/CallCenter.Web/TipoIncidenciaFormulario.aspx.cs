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
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;

                TipoIncidencia nuevo = new TipoIncidencia();

                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Activo = chkActivo.Checked;

                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();

                negocio.Agregar(nuevo);

                Response.Redirect("/TiposIncidencia.aspx", false);

                Context.ApplicationInstance.CompleteRequest();
            }

            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
                return;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudo guardar la prioridad";
                lblError.Visible = true;
                return;
            }


        
            

        }
    }
}