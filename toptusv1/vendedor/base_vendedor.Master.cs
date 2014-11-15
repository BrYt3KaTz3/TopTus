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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valido"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            //else.... usuario válido
            else
            {
                var usuario = HttpContext.Current.Session["usuario"];
                cargar_datos();
                string a;
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
            var sesion = Session["usuario"];
            ArrayList usuario = (ArrayList)sesion;
            string nombre = usuario[1].ToString();
            enlace_vendedor.InnerText = nombre;

        }
    }
}

