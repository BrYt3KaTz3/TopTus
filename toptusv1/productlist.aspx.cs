using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1.productos
{
    public partial class productlist : System.Web.UI.Page
    {
        DataTable dtproductos = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
            {

                int categoria =int.Parse(Request.QueryString["cat"]);
                int subcategoria =int.Parse(Request.QueryString["sub"]);
                



                lblcat.Text = categoria.ToString();
                lblsub.Text = subcategoria.ToString();

                cargar_productos(categoria,subcategoria);

            } //fin de , si hay parámetros
            else
            {
                //cuando no hay parámetros, cargar toooodooooooooooooos los productos
            }
        }

        public void cargar_productos(int cate, int sub)
        { 
            productos_clase obj = new productos_clase();
            dtproductos= obj.productos_lista(cate,sub);
            gvwproductos.DataSource = dtproductos;
            gvwproductos.DataBind();
        }
    }
}