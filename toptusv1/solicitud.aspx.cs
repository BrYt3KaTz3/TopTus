﻿using System;
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

                    string res = obj.insertar_solicitud(nombre, apellidop, apellidom, email, fechasol,pass);
                   // string res = "1";
                   // Console.Write(res);
                    if (res == "1")
                    {
                        try
                        {
                            //para el que solicita
                            string para_solicitud = sol_email.Text;
                            string subject_solicitud = "Toptus Confirmación";
                            string copia_solicitud = "luisfernandomtv@hotmail.com";
                            string mensaje_solicitud = "<table><tr><td><img src='http://demo.toptus.com/imagenes/BienvenidoTopTus.png' /></td></tr><tr><td>";
                            mensaje_solicitud += "Bienvenido a Toptus "+nombre;
                            mensaje_solicitud += "<br/> Ahora puedes acceder al sitio y subir tu<br/> información y productos.";
                            mensaje_solicitud += "<br/> Te recomendamos que inicies sesión y llenes<br/> los datos de vendedor para hacer que nuestros <br/> usuarioste contacten más facilmente.";
                            mensaje_solicitud += "<br/> Usuario: "+email;
                            mensaje_solicitud += "<br/> Pass: " + pass;
                            mensaje_solicitud += "<br/> <a href='http://demo.toptus.com/login.aspx' target='_blank'>Login </a>";
                            mensaje_solicitud+="</td></tr></table>";
                            string envio_solicitud = SendMail(para_solicitud, mensaje_solicitud, subject_solicitud, copia_solicitud);
                            //para los admins
                            string para_admin = "ferchomorado@gmail.com";
                            string subject_admin = "Toptus Alerta de Inscripción";
                            string copia_admin = "luisfernandomtv@hotmail.com";
                            string mensaje_admin = "Se ha unido a TopTus el usuario con correo: "+sol_email.Text;
                            mensaje_admin += "<br/>Sigue el siguiente enlace y teclea tus credenciales para aprobar o rechazar la solicitud";
                            mensaje_admin += "<br/><a href='http://demo.toptus.com/admin/a_solicitud.aspx'>Solicitudes</a>";
                            string envio_admin = SendMail(para_admin, mensaje_admin, subject_admin, copia_admin);
                            
                            if (envio_solicitud == "1" && envio_admin == "1")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_solicitud()", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "mensaje", "alert('Te has dado de alta correctamente, solo lamentamos informarte que el correo de bienvenida no fue posible de enviar. Ingresa a toptus y entra con tus datos de la solicitud."+envio_admin+"')", true);
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
                SmtpClient SmtpServer = new SmtpClient("toptusmail.com");
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