using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json; // para el json
using System.IO;  //para el streamreader

namespace toptusv1.vendedor
{
    public partial class catprod : System.Web.UI.Page
    {
        public string producton, id_prods;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["valido"] == null)
                {
                    Response.Redirect("../login.aspx");
                }
                //else.... usuario válido
                else
                {
                   
                       
                        cargar_datos();


                }
            }
        }
        public void cargar_datos()
        {
            vendedor obj = new vendedor();
            int id_prod = int.Parse(desencriptar());
            //paises
            string jsoncate = HttpContext.Current.Server.MapPath("~/json/categorias.json"); //ruta
            string jsonsub = HttpContext.Current.Server.MapPath("~/json/subcategorias.json"); //ruta
            if (File.Exists(jsoncate) && File.Exists(jsonsub))
            {
                
                var listapaises = lectura(jsoncate); //lee cates
                var listaestados = lecturasub(jsonsub); //lee sub





            }
            else
            {
               
                creacion_json(jsoncate, jsonsub); // crea los 2 json's

            }

            string filejson = HttpContext.Current.Server.MapPath("~/json/categorias.json"); //ruta
            var listcategorias = lectura(filejson); //lee cates
            ddlcat.DataSource = listcategorias;

            ddlcat.DataTextField = "categoria_descr";
            ddlcat.DataValueField = "categoria_id";
            ddlcat.SelectedValue = "4"; //siempre el primer cate
            ddlcat.DataBind();

            //cargar subcategorías
            int idcat = int.Parse(ddlcat.SelectedValue);
            var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
            var listasubs = subc.Where(subcs => subcs.categoria_id == idcat);

            ddlsub.DataSource = listasubs;
            ddlsub.DataTextField = "subcategoria_descr";
            ddlsub.DataValueField = "subcategoria_id";
            ddlsub.SelectedValue = "51"; //es siempre la primer subcategoría
            ddlsub.DataBind(); 

            //cargar repeater con las cateogorías y subcategorias del producto
            DataTable existe_cate = obj.prod_cat_produco(id_prod);
            productos_clase probj = new productos_clase();
            DataTable producto = probj.datos_producto(id_prod);
            if (producto.Rows.Count != 0)
            {
                producton = producto.Rows[0]["producto"].ToString();
                id_prods = producto.Rows[0]["producto_id"].ToString();
                DataBind();
            }
            if (existe_cate.Rows.Count == 0)
            {
               repeater_status.Text="Aún no has agregado categoría para este producto";
            }
            else
            {
                
                rptCategorias_Subcategorias.DataSource=existe_cate;
                rptCategorias_Subcategorias.DataBind();

            }
            

            
        }

        //JSONS
        //JSONS
        public List<prueba_json> lectura(string path) //paises
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

        protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idcat = int.Parse(ddlcat.SelectedValue);
            var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
            var listasubs = subc.Where(subcs => subcs.categoria_id == idcat);

            ddlsub.DataSource = listasubs;
            ddlsub.DataTextField = "subcategoria_descr";
            ddlsub.DataValueField = "subcategoria_id";
           
            ddlsub.DataBind();
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            vendedor obj = new vendedor();
            int cat =int.Parse(ddlcat.SelectedValue.ToString());
            int sub =int.Parse(ddlsub.SelectedValue.ToString());
            string prod = desencriptar(); //desencripta el valor de la url
            int id_prd = int.Parse(prod);

            //verificacion de cuantas categorías restantes de acuerdo al tipo de vendedor
            int verifcar_registradas = obj.prod_cat_produco(id_prd).Rows.Count; //cuantos ha registrado
            int tipo = tipo_vendedor(); //tipo de vendedor
            int a_registrar =int.Parse(obj.valores_tipo_vendedor(tipo).Rows[0]["categorias"].ToString());  //cuantos categorías puede registrar por producto

            if (verifcar_registradas < a_registrar)
            {
                #region insertar
                string res = obj.insert_prod_cat(id_prd, cat, sub);
                if (res == "1")

                {
                    string id_producto = encriptar_url(id_prd.ToString());
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar_categoria('" + id_producto + "')", true);
                    //Response.Redirect(Server.MapPath("vendedor_perfil.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + res + "')", true);
                }
                #endregion
            }
            else
            {
                string res = "Haz alcanzado el máximo de categorías permitidas por producto";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + res + "')", true);
            
            }
        

           
        }

        public string desencriptar()
        {
            string ID = Request.QueryString["prod"].ToString();
            string des = seguridad.DesEncriptar(ID);
            return des;
        }

        //datos usuario
        public int tipo_vendedor() //obtener el tipo de vendedor
        {
            var sesion = HttpContext.Current.Session["usuario"];

            DataTable usuario = (DataTable)sesion;
            int id_tipo_vendedor = int.Parse(usuario.Rows[0]["tipovendedor_id"].ToString());
            return id_tipo_vendedor;
        }

        public string encriptar_url(string id_producto)
        {
            string encriptado = seguridad.Encriptar(id_producto);
            return encriptado;
        }

        protected void delete_cat_Click(object sender, CommandEventArgs e)
        {
            int id_prod = int.Parse(desencriptar());
            string redirect = encriptar_url(id_prod.ToString());
            if (e.CommandName == "eliminar")
            {
              
                string args = e.CommandArgument.ToString();
                string [] parametros  = args.Split(';');
                int cat = int.Parse(parametros[0].ToString());
                int sub = int.Parse(parametros[1].ToString());

                vendedor obj = new vendedor();
                try
                {
                   string res= obj.eliminar_categoria(cat, sub,id_prod);
                   if (res == "1")
                   {
                       ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_eliminar_categoria("+id_prod+")", true);
                   }
                   else
                   {
                       ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar("+res+")", true);
                   }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }
    }
}