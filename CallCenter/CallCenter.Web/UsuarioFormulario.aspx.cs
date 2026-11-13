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
    public partial class UsuarioFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rfvContrasena.Enabled = Request.QueryString["id"] == null;

            if (!IsPostBack)
            {
                try
                {

                    RolNegocio negocio = new RolNegocio();
                    ddlRol.DataSource = negocio.Listar();
                    ddlRol.DataTextField = "Nombre";
                    ddlRol.DataValueField = "Id";
                    ddlRol.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        Cargausuario(int.Parse(Request.QueryString["id"]));
                    }


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudieron cargar los roles.";
                    lblError.Visible = true;
                }
            }

        }

        private void Cargausuario(int id)
        {
            tituloPagina.InnerText = "Editar usuario";
            Usuario usuario = new UsuarioNegocio().ObtenerPorId(id);
            if (usuario == null)
            {
                Response.Redirect("Usuarios.aspx", false);
                return;
            }

            txtNombre.Text = usuario.Nombre;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            ddlRol.SelectedValue = usuario.Rol.Id.ToString();
            chkActivo.Checked = usuario.Activo;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                return;
            }
            try
            {
                int id = 0;
                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"]);
                }
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (negocio.ExisteNombreUsuario(txtNombreUsuario.Text.Trim(), id))
                {
                    lblError.Text = "Ya existe un usuario con ese nombre de usuario.";
                    lblError.Visible = true;
                    return;
                }
                Usuario usuario = new Usuario();
                usuario.Id = id;
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.NombreUsuario = txtNombreUsuario.Text.Trim();
                usuario.Contraseña = txtContrasena.Text;
                usuario.Rol = new RolUsuario();
                usuario.Rol.Id = int.Parse(ddlRol.SelectedValue);
                usuario.Activo = chkActivo.Checked;
                if (id > 0)
                {
                    negocio.Modificar(usuario);
                }
                else
                {
                    negocio.Agregar(usuario);
                }
                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "No se pudo guardar el usuario: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}