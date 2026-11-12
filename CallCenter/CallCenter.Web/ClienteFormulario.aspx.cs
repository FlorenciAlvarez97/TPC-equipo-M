using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Dominio;
using CallCenter.Negocio;

namespace CallCenter.Web
{
    public partial class ClienteFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    CargarCliente(id);
                }
            }
        }

        private void CargarCliente(int id)
        {
            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.obtenerporId(id);
                if (cliente == null)
                {
                    Response.Redirect("Clientes.aspx", false);
                    return;
                }

                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;
                chkActivo.Checked = cliente.Activo;
                tituloPagina.InnerText = "Editar Cliente";
                Title = "Editar Cliente";

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar cliente: " + ex.ToString());
                lblError.Text = "Ocurrió un error al cargar el cliente. Por favor, inténtelo de nuevo más tarde.";
                lblError.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Activo = chkActivo.Checked;

                ClienteNegocio negocio = new ClienteNegocio();
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    cliente.Id = id;
                    negocio.modificar(cliente);
                }
                else
                {
                    negocio.agregar(cliente);
                }
                Response.Redirect("Clientes.aspx", false);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudo guardar el cliente.";
                lblError.Visible = true;
            }
        }


    }
}