using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;


namespace toptusv1
{
    public partial class productdetail : System.Web.UI.Page
    {
        DataTable dtcomentarios = new DataTable();
        public string nombre_producto, precio, descripcion, nombre, nick, imagen, img_principal,ruta_foto;
        public int id_vendedor,id_producto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
                {

                    int producto = int.Parse(Request.QueryString["prod"]);
                    hdproducto.Value = producto.ToString();
                    cargar_detalles_producto(producto);
                    cargar_fotos_producto(producto);
                    cargar_comentarios(producto);
                    DataBind();
                    /*try
                    {
                        var coment = Request.QueryString["com"].ToString();

                        if (coment != "0")
                        {
                            txtComentario.Focus();
                        }
                    }
                    catch (Exception)
                    {
                    
                        throw;
                    }*/


                } //fin de , si hay parámetros
                else
                {
                    //cuando no hay parámetros, cargar toooodooooooooooooos los productos
                }
            }
            
        }

        public void cargar_detalles_producto(int idproducto)
        {
            productos_clase obj = new productos_clase();
            var datos = obj.detalle_producto(idproducto);
            if (datos.Rows.Count == 1)
            {
                nombre_producto = datos.Rows[0]["producto"].ToString();
                precio = datos.Rows[0]["precio"].ToString();
                descripcion = datos.Rows[0]["producto_descr"].ToString();
                id_vendedor = int.Parse(datos.Rows[0]["vendedor_id"].ToString());
                id_producto =int.Parse(datos.Rows[0]["producto_id"].ToString());
                cargar_datos_vendedor(id_vendedor);
            }
            else
            {
                nombre_producto = "";
                precio = "";
                descripcion = "Aún no se carga la información de este producto";
            }
        }

        public void cargar_datos_vendedor(int id)
        {
            vendedor.vendedor obj = new vendedor.vendedor();
            var datos = obj.datos_vendedor(id);
            if (datos.Rows.Count == 1)
            {
                nombre = datos.Rows[0]["nombre"].ToString();
                nick = datos.Rows[0]["nick"].ToString();
                imagen = datos.Rows[0]["imagen"].ToString();
                
            }
           
           
            
        }

        public void cargar_fotos_producto(int id)
        { 
            productos_clase obj =new productos_clase();
            var fotos = obj.fotos_por_producto(id);
            var foto_principal = obj.fotos_principal_producto(id);
            if (foto_principal.Rows.Count == 0)
            {
                ruta_foto = "vendedor/prod_fotos/default.png";
            }
            else {
                ruta_foto = foto_principal.Rows[0]["img_ruta"].ToString();
            }
            if (fotos.Rows.Count > 0)
            {
               
                rptFotosPorProducto.DataSource = fotos;
                rptFotosPorProducto.DataBind();
            }
            else
            {
                nofotos.Text = "<h4>No hay fotos para este producto.</h4>";
            }
        }

        protected void btnComentario_Click(object sender, EventArgs e)
        {
            if (Session["valido"] == null)
            {
                //no puede comentar 
                string error = "Debes estar logeado para poder comentar.";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "log_error_comentario_producto('"+error+"')", true);
            }
            else
            {
               
                #region comentario
                productos_clase obj = new productos_clase();
                vendedor.vendedor ven = new vendedor.vendedor();
                int usuario = id_usuario();
                int producto = int.Parse(Request.QueryString["prod"]);
                string comentario = txtComentario.Text;
                

                if (comentario.Length <10)
                {
                    string res = "Teclea un comentario de mínimo 10 caracteres.";
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "log_error_comentario_producto('" + res + "')", true);
                }
                else
                {
                    #region insertar comentario
                    string res = obj.instertar_comentario_producto(comentario, producto, usuario);
                    if (res == "1")
                    {
                        string nombre_vendedor = string.Empty;
                        string nick_vendedor = string.Empty;
                        string mail_vendedor = string.Empty;
                        string nombre_compra = string.Empty;
                        string nick_compra = string.Empty;
                        string mail_compra = string.Empty;

                        //nombre producto y mail del propietario
                        var datos = obj.detalle_producto(producto);
                        if (datos.Rows.Count == 1)
                        {
                            nombre_producto = datos.Rows[0]["producto"].ToString();
                            id_vendedor = int.Parse(datos.Rows[0]["vendedor_id"].ToString());
                            var vendedor = ven.datos_vendedor(id_vendedor);
                            if (vendedor.Rows.Count == 1)
                            {
                                nombre_vendedor = vendedor.Rows[0]["nombre"].ToString();
                                nick_vendedor = vendedor.Rows[0]["nick"].ToString();
                                mail_vendedor = vendedor.Rows[0]["email"].ToString();
                            }
                        } //if detalleproducto
                        //nombre y correo del que envia el comentario
                        var comprador = ven.datos_vendedor(usuario);
                        if (comprador.Rows.Count == 1)
                        {
                            nombre_compra = comprador.Rows[0]["nombre"].ToString();
                            nick_compra = comprador.Rows[0]["nick"].ToString();
                            mail_compra = comprador.Rows[0]["email"].ToString();
                        }
                        string copia_admin = "debug@toptusmail.com";
                        string mensaje = "<table><tr><td>";
                        mensaje += "Hola " + nombre_vendedor + " , el usuario: " + nombre_compra + " - '" + nick_compra + "' ha comentado tu producto: <a href='http://demo.toptus.com/productdetail.aspx?prod="+producto+"' > " + nombre_producto + ".</a><br/><br/>";
                        mensaje += "'" + comentario + "' <br/><br/>";
                        mensaje += "Responde a su dirección web : <a href='mailto:" + mail_compra + "'>" + mail_compra + "</a>";
                        mensaje += "</td></tr></table>";
                        string send = SendMail(mail_vendedor, mensaje, "Comentario a uno de tus productos", copia_admin);
                        if (send == "1")
                        { ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_comentario_producto()", true); }
                        else
                        { ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_comentario_producto_nomail()", true); }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_comentario_producto(" + res + ")", true);
                    }

                    #endregion
                }

                #endregion comentario
                
            }
        }

        protected void btnRespuesta_Click(object sender, EventArgs e)
        {
            if (Session["valido"] == null)
            {
                //no puede comentar 
                string error = "Debes estar logeado para poder comentar.";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "log_error_comentario_producto('" + error + "')", true);
            }
            else
            {
                int usuario =int.Parse(hdusuario.Value); //usuario a responder
                int comentario_id = int.Parse(hdcomentario.Value); //comentario al que se le asignará la respuesta



                foreach (Control item in rptComentarios.Items)
                {
                    TextBox txtQ = (TextBox)item.FindControl("txtRespuesta");
                    string respuesta = txtQ.Text;
                     //hay que obtener, el usuario que responde, al que se le responde y el texto e insertar la respuesta
                    #region respuesta
                    productos_clase obj = new productos_clase();
                    vendedor.vendedor ven = new vendedor.vendedor();
                    int usuario_sesion = id_usuario();
                    int producto = int.Parse(Request.QueryString["prod"]);

                    

                    if (respuesta.Length < 10)
                    {
                        string corto = "Teclea un comentario de mínimo 10 caracteres.";
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "log_error_comentario_producto('" + corto + "')", true);
                    }
                    else
                    {
                        #region insertar comentario
                        string res = obj.insertar_respuesta_comentario(respuesta, comentario_id, usuario_sesion);
                        if (res == "1")
                        {
                            string nombre_recibe = string.Empty;// al que le responden
                            string nick_recibe = string.Empty;
                            string mail_recibe = string.Empty;
                            string nombre_comenta = string.Empty; // el que responde
                            string nick_comenta = string.Empty;
                            string mail_comenta = string.Empty;

                            //a quien se le enviará la notifiación
                            var datos = obj.detalle_producto(producto);
                            if (datos.Rows.Count == 1)
                            {
                                nombre_producto = datos.Rows[0]["producto"].ToString();
                                var recibe = ven.datos_vendedor(usuario);
                                if (recibe.Rows.Count == 1)
                                {
                                    nombre_recibe = recibe.Rows[0]["nombre"].ToString();
                                    nick_recibe = recibe.Rows[0]["nick"].ToString();
                                    mail_recibe = recibe.Rows[0]["email"].ToString();
                                }
                            } //if detalleproducto
                            //nombre y correo del que envia el comentario /sesion
                            var comenta = ven.datos_vendedor(usuario_sesion);
                            if (comenta.Rows.Count == 1)
                            {
                                nombre_comenta = comenta.Rows[0]["nombre"].ToString();
                                nick_comenta = comenta.Rows[0]["nick"].ToString();
                                mail_comenta = comenta.Rows[0]["email"].ToString();
                            }
                            string copia_admin = "debug@toptusmail.com";
                            string mensaje = "<table><tr><td>";
                            mensaje += "Hola " + nombre_recibe + " , el usuario: " + nombre_comenta + " - '" + nick_comenta + "' ha respondido tu comentario en el producto:<a href='http://demo.toptus.com/productdetail.aspx?prod=" + producto + "' > > " + nombre_producto + ".</a><br/><br/>";
                            mensaje += "'" + respuesta + "' <br/><br/>";
                            mensaje += "Responde a su dirección web : <a href='mailto:" + mail_comenta + "'>" + mail_comenta + "</a>";
                            mensaje += "</td></tr></table>";
                            string send = SendMail(mail_recibe, mensaje, "Respuesta de comentario en toptus", copia_admin);
                            if (send == "1")
                            { ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_comentario_producto()", true); }
                            else
                            { ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_comentario_producto_nomail()", true); }

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_comentario_producto(" + res + ")", true);
                        }

                        #endregion
                    }

                    #endregion comentario
                }
                
               
               
                
            } //else logeado
        }

        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

        public void cargar_comentarios(int producto)
        {
            productos_clase obj = new productos_clase();
            var datos = obj.comentarios_por_producto(producto);
            rptComentarios.DataSource = datos;
            num_coments.InnerText = datos.Rows.Count.ToString();
            rptComentarios.DataBind();



        }

        protected void rptComentarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            productos_clase obj = new productos_clase();
            Repeater r = e.Item.FindControl("rptRespuestas") as Repeater;

            var hidden = e.Item.FindControl("hidden_comentario") as HiddenField;
            int id_comentario = int.Parse(hidden.Value);

            if (r != null)
            {
                dtcomentarios = obj.respuestas_por_comentario(id_comentario);
                r.DataSource=dtcomentarios;
                r.DataBind();
            }
        }
        //envio de comentarios a correo del propietario del mismo

        //envio de notificación a usuario propietario del producto
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