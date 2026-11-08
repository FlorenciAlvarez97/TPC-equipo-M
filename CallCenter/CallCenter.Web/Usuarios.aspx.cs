using CallCenter.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Dominio;

namespace CallCenter.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargarroles();
                Cargarusuarios();
            }


        }

        private void Cargarroles()
        {
            try
            {

                ddlFiltroRol.DataSource = new RolNegocio().Listar();
                ddlFiltroRol.DataTextField = "Nombre";
                ddlFiltroRol.DataValueField = "Id";
                ddlFiltroRol.DataBind();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudieron cargar los roles.";
                lblError.Visible = true;
            }
        }

        private void Cargarusuarios()
        {

            try
            {
                int? idrol = null;
                if (ddlFiltroRol.SelectedValue != "")
                {
                    idrol = int.Parse(ddlFiltroRol.SelectedValue);
                }

                bool? activo = null;
                if (ddlEstado.SelectedValue != "")
                {
                    activo = ddlEstado.SelectedValue == "1";
                }
                dgvUsuarios.DataSource = new UsuarioNegocio().Buscar(txtBuscar.Text.Trim(), idrol, activo);
                dgvUsuarios.DataBind();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudieron cargar los usuarios.";
                lblError.Visible = true;
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargarusuarios();
        }

        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CambiarEstado") 
            {
                try
                {
                    int id = int.Parse(e.CommandArgument.ToString());
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = negocio.ObtenerPorId(id);
                    negocio.CambiarEstado(id, !usuario.Activo);
                    Cargarusuarios();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblError.Text = "No se pudo cambiar el estado del usuario.";
                    lblError.Visible = true;
                }

            }
        }
    }
}