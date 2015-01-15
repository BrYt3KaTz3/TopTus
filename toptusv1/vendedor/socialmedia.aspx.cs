using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace toptusv1.vendedor
{
    public partial class socialmedia : System.Web.UI.Page
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
                   

                    cargar_datos();


                }
            } //postback
        }

        public void cargar_datos()
        {
            int usuario = id_usuario();
            vendedor obj = new vendedor();
            var res = obj.redes_sociales(usuario);
            if (res.Rows.Count == 1)
            {
                redes_facebook.Text = res.Rows[0]["facebook"].ToString();
                redes_twitter.Text = res.Rows[0]["twitter"].ToString();
                redes_google.Text = res.Rows[0]["googleplus"].ToString();
                redes_instagram.Text = res.Rows[0]["instagram"].ToString();
                redes_linked.Text = res.Rows[0]["linkedin"].ToString();
            }
        }

      

        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

        protected void btnRedes_Click(object sender, EventArgs e)
        {
            int usuario= id_usuario();
            vendedor obj = new vendedor();
            string face = redes_facebook.Text;
            string tw = redes_twitter.Text;
            string gg = redes_google.Text;
            string ins = redes_instagram.Text;
            string lk = redes_linked.Text;
            string accion;
            var res = obj.redes_sociales(usuario);
            if (res.Rows.Count == 1) //update
            {
                accion = "actualizar";
                string resins =obj.insert_redes_sociales(usuario, face, tw, gg, ins, lk, accion);
                if (resins == "1")
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + resins + "')", true);
                }
            }
            else //insert
            {
                accion = "insertar";
               string resins=obj.insert_redes_sociales(usuario,face, tw, gg, ins, lk,accion);
               if (resins == "1")
               {
                   ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
               }
               else
               {
                   ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + resins + "')", true);
               }
            }


        }
    }
}