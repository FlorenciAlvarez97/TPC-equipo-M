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
    public partial class PrioridadFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {}   
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Ocultar cualquier mensaje del intento anterior
            lblError.Visible= false;

            int nivel;

            if (!int.TryParse(txtNivel.Text, out nivel) || nivel <= 0)
            {
                lblError.Text = "Ingresá un nivel mayor a cero";
                lblError.Visible = true;
                return;
            }

            try
            {    // Armar el objeto con los datos del formulario.
                Prioridad prioridad = new Prioridad();
                prioridad.Nombre = txtNombre.Text;
                prioridad.Nivel = nivel;
                prioridad.Activo = true;

                PrioridadNegocio negocio = new PrioridadNegocio();
                negocio.Agregar(prioridad);
            }

            catch (ArgumentException ex)
            {
                lblError.Text = Server.HtmlEncode(ex.Message);
                lblError.Visible = true;
                return;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.Text = "No se pudo completar el guardado. Revisá el listado antes de volver a intentar.";
                lblError.Visible = true;
                return;
            }

            Response.Redirect("~/Prioridades.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
            return;
            
        }
    }
}