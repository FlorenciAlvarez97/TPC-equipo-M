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
        private int ObtenerIdDesdeUrl()
        {
            string idTexto = Request.QueryString["id"]; 

            if(idTexto == null)
            {
                return 0;
            }

            int id;

            if(!int.TryParse(idTexto, out id)|| id <=0)
            {
                throw new ArgumentException("El ID de la prioridad no es válido");
            }

            return id;
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = Server.HtmlEncode(mensaje);
            lblError.Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            try
            {
                int id = ObtenerIdDesdeUrl();

                if (id == 0)
                {
                    Title = "Nueva prioridad";
                    btnGuardar.Text = "Guardar";
                    return;
                }

                PrioridadNegocio negocio = new PrioridadNegocio();
                Prioridad prioridad = negocio.ObtenerPorId(id);

                if (prioridad == null)
                {
                    throw new ArgumentException("No se encontro la prioridad solicitada");
                }

                txtNombre.Text = prioridad.Nombre;
                txtNivel.Text = prioridad.Nivel.ToString();

                Title = "Editar prioridad";
                btnGuardar.Text = "Guardar cambios";
            }

            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
                btnGuardar.Enabled = false;
            }

            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                MostrarError("Nos se puedo cargar la prioridad");
                btnGuardar.Enabled=false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // No guardar si se bloqueó el formulario por un error de carga
            if (!btnGuardar.Enabled)
            {
                return;
            }

            // Ocultar cualquier mensaje del intento anterior
            lblError.Visible= false;

            int nivel;

            if (!int.TryParse(txtNivel.Text, out nivel) || nivel <= 0)
            {
                MostrarError("Ingresá un nivel mayot a cero");
                return;
            }

            try
            {    // Armar el objeto con los datos del formulario.

                int id = ObtenerIdDesdeUrl();

                Prioridad prioridad = new Prioridad();
                prioridad.Id = id;
                prioridad.Nombre = txtNombre.Text;
                prioridad.Nivel = nivel;
                prioridad.Activo = true;

                PrioridadNegocio negocio = new PrioridadNegocio();

                if(id == 0)
                {   // crear un registro nuevo
                    prioridad.Activo= true;
                    negocio.Agregar(prioridad);
                }
                else
                {   //actualizar el registro indicado.
                    negocio.Modificar(prioridad);
                }
                
            }

            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
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