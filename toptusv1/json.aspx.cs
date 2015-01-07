using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace toptusv1
{
    public partial class json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cat;
            string subcat;
            string filejson = HttpContext.Current.Server.MapPath("~/json/categorias.json"); //ruta
            string jsonsub = HttpContext.Current.Server.MapPath("~/json/subcategorias.json"); //ruta
            if (File.Exists(filejson) && File.Exists(jsonsub))
            {
                string si;
                var listacat = lectura(filejson); //lee cates
                var listasubcat = lecturasub(jsonsub); //lee sub

                resultado(listacat, listasubcat);
              


            }
            else
            {
                string no;
                creacion_json(filejson,jsonsub); // crea los 2 json's
                
            }
           
               
           
           
           
            string a;
        }

        public List<prueba_json> lectura(string path) //categorias
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<prueba_json> categorias_json = JsonConvert.DeserializeObject<List<prueba_json>>(file);
            string cat = categorias_json[0].categoria_descr;
            r.Close();
            return categorias_json;
            //termina lectura de json
        }

        public List<sub_json> lecturasub(string path) //subcategorias
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<sub_json> subcategorias_json = JsonConvert.DeserializeObject<List<sub_json>>(file);
            string subcat = subcategorias_json[0].subcategoria_descr;
            int idsub = subcategorias_json[0].subcategoria_id;
            r.Close();
            return subcategorias_json;
            //termina lectura de json
        }

        public void creacion_json(string path,string sub) //cuando no existe, lo crea , lo cierra y escribe en el
        {
            categorias_menu obj = new categorias_menu();
            var categorias = obj.categorias();
            var json = JsonConvert.SerializeObject(categorias);
            StreamWriter files = File.CreateText(path);
            files.Close();
            File.WriteAllText(path, json);

            //string cat=lectura(path);

            categorias_menu objs = new categorias_menu();
            var subcategorias = objs.subcategoriasjson();
            var jsonsub = JsonConvert.SerializeObject(subcategorias);
            StreamWriter filesub = File.CreateText(sub);
            filesub.Close();
            File.WriteAllText(sub, jsonsub);

          //  p.InnerText = cat+" creacion";
            files.Close();
        }

        public void resultado(List<prueba_json> cats , List<sub_json> subs)
        {
            rptItemsInCart.DataSource = cats;
            rptItemsInCart.DataBind();
           
        }

        protected void rptItemsInCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var hidden = e.Item.FindControl("hidden_categorias") as HiddenField;
            var subc = lecturasub( HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
            Repeater r = e.Item.FindControl("repeater_subcategorias") as Repeater;
            
            int id_cat = int.Parse(hidden.Value);
            string a;
            List<sub_json> listasub;
            if (r != null)
            {
               var listasubs = subc.Where(subcs => subcs.categoria_id==id_cat);

               r.DataSource = listasubs;
                r.DataBind();


            }
            
        }
    }
}