using CallCenter.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Web
{
    public partial class CorreoPrueba : System.Web.UI.Page
    {
        protected void btnProbarCorreo_Click(object sender, EventArgs e)
        {

            try
            {
                EmailService servicio = new EmailService();

                servicio.ArmarCorreo( "prueba@example.com", "Prueba de correo - Call Center", "¡Hola! Este es nuestro primer correo de prueba." );

                servicio.EnviarCorreo();

                lblResultado.Text = "Correo enviado a Mailtrap correctamente.";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                lblResultado.Text = "Ocurrió un error al enviar el correo.";
            }


        }
    }
}