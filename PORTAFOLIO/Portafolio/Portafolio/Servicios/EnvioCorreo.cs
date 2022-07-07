using System.Net;
using System.Net.Mail;
using System.Text;

namespace Portafolio.Servicios
{
    public class EnvioCorreo
    {
        public bool EnviarCorreo( string htmlmensaje, string correodestino, string asunto, ref string mensajeerror/*, byte[] ReportMemory*/)
        {
            MailMessage email = null;
            try
            {
                string host = "";
                string from = ""; 
                int puerto = 587;
                bool ssl = true;
                string usuario = "";
                string contrasena = "";

                email = MailMessage(correodestino, from, asunto, htmlmensaje/*, ReportMemory*/);
                ClienteSmtp(host, puerto, ssl, usuario, contrasena).Send(email);
                email.Dispose();
                mensajeerror = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                //   email.Dispose();
                mensajeerror = ex.Message;
                return false;
            }

        }
        private SmtpClient ClienteSmtp(string Host, int Port, bool EnableSsl, string NetworkUsuario, string NetworkPassword)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = EnableSsl;
            smtp.Credentials = new NetworkCredential(NetworkUsuario, NetworkPassword);
            return smtp;
        }
        private MailMessage MailMessage(string To, string From, string Subject, string Mensaje/*, byte[] reporteMemory*/)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(To));
            email.From = new MailAddress(From, "Sistema PORTAFOLIO", Encoding.UTF8);
            email.Subject = Subject;
            email.Body = Mensaje;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //email.Attachments.Add(new Attachment(new MemoryStream(reporteMemory), "prueba.pdf"));
            //mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "" + nombrePDF  + "-" + vcCodigoSede + ".pdf"));
            return email;
        }
    }
}
