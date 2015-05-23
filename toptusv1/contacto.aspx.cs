using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace toptusv1
{
    public partial class contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnComentario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = con_nombre.Text;
                string empresa = con_empresa.Text;
                string direccion = con_direccion.Text;
                string pais = con_pais.Text;
                string ciudad = con_ciudad.Text;
                string tel = con_tel.Text;
                string mail = con_mail.Text;
                string comentario = con_comentario.Text;
                string mensaje_comentario = "<table><tr><td>Nombre:</td><td>"+nombre+"</td></tr> ";
                mensaje_comentario += "<tr><td>Empresa:</td><td>" + empresa + "</td></tr>";
                mensaje_comentario += "<tr><td>Dirección:</td><td>" + direccion + "</td></tr>";
                mensaje_comentario += "<tr><td>País:</td><td>" + pais + "</td></tr>";
                mensaje_comentario += "<tr><td>Ciudad:</td><td>" + ciudad + "</td></tr>";
                mensaje_comentario += "<tr><td>Teléfono:</td><td>" + tel + "</td></tr>";
                mensaje_comentario += "<tr><td>Mail:</td><td>" + mail + "</td></tr>";
                mensaje_comentario += "<tr><td>Comentario:</td><td>" + comentario + "</td></tr>";
                mensaje_comentario += "</table>";
                
                string envio_comentario = SendMail("info@toptus.com", mensaje_comentario, "Comentario recibido en toptus.com", "luisfernandomtv@hotmail.com");
                //string envio_comentario = "0";

                if (envio_comentario == "1")
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_comentario()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_comentario()", true);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static String SendMail(string para, string mensaje, string subject, string copia)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();

                //Especificamos el correo desde el que se enviará el Email
                //mail.From = new MailAddress("toptustest@gmail.com"); //ok
                mail.From = new MailAddress("info@toptusmail.com");
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = mensaje;

                mail.To.Add(para); //aqui va el correo tecleado, o sea del que hace la solicitud o los admins
                mail.Bcc.Add(copia);//copia oculta de la solicitud
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

                //Configuracion del SMTP 
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); /7ok
                SmtpClient SmtpServer = new SmtpClient("mail.servergrove.com");
                //SmtpServer.Port = 587; //ok
                SmtpServer.Port = 587; //Puerto que utiliza gmail, mocha es el 25


                //Especificamos las credenciales con las que enviaremos el mail
                //SmtpServer.Credentials = new System.Net.NetworkCredential("toptustest@gmail.com", "toptus1234");
                //SmtpServer.EnableSsl = true;

                // Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("info@toptusmail.com", "dolce1234");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}