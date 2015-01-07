using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace toptusv1.vendedor
{
    public partial class fotoperfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["valido"] == null)
                {
                    Response.Redirect("../login.aspx");
                }
                //else.... usuario válido
                else
                {
                    // var usuario = HttpContext.Current.Session["usuario"];
                    var sesion = HttpContext.Current.Session["usuario"];

                    DataTable usuario = (DataTable)sesion;
                    // cargar imagen si existe
                    string imagen = usuario.Rows[0]["imagen"].ToString();
                    if (imagen != "")
                    {
                        string path = "perfil/" + imagen;
                        imgViewFile.ImageUrl = path;
                    }
                    else
                    {
                        imgViewFile.ImageUrl = "http://ilasitc.org/images/Userimage.jpg";
                       
                    }


                }
            } //postback
            
        }

        protected void btnfoto_Click(object sender, EventArgs e)
        {
            var sesion = HttpContext.Current.Session["usuario"];
            vendedor obj = new vendedor();
            DataTable usuario = (DataTable)sesion;

            // var hidden = e.Item.FindControl("hidden_detalle") as HiddenField;
            string id_usuario = usuario.Rows[0]["vendedor_id"].ToString();
            string extension = System.IO.Path.GetExtension(FileUpload1.FileName); //obtener la extensión del archivo
            string path = Server.MapPath("perfil/") + id_usuario + extension;
            if (FileUpload1.HasFile)//true
            {
                //insertar el nombre en la bd
                string imagen = id_usuario +extension;
                string res = obj.insert_foto_perfil(int.Parse(id_usuario), imagen);
                if (res == "1")
                {
                    File.Delete(path);
                    FileUpload1.PostedFile.SaveAs(path);

                    Session.Clear();
                    // Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    Session["usuario"] = obj.usuario_actualizado(int.Parse(id_usuario));
                    Session["valido"] = true;

                    imgViewFile.ImageUrl =Server.MapPath("perfil/") + usuario.Rows[0]["imagen"].ToString();

                   // ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                    Response.Redirect("fotoperfil.aspx");
                }
                else 
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar_foto('" + res + "')", true);
                }
                

            }
            else {
                imgViewFile.ImageUrl = "http://ilasitc.org/images/Userimage.jpg";
            }
        }
    }
}