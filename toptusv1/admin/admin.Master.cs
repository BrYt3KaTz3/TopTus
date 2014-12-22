using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valido_admin"] == null)
            {
                Response.Redirect("login_a.aspx");
            }
            //else.... usuario válido
            else
            {
                var usuario_admin = HttpContext.Current.Session["usuario_admin"];
                cargar_datos();
               
            }
        }

        public void cargar_datos() // a la pestaña de login
        {
            var sesion = HttpContext.Current.Session["usuario_admin"];
            DataTable usuario = (DataTable)sesion;


            string nombre = usuario.Rows[0]["nombre"].ToString();
            enlace_vendedor.InnerText = nombre;

        }

        protected void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("login_a.aspx");
        }
    }
}