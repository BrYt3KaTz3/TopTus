using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace toptusv1
{
    public partial class _base : System.Web.UI.MasterPage
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            
           

            if (Session["valido"] == null)
            {
                logeado.Visible = false;
                login.Visible = true;
            }
            else
            {
                logeado.Visible = true;
                login.Visible = false;
                cargar_datos();
            }
        }

        public void cargar_datos() // a la pestaña de login
        {
        var sesion = Session["usuario"];
        ArrayList usuario =(ArrayList)sesion;
        string nombre = usuario[1].ToString();
        enlace_vendedor.InnerText = nombre;
            
        }

        protected void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Index.aspx");
        }
    }
}