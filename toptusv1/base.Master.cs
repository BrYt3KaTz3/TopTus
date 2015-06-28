using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json; // para el json
using System.IO;  //para el streamreader


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

            if (usuario.Rows[0]["nick"].ToString() != "")
            {
                string nick = usuario.Rows[0]["nick"].ToString();
                enlace_vendedor.InnerText = nick;
            }
            else
            {
                string nombre = usuario.Rows[0]["nombre"].ToString();
                enlace_vendedor.InnerText = nombre;
            }



        
            
        }
       /* public DataTable cargar_categorias()
        {
            categorias_menu obj = new categorias_menu();
            dtcategorias= obj.categorias();
            repeater_categorias.DataSource = dtcategorias;
            repeater_categorias.DataBind();
            return dtcategorias;
            
        }*/

        public void cargar_categorias()
        {
            string jsoncate = HttpContext.Current.Server.MapPath("json/categorias.json"); //ruta
            string jsonsub = HttpContext.Current.Server.MapPath("json/subcategorias.json"); //ruta
            if (File.Exists(jsoncate) && File.Exists(jsonsub))
            {
                var listacat = lectura(jsoncate); //lee cates
                var listasub = lecturasub(jsonsub); //lee sub
            }
            else
            {
                creacion_json(jsoncate, jsonsub); // crea los 2 json's
            }

            string filejson = HttpContext.Current.Server.MapPath("json/categorias.json"); //ruta
            var listcategorias = lectura(filejson).OrderBy(x=>x.orden); //lee cates
            
            repeater_categorias.DataSource = listcategorias;
            repeater_categorias.DataBind();

        }


        public List<prueba_json> lectura(string path) //categorias
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<prueba_json> categorias_json_data = JsonConvert.DeserializeObject<List<prueba_json>>(file);
           
            r.Close();
            
            return categorias_json_data;
            //termina lectura de json
        }

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

        public void creacion_json(string path, string sub) //cuando no existe, lo crea , lo cierra y escribe en el
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

        protected void cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Index.aspx");
        }

      /*  protected void repeater_categorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        }*/

        protected void repeater_categorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            categorias_menu obj = new categorias_menu();
            Repeater r = e.Item.FindControl("repeater_subcategorias") as Repeater;

            var hidden = e.Item.FindControl("hidden_categoria") as HiddenField;
            int id_cat = int.Parse(hidden.Value);

            if (r != null)
            {
                var subc = lecturasub(HttpContext.Current.Server.MapPath("json/subcategorias.json"));
                var listasubs = subc.Where(subcs => subcs.categoria_id == id_cat);
                r.DataSource = listasubs;
                r.DataBind();

            }
        }


        /* */
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            if (busqueda.Length >1)
            {
                if (busqueda[0].ToString() != " ")
                { Response.Redirect("productlist.aspx?cat=0&sub=0&q=" + txtBuscar.Text); }
                else
                {
                    string res = "La búsqueda no puede empezar con espacios.";
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "mensaje", "alert('" + res + "')", true);
                }
                
               
            }
            else
            {
                string res = "Teclea una búsqueda válida.";
                this.Page.ClientScript.RegisterStartupScript(GetType(), "mensaje", "alert('" + res + "')", true);
            }
            
        }

        

        
    }
}