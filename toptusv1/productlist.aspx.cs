using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Newtonsoft.Json;

namespace toptusv1.productos
{
    public partial class productlist : System.Web.UI.Page
    {
        DataTable dtproductos = new DataTable();
        public string ruta_principal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros cat 
            
            {

                int categoria =int.Parse(Request.QueryString["cat"]);
                int subcategoria =int.Parse(Request.QueryString["sub"]);
                if (categoria == 0 && subcategoria == 0)
                {
                    string q = Request.QueryString["q"].ToString();
                    cargar_productos_busqueda(q);
                }
                else {
                    cargar_cate_y_subcat(categoria, subcategoria);
                    cargar_productos(categoria, subcategoria);
                }
                

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
            if (dtproductos.Rows.Count == 0)
            {
                no_hay_productos.Text = "<h2 class='text-danger'>Aún no hay productos para esta categoría</h2><br/>Se el primero entrando <a href='solicitud.aspx'>Aquí</a>";
            }
            else 
            {
                
                rptProductosList.DataSource = dtproductos;
                rptProductosList.DataBind();
            }
           
          
        }

        public void cargar_productos_busqueda(string q)
        {
            productos_clase obj = new productos_clase();
            //se carga el repeater con los datos
            dtproductos = obj.productos_lista_busqueda(q);
            if (dtproductos.Rows.Count == 0)
            {
                no_hay_productos.Text = "<h2 class='text-danger'>Aún no hay productos para esta categoría</h2><br/>Se el primero entrando <a href='solicitud.aspx'>Aquí</a>";
            }
            else
            {
                rptProductosList.DataSource = dtproductos;
                rptProductosList.DataBind();
            }


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

        public string ruta(int prod)
        {

            
            productos_clase obj = new productos_clase(); //
            var datos = obj.fotos_principal_producto_lista(prod);
            if (datos.Rows.Count == 0)
            {
                ruta_principal = "vendedor/prod_fotos/default.png";
            }
            else
            {
                ruta_principal = datos.Rows[0]["img_ruta"].ToString();
            }
            return ruta_principal;
        
        }
        protected void rptProductosList_ItemDataBound(object sender, RepeaterItemEventArgs e) //ruta principal de la imagen
        {
            var hidden = e.Item.FindControl("hidden_product") as HiddenField;
            //var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
            //Repeater r = e.Item.FindControl("rptcatsub") as Repeater;

            int id_prod = int.Parse(hidden.Value);
            productos_clase obj = new productos_clase(); //
            var datos = obj.fotos_principal_producto_lista(id_prod);
            if (datos.Rows.Count == 0)
            {
                ruta_principal = "vendedor/prod_fotos/default.png";
            }
            else
            {
                ruta_principal = datos.Rows[0]["img_ruta"].ToString();
            }
           // if (r != null)
            //{
              //  var listacatsub = obj.prod_cat_produco(id_prod);
               // r.DataSource = listacatsub;
                //r.DataBind();


           // }
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