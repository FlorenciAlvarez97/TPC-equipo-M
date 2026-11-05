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



        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Activo = chkActivo.Checked;
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.agregar(nuevo);
                Response.Redirect("Clientes.aspx", false);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblError.Text = "No se pudo guardar el cliente.";
                lblError.Visible = true;
            }
        }
    }
}