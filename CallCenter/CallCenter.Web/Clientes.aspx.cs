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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();

            }
        }
        private void CargarClientes()
        {
            try
            {
                bool? activo = null;
                if (ddlEstado.SelectedValue == "1")
                {
                    activo = true;
                }

                else if (ddlEstado.SelectedValue == "0")
                {
                    activo = false;
                }

                ClienteNegocio negocio = new ClienteNegocio();
                dgvClientes.DataSource = negocio.Buscar(txtBuscar.Text.Trim(), activo);
                dgvClientes.DataBind();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = Server.HtmlEncode(ex.ToString());//"No se pudieron cargar los clientes: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }
        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "CambiarEstado")
            {
                return;
            }
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.obtenerporId(id);
                if (cliente != null)
                {
                    negocio.cambiarestado(id, !cliente.Activo);
                }
                CargarClientes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudo cambiar el estado del cliente.";
                lblError.Visible = true;
            }
        }
    }
}