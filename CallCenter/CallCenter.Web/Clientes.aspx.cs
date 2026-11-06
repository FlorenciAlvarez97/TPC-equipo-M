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
                ClienteNegocio negocio = new ClienteNegocio();
                dgvClientes.DataSource = negocio.Listar();
                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudieron cargar los clientes.";
                lblError.Visible = true;
            }
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