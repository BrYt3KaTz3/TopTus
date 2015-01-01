using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace toptusv1.vendedor
{
    public partial class vendedor_perfil : System.Web.UI.Page
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
                // var usuario = HttpContext.Current.Session["usuario"];
                cargar_datos();

            }
        }

        public void cargar_datos() // a la pestaña de login
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;

           // Response.Write(usuario.Rows[0]);
            string nombre = usuario.Rows[0]["nombre"].ToString();
            string apellido_m = usuario.Rows[0]["apellido_m"].ToString();
            string apellido_p = usuario.Rows[0]["apellido_p"].ToString();
            string email = usuario.Rows[0]["email"].ToString();
            string fecha_ingreso = usuario.Rows[0]["fecha_ingreso"].ToString();
            //agregar campos que faltan

            //cargar txtbox
            ven_nombre.Text = nombre;
            ven_apellidop.Text = apellido_p;
            ven_apellidom.Text = apellido_m;
            ven_email.Text = email;



        }
    }
}