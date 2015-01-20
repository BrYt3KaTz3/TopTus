using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Newtonsoft.Json;

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
                cargar_cate_y_subcat(categoria, subcategoria);
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
            //se carga el repeater con los datos
            dtproductos= obj.productos_lista(cate,sub);
            rptProductosList.DataSource = dtproductos;
            rptProductosList.DataBind();
          
        }

        public void cargar_cate_y_subcat(int cate, int sub)
        {
            categorias_menu ojb = new categorias_menu();
            dtproductos = ojb.cat_y_sub(cate, sub);
            if (dtproductos.Rows.Count ==1)
            {
                li_categoria.InnerText = dtproductos.Rows[0]["categoria_descr"].ToString();
                li_subcategoria.InnerText = dtproductos.Rows[0]["subcategoria_descr"].ToString();
            }
        }
        protected void rptProductosList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var hidden = e.Item.FindControl("hidden_product") as HiddenField;
            var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
            Repeater r = e.Item.FindControl("rptcatsub") as Repeater;

            int id_prod = int.Parse(hidden.Value);
            vendedor.vendedor obj = new vendedor.vendedor(); //está en la carpeta por eso el punto
            if (r != null)
            {
                var listacatsub = obj.prod_cat_produco(id_prod);
                r.DataSource = listacatsub;
                r.DataBind();


            }
        }

        //leer json de subcat
        public List<sub_json> lecturasub(string path) //estados
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<sub_json> sub_json = JsonConvert.DeserializeObject<List<sub_json>>(file);

            r.Close();
            return sub_json;
            //termina lectura de json
        }
    }
}