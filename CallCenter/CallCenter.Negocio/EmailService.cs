using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace CallCenter.Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient servidor;

        public EmailService()
        {
            servidor = new SmtpClient();

            servidor.Host = "sandbox.smtp.mailtrap.io";
            servidor.Port = 2525;
            servidor.EnableSsl = true;
            servidor.UseDefaultCredentials = false;


            string usuario = Environment.GetEnvironmentVariable("MAILTRAP_SMTP_USER");

            string contrasena = Environment.GetEnvironmentVariable("MAILTRAP_SMTP_PASSWORD");

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                throw new InvalidOperationException( "Faltan configurar las credenciales");
            }

            servidor.Credentials = new NetworkCredential(usuario, contrasena);
        }



        public void ArmarCorreo(string destinatario,string asunto, string cuerpo)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
            {
                throw new ArgumentException( "El correo del destinatario es obligatorio.");
            }

            email = new MailMessage();
            email.From = new MailAddress("no-responder@example.com", "Sistema Call Center");


            email.To.Add(destinatario);
            email.Subject = asunto;
            email.Body = cuerpo;
            email.IsBodyHtml = false;
        }

        public void EnviarCorreo()
        {
            if (email == null)
            {
                throw new InvalidOperationException( "No se armó el correo");
            }

            try
            {
                servidor.Send(email);
            }
            finally
            {
                email.Dispose();
                email = null;
                servidor.Dispose();
            }
        }

    }
}
