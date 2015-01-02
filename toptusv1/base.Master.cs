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
        DataTable dtcategorias = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           

            if (Session["valido"] == null)
            {
                logeado.Visible = false;
                capa_login.Visible = true;
                cargar_categorias(); //para el repeater del menú
            }
            else
            {
                logeado.Visible = true;
                capa_login.Visible = false;
                cargar_datos();
                cargar_categorias(); //para el repeater del menú
            }
        }

        public void cargar_datos() // a la pestaña de login
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;


            string nombre = usuario.Rows[0]["nombre"].ToString();
            enlace_vendedor.InnerText = nombre;

        
            
        }
        public DataTable cargar_categorias()
        {
            categorias_menu obj = new categorias_menu();
            dtcategorias= obj.categorias();
            repeater_categorias.DataSource = dtcategorias;
            repeater_categorias.DataBind();
            return dtcategorias;
            
        }

        protected void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Index.aspx");
        }

        protected void repeater_categorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
             categorias_menu obj = new categorias_menu();
            Repeater r = e.Item.FindControl("repeater_subcategorias") as Repeater;

            var hidden = e.Item.FindControl("hidden_categoria") as HiddenField;
            int id_cat = int.Parse(hidden.Value);
            
            if (r != null)
            {
               dtcategorias=  obj.subcategorias(id_cat);
               r.DataSource = dtcategorias;
               r.DataBind();
               
             
            }
        }

        
    }
}