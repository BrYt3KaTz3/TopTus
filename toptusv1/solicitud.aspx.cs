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
                if (cbTerminos.Checked == false)
                {//if terminos
                    string terminos = "Tienes que aceptar los términos y condiciones del sitio.";
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud('" + terminos + "')", true);
                } //ifedn terminos
                else { //else terminos

                    if (existe.Rows.Count == 0)
                    {

                        string res = obj.insertar_solicitud(nombre, apellidop, apellidom, email, fechasol, pass);
                        //string res = "1";
                        // Console.Write(res);
                        if (res == "1")
                        {
                            try
                            {
                                //para el que solicita
                                string para_solicitud = sol_email.Text;
                                string subject_solicitud = "Toptus Confirmación";
                                string copia_solicitud = "debug@toptusmail.com";
                                string mensaje_solicitud = "<table ><tr><td><img src='http://demo.toptus.com/imagenes/BienvenidoTopTus.png' /></td></tr><tr><td style='font-size:24px;'>";
                                mensaje_solicitud += "Bienvenido a Toptus " + nombre;
                                mensaje_solicitud += "<br/> Por favor accede al siguiente link para poder activar tu cuenta";
                                mensaje_solicitud += "<br/> Hecho esto , te recomendamos que inicies sesión y llenes<br/> los datos de vendedor para hacer que nuestros <br/> usuarios te contacten.";
                               
                                string correo_activacion = encriptar_url(email);
                                mensaje_solicitud += "<br/> <a href='http://demo.toptus.com/activacion.aspx?usr=" + correo_activacion + "' target='_blank'>Activar mi cuenta </a>";
                                mensaje_solicitud += "</td></tr></table>";
                                string envio_solicitud = SendMail(para_solicitud, mensaje_solicitud, subject_solicitud, copia_solicitud);
                                //para los admins
                                string para_admin = "ferchomorado@gmail.com";
                                string subject_admin = "Toptus Alerta de Inscripción";
                                string copia_admin = "debug@toptusmail.com";
                                string mensaje_admin = "Se ha unido a TopTus el usuario con correo: " + sol_email.Text;
                                
                                
                                string envio_admin = SendMail(para_admin, mensaje_admin, subject_admin, copia_admin);

                                if (envio_solicitud == "1" && envio_admin == "1")
                                {
                                    //enviar a confirmación, si se envió mail
                                    string correo = encriptar_url(email);
                                   
                                    Response.Redirect("confirmacion.aspx?status=1&usr=" + correo);
                                }
                                else
                                {
                                    //solicitud enviada pero correo no
                                    //string mensaje = "Te has dado de alta correctamente, solo lamentamos informarte que el correo de bienvenida no fue posible de enviar. Ingresa a toptus y entra con tus datos de la solicitud.";
                                    string correo = encriptar_url(email);
                                    Response.Redirect("confirmacion.aspx?status=2&usr=" + correo);
                                   // ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud('"+mensaje+"')", true);
                                }
                            }
                            catch (Exception)
                            {

                                ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud('Error:"+res+"')", true);
                            }

                        }
                        else //if res
                        {
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud('Error:" + res + "')", true);
                        }
                    } //if existe
                    else
                    {
                        string yaexiste = "Ya existe el correo: "+email+ " dado de alta.";
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud('"+yaexiste+"')", true);
                    }

                } //fin terminos
                

            }
            catch (Exception error)
            {

                throw error;
            }
        }


        public string encriptar_url(string id_producto)
        {
            string encriptado = seguridad.Encriptar(id_producto);
            return encriptado;
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