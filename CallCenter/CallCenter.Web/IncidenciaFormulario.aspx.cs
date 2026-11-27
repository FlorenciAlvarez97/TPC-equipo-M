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
    public partial class IncidenciaFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlAviso.Visible = false;

            txtDescripcion.Attributes["maxlength"] = "1000";

            if (!IsPostBack)
            {
                pnlUsuarioDemo.Visible = !Sesion.EstaLogueado;

                if (pnlUsuarioDemo.Visible)
                {
                    UsuarioNegocio negocioUsuarios = new UsuarioNegocio();

                    ddlUsuarioDemo.DataSource =
                        negocioUsuarios.Listar().FindAll(u => u.Activo);

                    ddlUsuarioDemo.DataTextField = "NombreUsuario";
                    ddlUsuarioDemo.DataValueField = "Id";
                    ddlUsuarioDemo.DataBind();

                    ddlUsuarioDemo.Items.Insert(0,
                        new ListItem("Seleccioná un usuario de prueba", ""));
                }

                 TipoIncidenciaNegocio negocioTipos = new TipoIncidenciaNegocio();

                 ddlTipo.DataSource = negocioTipos.Listar().FindAll(t => t.Activo);
                 ddlTipo.DataTextField = "Nombre";
                 ddlTipo.DataValueField = "Id";
                 ddlTipo.DataBind();

                 ddlTipo.Items.Insert(0, new ListItem("Seleccioná un tipo de incidencia", ""));


                 PrioridadNegocio negocioPrioridades = new PrioridadNegocio();

                 ddlPrioridad.DataSource = negocioPrioridades.Listar().FindAll(p => p.Activo);
                 ddlPrioridad.DataTextField = "Nombre";
                 ddlPrioridad.DataValueField = "Id";
                 ddlPrioridad.DataBind();

                 ddlPrioridad.Items.Insert(0, new ListItem("Seleccioná una prioridad", ""));
            }




        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            ViewState["IdClienteConfirmado"] = null;
            int idCliente;

            if (!int.TryParse(txtNumeroCliente.Text, out idCliente) || idCliente <= 0)
            {
                lblClienteEncontrado.Text = "Ingresá un número de cliente válido.";
                lblClienteEncontrado.Visible = true;
                return;
            }

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.obtenerporId(idCliente);

                if (cliente == null || !cliente.Activo)
                {
                    lblClienteEncontrado.Text = "No se encontró un cliente activo con ese número.";
                    lblClienteEncontrado.Visible = true;
                    return;
                }

                ViewState["IdClienteConfirmado"] = cliente.Id;
                lblClienteEncontrado.Text =
                    "Nombre: " + Server.HtmlEncode(cliente.Nombre) +  " " + Server.HtmlEncode(cliente.Apellido) + " | Email: " + Server.HtmlEncode(cliente.Email) +  " | Teléfono: " + Server.HtmlEncode(cliente.Telefono ?? "Sin teléfono");
                lblClienteEncontrado.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblClienteEncontrado.Text = "No se pudo buscar el cliente.";
                lblClienteEncontrado.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }


            int idCliente;

            if (!int.TryParse(txtNumeroCliente.Text, out idCliente) || idCliente <= 0)
            {
                lblClienteEncontrado.Text = "Ingresá un número de cliente válido.";
                lblClienteEncontrado.Visible = true;
                return;
            }

            if (ViewState["IdClienteConfirmado"] == null || (int)ViewState["IdClienteConfirmado"] != idCliente)
            {
                lblClienteEncontrado.Text = "Primero debés buscar y confirmar el cliente.";
                lblClienteEncontrado.Visible = true;
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.obtenerporId(idCliente);

            if (cliente == null || !cliente.Activo)
            {
                ViewState["IdClienteConfirmado"] = null;
                lblClienteEncontrado.Text = "El cliente no existe o está inactivo.";
                lblClienteEncontrado.Visible = true;
                return;
            }


            int idTipo;
            int idPrioridad;

            if (!int.TryParse(ddlTipo.SelectedValue, out idTipo) || idTipo <= 0)
            {
                lblClienteEncontrado.Text = "Debés seleccionar un tipo de incidencia.";
                lblClienteEncontrado.Visible = true;
                return;
            }

            if (!int.TryParse(ddlPrioridad.SelectedValue, out idPrioridad) || idPrioridad <= 0)
            {
                lblClienteEncontrado.Text = "Debés seleccionar una prioridad.";
                lblClienteEncontrado.Visible = true;
                return;
            }

            Incidencia nueva = new Incidencia();

            nueva.cliente = cliente;
            nueva.Tipo = new TipoIncidencia();
            nueva.Tipo.Id = idTipo;

            nueva.prioridad = new Prioridad();
            nueva.prioridad.Id = idPrioridad;

            nueva.Descripcion = txtDescripcion.Text;


            int idUsuarioCreador;

            if (Sesion.EstaLogueado)
            {
                idUsuarioCreador = Sesion.UsuarioId;
            }
            else
            {
                if (!Request.IsLocal)
                {
                    lblClienteEncontrado.Text = "Debés iniciar sesión.";
                    lblClienteEncontrado.Visible = true;
                    return;
                }

                if (!int.TryParse(ddlUsuarioDemo.SelectedValue,
                    out idUsuarioCreador) || idUsuarioCreador <= 0)
                {
                    lblClienteEncontrado.Text = "Seleccioná un usuario de prueba.";
                    lblClienteEncontrado.Visible = true;
                    return;
                }

                Usuario usuarioPrueba =
                    new UsuarioNegocio().ObtenerPorId(idUsuarioCreador);

                if (usuarioPrueba == null || !usuarioPrueba.Activo)
                {
                    lblClienteEncontrado.Text =
                        "El usuario de prueba no existe o está inactivo.";
                    lblClienteEncontrado.Visible = true;
                    return;
                }
            }

            nueva.UsuarioCreador = new Usuario();
            nueva.UsuarioCreador.Id = idUsuarioCreador;


            try
            {
                IncidenciaNegocio negocioIncidencia = new IncidenciaNegocio();

                int numeroGenerado = negocioIncidencia.Agregar(nueva);

                // Prepara el correo
                bool correoEnviado = false;

                try
                {
                    EmailService servicio = new EmailService();

                    string asunto = "Alta de incidencia Nº " + numeroGenerado;

                    string cuerpo = "Hola " + cliente.Nombre + " " + cliente.Apellido + ",\n\n" + "Tu reclamo fue registrado correctamente.\n\n" + "Número de reclamo: " + numeroGenerado + "\n" +
                                    "Tipo de incidencia: " + ddlTipo.SelectedItem.Text + "\n" + "Prioridad: " + ddlPrioridad.SelectedItem.Text + "\n" + "Estado: Abierto\n" +
                                    "Descripción: " + nueva.Descripcion + "\n\n" + "Conservá este número para consultar tu reclamo.\n\n" + "Sistema Call Center";

                    servicio.ArmarCorreo(cliente.Email, asunto, cuerpo);
                    servicio.EnviarCorreo();
                    correoEnviado = true;
                }
                catch (Exception errorCorreo)
                {
                    System.Diagnostics.Debug.WriteLine(errorCorreo.ToString());
                }

                txtNumeroCliente.Text = "";
                txtDescripcion.Text = "";

                ddlTipo.SelectedIndex = 0;
                ddlPrioridad.SelectedIndex = 0;

                if (pnlUsuarioDemo.Visible)
                {
                    ddlUsuarioDemo.SelectedIndex = 0;
                }

                ViewState["IdClienteConfirmado"] = null;


                if (correoEnviado)
                {
                    lblAviso.Text = "La incidencia Nº " + numeroGenerado + " se guardó correctamente. Correo enviado";
                }
                else
                {
                    lblAviso.Text = "La incidencia Nº " + numeroGenerado + " se guardó correctamente, pero no se pudo enviar el correo.";
                    pnlAviso.CssClass = "alert alert-warning alert-dismissible fade show shadow";
                }

                lblClienteEncontrado.Text = "";
                lblClienteEncontrado.Visible = false;
                pnlAviso.Visible = true;
            }
            catch (ArgumentException ex)
            {
                lblClienteEncontrado.Text = Server.HtmlEncode(ex.Message);
                lblClienteEncontrado.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblClienteEncontrado.Text = "No se pudo guardar la incidencia.";
                lblClienteEncontrado.Visible = true;
            }

        }
    }
}