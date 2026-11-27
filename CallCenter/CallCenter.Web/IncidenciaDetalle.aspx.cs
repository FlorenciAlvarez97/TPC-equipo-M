using System;
using CallCenter.Dominio;
using CallCenter.Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace CallCenter.Web
{
    public partial class IncidenciaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Sesion.EstaLogueado)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            btnReasignar.Enabled = Sesion.EsSupervisor || Sesion.EsAdministrador;
            btnResolver.Enabled = true;
            btnCerrar.Enabled = true;
            btnReabrir.Enabled = Sesion.EsSupervisor || Sesion.EsAdministrador;
            btnGuardarGestion.Enabled = true;
            if (!IsPostBack)
            {
                cargarresponsables();
                if (Cargarincidencias())
                {
                    CargarHistorial();
                }
            }
        }

        private bool Cargarincidencias()
        {
            int id;
            if (!int.TryParse(Request.QueryString["id"], out id))
            {
                lblError.Text = "Id de incidencia inválido.";
                lblError.Visible = true;
                return false;
            }
            try
            {
                Incidencia inc = new IncidenciaGestionNegocio().obtenerporid(id);
                if (inc == null)
                {
                    lblError.Text = "No se encontró la incidencia solicitada.";
                    lblError.Visible = true;
                    return false;
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
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "Ocurrió un error al cargar la incidencia.";
                lblError.Visible = true;
                return false;
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

            if (resolucion.Length > 1000)
            {
                lblError.Text = "La resolución no puede superar los 1000 caracteres.";
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
                RegistrarHistorial(idincidencia, resolucion);
                Cargarincidencias();
                CargarHistorial();

                string cuerporesuelto = "Hola " + incidencia.cliente.Nombre + " " + incidencia.cliente.Apellido + ",\n\n" + "Tu reclamo Nº " + incidencia.Numero + " fue resuelto.\n\n" + "Resolución: " + resolucion + "\n\n" + "Sistema Call Center";
                if (!EnviarAviso(incidencia, "Reclamo Nº " + incidencia.Numero + " resuelto", cuerporesuelto))
                {
                    lblError.Text = "La incidencia se resolvió, pero no se pudo enviar el correo al cliente.";
                    lblError.Visible = true;
                }
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

            if (comentario.Length > 1000)
            {
                lblError.Text = "El comentario de cierre no puede superar los 1000 caracteres.";
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
                RegistrarHistorial(idincidencia, comentario);
                Cargarincidencias();
                CargarHistorial();

                string cuerpoCerrado = "Hola " + incidencia.cliente.Nombre + " " + incidencia.cliente.Apellido + ",\n\n" + "Tu reclamo Nº " + incidencia.Numero + " fue cerrado.\n\n" + "Comentario de cierre: " + comentario + "\n\n" + "Sistema Call Center";
                if (!EnviarAviso(incidencia, "Reclamo Nº " + incidencia.Numero + " cerrado", cuerpoCerrado))
                {
                    lblError.Text = "La incidencia se cerró, pero no se pudo enviar el correo al cliente.";
                    lblError.Visible = true;
                }


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

                string comentarioreapertura = txtComentarioSeguimiento.Text.Trim();
                if (comentarioreapertura == "")
                {
                    comentarioreapertura = "Incidencia reabierta.";
                }
                if (comentarioreapertura.Length > 1000)
                {
                    lblError.Text = "El comentario no puede superar los 1000 caracteres.";
                    lblError.Visible = true;
                    return;
                }

                negocio.Reabrir(idincidencia, Sesion.UsuarioId);
                RegistrarHistorial(idincidencia, comentarioreapertura);
                Cargarincidencias();
                CargarHistorial();


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
                    {
                        if (string.IsNullOrWhiteSpace(comentario))
                        {
                            lblError.Text = "Debés escribir un comentario";
                            lblError.Visible = true;
                            return;
                        }

                        if (comentario.Length > 1000)
                        {
                            lblError.Text = "El comentario no puede superar los 1000 caracteres";
                            lblError.Visible = true;
                            return;
                        }

                        int idIncidencia;

                        if (!int.TryParse(Request.QueryString["id"], out idIncidencia)
                            || idIncidencia <= 0)
                        {
                            lblError.Text = "La incidencia no es válida";
                            lblError.Visible = true;
                            return;
                        }

                        try
                        {
                            IncidenciaGestionNegocio negocioIncidencia = new IncidenciaGestionNegocio();

                            Incidencia incidencia = negocioIncidencia.obtenerporid(idIncidencia);

                            if (incidencia == null)
                            {
                                lblError.Text = "No se encontró la incidencia.";
                                lblError.Visible = true;
                                return;
                            }

                            if (incidencia.Estado.Id == 5)
                            {
                                lblError.Text = "No se pueden agregar seguimientos a una incidencia cerrada";
                                lblError.Visible = true;
                                return;
                            }

                            bool puede = Sesion.EsAdministrador || Sesion.EsSupervisor || incidencia.UsuarioAsignado.Id == Sesion.UsuarioId;
                            if (puede && (incidencia.Estado.Id == 1 || incidencia.Estado.Id == 2 || incidencia.Estado.Id == 6))
                            {
                                negocioIncidencia.pasarenanalisis(idIncidencia, Sesion.UsuarioId);
                            }

                            HistorialIncidencia nuevo = new HistorialIncidencia();

                            nuevo.Incidencia = incidencia;

                            nuevo.Usuario = new Usuario();
                            nuevo.Usuario.Id = Sesion.UsuarioId;

                            nuevo.Comentario = comentario;

                            HistorialIncidenciaNegocio negocioHistorial = new HistorialIncidenciaNegocio();

                            negocioHistorial.Agregar(nuevo);

                            // Actualizar el historial que aparece en pantalla
                            dgvHistorial.DataSource = negocioHistorial.ListarPorIncidencia(idIncidencia);
                            dgvHistorial.DataBind();
                            Cargarincidencias();

                            // Limpiar el comentario
                            txtComentarioSeguimiento.Text = "";

                            lblError.CssClass = "alert alert-success d-block";
                            lblError.Text = "Seguimiento guardado correctamente.";
                            lblError.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());

                            lblError.Text = "No se pudo guardar el seguimiento.";
                            lblError.Visible = true;
                        }

                        break;
                    }

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

        private void CargarHistorial()
        {
            int idIncidencia;

            if (!int.TryParse(Request.QueryString["id"], out idIncidencia) || idIncidencia <= 0)
            {
                return;
            }

            try
            {
                HistorialIncidenciaNegocio negocio = new HistorialIncidenciaNegocio();

                dgvHistorial.DataSource = negocio.ListarPorIncidencia(idIncidencia);
                dgvHistorial.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblError.CssClass = "alert alert-danger d-block";
                lblError.Text = "No se pudo cargar el historial de seguimientos.";
                lblError.Visible = true;
            }
        }

        private void RegistrarHistorial(int idincidencia, string comentario)
        {
            HistorialIncidencia historial = new HistorialIncidencia();
            historial.Incidencia = new Incidencia();
            historial.Incidencia.Id = idincidencia;
            historial.Usuario = new Usuario();
            historial.Usuario.Id = Sesion.UsuarioId;
            historial.Comentario = comentario;
            new HistorialIncidenciaNegocio().Agregar(historial);

        }

        private bool EnviarAviso(Incidencia incidencia, string asunto, string cuerpo)
        {
            try
            {
                EmailService servicio = new EmailService();
                servicio.ArmarCorreo(incidencia.cliente.Email, asunto, cuerpo);
                servicio.EnviarCorreo();
                return true;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }



        }


    }

}
