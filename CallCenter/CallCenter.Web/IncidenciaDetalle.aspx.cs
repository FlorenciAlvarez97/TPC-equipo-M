using System;
using CallCenter.Dominio;
using CallCenter.Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class IncidenciaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnReasignar.Enabled = Sesion.EstaLogueado && (Sesion.EsSupervisor || Sesion.EsAdministrador);
            if (!IsPostBack)
            {
                Cargarincidencias();
                cargarresponsables();
      
            }

        }

        private void Cargarincidencias()
        {
            int id;
            if (!int.TryParse(Request.QueryString["id"], out id) || id <= 0)
            {
                lblError.Text = "La incidencia solicitada no es válida.";
                lblError.Visible = true;
                return;
            }

            try
            {
                Incidencia inc = new IncidenciaGestionNegocio().obtenerporid(id);
                if (inc == null)
                {
                    lblError.Text = "No se encontró la incidencia solicitada.";
                    lblError.Visible = true;
                    return;
                }
                txtNumero.Text = inc.Numero.ToString();
                txtFechaAlta.Text = inc.FechaAlta.ToString("dd/MM/yyyy HH:mm");
                txtCliente.Text = inc.cliente.Nombre + " " + inc.cliente.Apellido;
                txtTipo.Text = inc.Tipo.Nombre;
                txtPrioridad.Text = inc.prioridad.Nombre;
                txtEstado.Text = inc.Estado.Nombre;
                txtDescripcion.Text = inc.Descripcion;
                txtUsuarioAsignado.Text = inc.UsuarioAsignado.Nombre;
                ddlNuevoResponsable.SelectedValue = inc.UsuarioAsignado.Id.ToString();


            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al cargar la incidencia.";
                lblError.Visible = true;

            }
        }

        private void cargarresponsables()
        {
            try
            {
                IncidenciaGestionNegocio negocio = new IncidenciaGestionNegocio();
                ddlNuevoResponsable.DataSource = negocio.ListarUsuariosActivos();
                ddlNuevoResponsable.DataTextField = "Nombre";
                ddlNuevoResponsable.DataValueField = "Id";
                ddlNuevoResponsable.DataBind();
       
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudieron cargar los usuarios.";
                lblError.Visible = true;
            }
        }

        protected void btnReasignar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!Sesion.EstaLogueado || !(Sesion.EsSupervisor || Sesion.EsAdministrador))
            {
                lblError.Text = "No tiene permisos para reasignar la incidencia.";
                lblError.Visible = true;
                return;
            }

            int idincidencia;
            int idnuevoresponsable;
            if (!int.TryParse(Request.QueryString["id"], out idincidencia) || !int.TryParse(ddlNuevoResponsable.SelectedValue, out idnuevoresponsable))
            {
                lblError.Text = "Datos inválidos para reasignar la incidencia.";
                lblError.Visible = true;
                return;
            }
            try
            {
                IncidenciaGestionNegocio negocio = new IncidenciaGestionNegocio();
                negocio.Reasignar(idincidencia, idnuevoresponsable, Sesion.UsuarioId);
                Cargarincidencias();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al reasignar la incidencia.";
                lblError.Visible = true;
            }
        }
    }
}