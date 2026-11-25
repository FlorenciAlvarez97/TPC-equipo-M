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
            btnResolver.Enabled = Sesion.EstaLogueado;
            btnCerrar.Enabled = Sesion.EstaLogueado;
            btnReabrir.Enabled = Sesion.EstaLogueado && (Sesion.EsSupervisor || Sesion.EsAdministrador);
            btnGuardarGestion.Enabled = Sesion.EstaLogueado;

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

        protected void btnResolver_Click(Object sender, EventArgs e)
        {
            lblError.Visible = false;
            int idincidencia;
            if (!Sesion.EstaLogueado || !int.TryParse(Request.QueryString["id"], out idincidencia))
            {
                lblError.Text = "No tiene permisos para resolver la incidencia.";
                lblError.Visible = true;
                return;

            }

            string resolucion = txtResolucion.Text.Trim();
            if (resolucion == "")
            {
                lblError.Text = "Debe ingresar una resolución para la incidencia.";
                lblError.Visible = true;
                return;
            }

            try
            {
                IncidenciaGestionNegocio negocio = new IncidenciaGestionNegocio();
                Incidencia incidencia = negocio.obtenerporid(idincidencia);
                if (incidencia == null)
                {
                    lblError.Text = "La incidencia no fue encontrada.";
                    lblError.Visible = true;
                    return;
                }

                bool puede = Sesion.EsAdministrador || Sesion.EsSupervisor || incidencia.UsuarioAsignado.Id == Sesion.UsuarioId;
                if (!puede)
                {
                    lblError.Text = "No tiene permisos para resolver esta incidencia.";
                    lblError.Visible = true;
                    return;
                }

                int estado = incidencia.Estado.Id;
                if (estado != 2 && estado != 3 && estado != 6)
                {
                    lblError.Text = "La incidencia no se encuentra en un estado que permita ser resuelta.";
                    lblError.Visible = true;
                    return;
                }

                negocio.Resolver(idincidencia, resolucion, Sesion.UsuarioId);
                Cargarincidencias();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al resolver la incidencia.";
                lblError.Visible = true;
            }


        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            int idincidencia;
            if (!Sesion.EstaLogueado || !int.TryParse(Request.QueryString["id"], out idincidencia))
            {
                lblError.Text = "No tiene permisos para cerrar la incidencia.";
                lblError.Visible = true;
                return;

            }

            string comentario = txtComentarioCierre.Text.Trim();
            if (comentario == "")
            {
                lblError.Text = "Debe ingresar un comentario para cerrar la incidencia.";
                lblError.Visible = true;
                return;
            }

            try
            {
                IncidenciaGestionNegocio negocio = new IncidenciaGestionNegocio();
                Incidencia incidencia = negocio.obtenerporid(idincidencia);
                if (incidencia == null)
                {
                    lblError.Text = "La incidencia no fue encontrada.";
                    lblError.Visible = true;
                    return;
                }

                bool puede = Sesion.EsAdministrador || Sesion.EsSupervisor || incidencia.UsuarioAsignado.Id == Sesion.UsuarioId;
                if (!puede)
                {
                    lblError.Text = "No tiene permisos para cerrar esta incidencia.";
                    lblError.Visible = true;
                    return;
                }

                if (incidencia.Estado.Id != 4)
                {
                    lblError.Text = "La incidencia no se encuentra en un estado que permita ser cerrada.";
                    lblError.Visible = true;
                    return;
                }

                negocio.Cerrar(idincidencia, comentario, Sesion.UsuarioId);
                Cargarincidencias();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al cerrar la incidencia.";
                lblError.Visible = true;
            }
        }

        protected void btnReabrir_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            int idincidencia;
            if (!Sesion.EstaLogueado || !(Sesion.EsSupervisor || Sesion.EsAdministrador))
            {
                lblError.Text = "No tiene permisos para reabrir la incidencia.";
                lblError.Visible = true;
                return;
            }

            if (!int.TryParse(Request.QueryString["id"], out idincidencia))
            {
                lblError.Text = "Datos inválidos para reabrir la incidencia.";
                lblError.Visible = true;
                return;
            }

            try
            {
                IncidenciaGestionNegocio negocio = new IncidenciaGestionNegocio();
                Incidencia incidencia = negocio.obtenerporid(idincidencia);
                if (incidencia == null)
                {
                    lblError.Text = "La incidencia no fue encontrada.";
                    lblError.Visible = true;
                    return;
                }

                if (incidencia.Estado.Id != 4 && incidencia.Estado.Id != 5)
                {
                    lblError.Text = "La incidencia no se encuentra en un estado que permita ser reabierta.";
                    lblError.Visible = true;
                    return;
                }

                negocio.Reabrir(idincidencia, Sesion.UsuarioId);
                Cargarincidencias();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al reabrir la incidencia.";
                lblError.Visible = true;
            }
        }


        protected void ddlTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlTipoGestion.SelectedValue)
            {
                case "resolver":
                    lblComentarioSeguimiento.Text = "Resolución (obligatoria)";
                    break;

                case "cerrar":
                    lblComentarioSeguimiento.Text = "Comentario final de cierre (obligatorio)";
                    break;

                case "reabrir":
                    lblComentarioSeguimiento.Text = "Comentario de reapertura";
                    break;

                default:
                    lblComentarioSeguimiento.Text = "Comentario de la gestión";
                    break;
            }
        }


        protected void btnGuardarGestion_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.CssClass = "alert alert-danger d-block";

            if (!Sesion.EstaLogueado)
            {
                lblError.Text = "Debés iniciar sesión.";
                lblError.Visible = true;
                return;
            }

            string comentario = txtComentarioSeguimiento.Text.Trim();

            switch (ddlTipoGestion.SelectedValue)
            {
                case "seguimiento":
                    lblError.Text = "El registro de seguimientos está pendiente.";
                    lblError.Visible = true;
                    break;

                case "resolver":
                    txtResolucion.Text = comentario;
                    btnResolver_Click(sender, e);
                    break;

                case "cerrar":
                    txtComentarioCierre.Text = comentario;
                    btnCerrar_Click(sender, e);
                    break;

                case "reabrir":
                    btnReabrir_Click(sender, e);
                    break;

                default:
                    lblError.Text = "Seleccioná una gestión válida.";
                    lblError.Visible = true;
                    break;
            }
        }

    }

}
