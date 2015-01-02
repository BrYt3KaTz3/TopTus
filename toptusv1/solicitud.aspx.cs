using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace toptusv1.vendedor
{
    public partial class solicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_solicitud_Click(object sender, EventArgs e)
        {
            vendedor obj = new vendedor();


            try
            {
                string nombre = sol_nombre.Text;
                string apellidop = sol_apellidop.Text;
                string apellidom = sol_apellidom.Text;
                string email = sol_email.Text;
                string pass = sol_pass.Text;
                var existe = obj.existe_vendedor(email);//verifica si hay un email registrado
                DateTime fechasol = DateTime.Today;
                if (existe.Rows.Count == 0)
                {

                    string res = obj.insertar_solicitud(nombre, apellidop, apellidom, email, fechasol);
                   // string res = "1";
                    Console.Write(res);
                    if (res == "1")
                    {
                        try
                        {
                            //para el que solicita
                            string para_solicitud = sol_email.Text;
                            string subject_solicitud = "Toptus Request Confirmation";
                            string copia_solicitud = "luisfernandomtv@hotmail.com";
                            string mensaje_solicitud = "Your request has been processed successfully.<br/> Let us verify it and we will respond promptly ";
                            mensaje_solicitud += "<br/> Please do not answer this mail";
                            mensaje_solicitud += "<br/> <a href='www.demo.toptus.com' target='_blank'>Visit TopTus.com </a>";
                            string envio_solicitud = SendMail(para_solicitud, mensaje_solicitud, subject_solicitud, copia_solicitud);
                            //para los admins
                            string para_admin = "ferchomorado@gmail.com";
                            string subject_admin = "Toptus Alerta de Solicitud";
                            string copia_admin = "luisfernandomtv@hotmail.com";
                            string mensaje_admin = "Hay una nueva solicitud de vendedor con correo: "+sol_email.Text;
                            mensaje_admin += "<br/>Sigue el siguiente enlace y teclea tus credenciales para aprobar o rechazar la solicitud";
                            mensaje_admin += "<br/><a href='http://demo.toptus.com/admin/a_solicitud.aspx'>Solicitudes</a>";
                            string envio_admin = SendMail(para_admin, mensaje_admin, subject_admin, copia_admin);
                            
                            if (envio_solicitud == "1" && envio_admin == "1")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_solicitud()", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "mensaje", "alert('Request sent, confirmation mail has not been succesfully sent')", true);
                            }
                        }
                        catch (Exception)
                        {

                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud()", true);
                        }
                        
                    }
                    else //if res
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud()", true);
                    }
                } //if existe
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "mail_ya_registrado()", true);
                }

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public static String SendMail(string para, string mensaje, string subject, string copia)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();

                //Especificamos el correo desde el que se enviará el Email
                mail.From = new MailAddress("toptustest@gmail.com");
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = mensaje;
                mail.To.Add(para); //aqui va el correo tecleado, o sea del que hace la solicitud o los admins
                mail.Bcc.Add(copia);//copia oculta de la solicitud
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

                //Configuracion del SMTP 
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587; //Puerto que utiliza gmail, mocha es el 25


                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("toptustest@gmail.com", "toptus1234");
                SmtpServer.EnableSsl = true;
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