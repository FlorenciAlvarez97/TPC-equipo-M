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
            if (!IsPostBack)
            {
                try
                {

                    RolNegocio negocio = new RolNegocio();
                    ddlRol.DataSource = negocio.Listar();
                    ddlRol.DataTextField = "Nombre";
                    ddlRol.DataValueField = "Id";
                    ddlRol.DataBind();


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudieron cargar los roles.";
                    lblError.Visible = true;
                }
            }




        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioNegocio negocio = new UsuarioNegocio();
                if (negocio.ExisteNombreUsuario(txtNombreUsuario.Text.Trim(), 0))
                {
                    lblError.Text = "El nombre de usuario ya existe.";
                    lblError.Visible = true;
                    return;
                }

                Usuario nuevo = new Usuario();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.NombreUsuario = txtNombreUsuario.Text.Trim();
                nuevo.Contraseña = txtContrasena.Text.Trim();
                nuevo.Rol = new RolUsuario();
                nuevo.Rol.Id = int.Parse(ddlRol.SelectedValue);
                nuevo.Activo = chkActivo.Checked;
                negocio.Agregar(nuevo);
                Response.Redirect("Usuarios.aspx");


            }
            catch (Exception ex)
            {
                lblError.Text = "No se pudo guardar el usuario. Error: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}