using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1
{
   
    public partial class base_vendedor : System.Web.UI.MasterPage
    {
       public TextBox usuario_id
        {
            get { return this.usuario_id_master; }
        }

      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valido"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            //else.... usuario válido
            else
            {
               // var usuario = HttpContext.Current.Session["usuario"];
                cargar_datos();
               
            }
        }

        protected void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("../Index.aspx");
        }

        public void cargar_datos() // a la pestaña de login
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;

            
            string nombre = usuario.Rows[0]["nombre"].ToString();
            string id_vendedor = usuario.Rows[0]["vendedor_id"].ToString();
            usuario_id_master.Text = id_vendedor;
            enlace_vendedor.InnerText = nombre;

        }
    }

   
}

