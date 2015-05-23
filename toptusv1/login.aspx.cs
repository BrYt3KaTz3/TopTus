using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using toptusv1.Login;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace toptusv1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valido"] != null)
            {
               //cuando ya están en sesión, preguntar que tipoi de usuario es nada mas
              
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //boton submit
        {
            login_vendedor obj = new login_vendedor();
            
            try
            {
                string mail = log_usuario.Text;
                string pass = log_password.Text;
                int tipovendedor = 1;

               if (tipovendedor == 1)
               {
                   #region vendedor
                   DataTable validar = obj.validar_usuario(mail, pass); //vendedor

                   if (validar.Rows.Count == 0)
                   {
                       ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);
                   }
                   else
                   {
                       //inicializar session 
                       Session["valido"] = true;
                       Session["usuario"] = validar;
                       Response.Redirect("vendedor/general_perfil.aspx");
                   }//fin else
                   #endregion
               }
               else 
               {
                #region Comprador
                //si es comprador se valida aquí
                   ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);
                #endregion
               }
               

               
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            vendedor.vendedor obj = new vendedor.vendedor();
            
            try
            {
                string mail = txtcorreo.Text;
                
                var usuario = obj.existe_vendedor(mail);
                if (usuario.Rows.Count == 0)
                { //no hay ese mail
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", " error_recuperar()", true);
                }
                else { // si existe
                    string pass = usuario.Rows[0]["pass"].ToString();
                    string mensaje_pass = "<h4>Datos de acceso.</h4><br/><table> ";
                    mensaje_pass += " <tr><td>Correo:</td><td>" + mail + "</td></tr> ";
                    mensaje_pass += "<tr><td>Contraseña:</td><td>" + pass + "</td></tr>";

                    mensaje_pass += "<tr><td colspan='2'><br /><img src='http://demo.toptus.com/imagenes/recuperado.jpg'  tabindex='0'></td></tr></table>";
                    string sub = "Recuperar password";
                    string copia = "ferchomorado@gmail.com";
                    string envio_pass = SendPassword(mail, mensaje_pass, sub, copia);
                    if (envio_pass == "1")
                    { //se envió bien la contra
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", " confirmacion_recuperar()", true);
                       
                    }
                    else
                    { //ocurrió un error 
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", " error_recuperar_dos()", true);
                    }
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
        public static String SendPassword(string para, string mensaje, string subject, string copia)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();

                //Especificamos el correo desde el que se enviará el Email
                //mail.From = new MailAddress("toptustest@gmail.com"); //ok
                mail.From = new MailAddress("recover@toptusmail.com");
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
                SmtpServer.Credentials = new System.Net.NetworkCredential("recover@toptusmail.com", "reco1234");
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


//Response.Redirect("vendedor/vendedor_perfil.aspx");