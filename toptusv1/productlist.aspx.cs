using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1.productos
{
    public partial class productlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
            {

                string categoria = Request.QueryString["cat"].ToString() ;
                string subcategoria = Request.QueryString["sub"].ToString();
                



                lblcat.Text = categoria;
                lblsub.Text = subcategoria;


            } //fin de , si hay parámetros
            else
            {
                //cuando no hay parámetros, cargar toooodooooooooooooos los productos
            }
        }
    }
}