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
    public partial class vendedor_perfil : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
            if (!Page.IsPostBack) { 
            if (Session["valido"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            //else.... usuario válido
            else
            {
                //var usuario = HttpContext.Current.Session["usuario"];
                //var ajlk = (TextBox)Master.FindControl("usuario_id_master");
                //TextBox hdnID = Page.Master.FindControl("usuario_id_master") as TextBox;
                //string user = hdnID.Text;
                //var usueraio = ((base_vendedor)Master).usuario_id;
                
                cargar_datos();
                

            }
            } //postback
        }

        public void cargar_datos() // a la pestaña de login
        {
            var sesion = HttpContext.Current.Session["usuario"];
            
            DataTable usuario = (DataTable)sesion;


            //paises
            string jsonpaise = HttpContext.Current.Server.MapPath("~/json/paises.json"); //ruta
            string jsonestado = HttpContext.Current.Server.MapPath("~/json/region.json"); //ruta
            if (File.Exists(jsonpaise) && File.Exists(jsonestado))
            {
                string si;
                var listapaises = lectura(jsonpaise); //lee cates
                var listaestados = lecturasub(jsonestado); //lee sub

                



            }
            else
            {
                string no;
                creacion_json(jsonpaise, jsonestado); // crea los 2 json's

            }

            string filejson = HttpContext.Current.Server.MapPath("~/json/paises.json"); //ruta
            var listpaises = lectura(filejson); //lee cates
            ddlpais.DataSource = listpaises;
           
            ddlpais.DataTextField = "Country";
            ddlpais.DataValueField = "CountryId";
            ddlpais.Items.Insert(0, "Selecciona");
            ddlpais.DataBind();
           
            
           // pasar sesion usuario a variables
            string nombre = usuario.Rows[0]["nombre"].ToString();
            string apellido_m = usuario.Rows[0]["apellido_m"].ToString();
            string apellido_p = usuario.Rows[0]["apellido_p"].ToString();
            string email = usuario.Rows[0]["email"].ToString();
            string fecha_ingreso = usuario.Rows[0]["fecha_ingreso"].ToString();
            string empresa = usuario.Rows[0]["empresa"].ToString();
            string RFC = usuario.Rows[0]["RFC"].ToString();
            string ciudad = usuario.Rows[0]["ciudad"].ToString();
            string colonia = usuario.Rows[0]["colonia"].ToString();
            string calle = usuario.Rows[0]["calle"].ToString();
            string calle_num = usuario.Rows[0]["calle_num"].ToString();
            string calle_num_int = usuario.Rows[0]["calle_num_int"].ToString();
            string lada_pais = usuario.Rows[0]["lada_pais"].ToString();
            string lada_ciudad = usuario.Rows[0]["lada_ciudad"].ToString();
            string telefono = usuario.Rows[0]["telefono"].ToString();
            string extension = usuario.Rows[0]["extension"].ToString();
            int pais = int.Parse(usuario.Rows[0]["pais_id"].ToString());
            int estado = int.Parse(usuario.Rows[0]["estado_id"].ToString());
            //precargar ddl's estado y país
            ddlpais.SelectedValue = pais.ToString();
            int idpais = int.Parse(ddlpais.SelectedValue);
            var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/region.json"));
            var listasubs = subc.Where(subcs => subcs.CountryId == idpais);

            ddlestado.DataSource = listasubs;
            ddlestado.DataTextField = "Region";
            ddlestado.DataValueField = "RegionId";
            ddlestado.DataBind();
            ddlestado.SelectedValue = estado.ToString();
            //agregar campos que faltan

            //cargar txtbox
            ven_nombre.Text = nombre;
            ven_apellidop.Text = apellido_p;
            ven_apellidom.Text = apellido_m;
            ven_email.Text = email;
            ven_fechaingreso.Text = fecha_ingreso;
            ven_empresa.Text = empresa;
            ven_rfc.Text = RFC;
            ven_ciudad.Text = ciudad;
            ven_colonia.Text = colonia;
            ven_calle.Text = calle;
            ven_num.Text = calle_num;
            ven_num_int.Text = calle_num_int;
            ven_lada_pais.Text = lada_pais.ToString();
            ven_lada_ciudad.Text = lada_ciudad.ToString();
            ven_telefono.Text = telefono.ToString();
            ven_extension.Text = extension.ToString();

           
            

        }

        protected void ddlpais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_estados();


            
        }

        public void cargar_estados() //sin importar si eligen otro o es el inicio
        {
            int idpais = int.Parse(ddlpais.SelectedValue);
            var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/region.json"));
            var listasubs = subc.Where(subcs => subcs.CountryId == idpais);

            ddlestado.DataSource = listasubs;
            ddlestado.DataTextField = "Region";
            ddlestado.DataValueField = "RegionId";
            ddlestado.DataBind();
        }
       
        protected void btn_actualizar_vendedor_basico_Click(object sender, EventArgs e)
        {
             var sesion = HttpContext.Current.Session["usuario"];
            
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            
            vendedor obj = new vendedor();
            
            string nombre = ven_nombre.Text;
            string apellido_p = ven_apellidop.Text;
            string apellido_m = ven_apellidom.Text;
            string rfc = ven_rfc.Text;
            string empresa= ven_empresa.Text;
            int pais_id = int.Parse(ddlpais.SelectedValue.ToString()); ;
            int estado_id = int.Parse(ddlestado.SelectedValue.ToString());
            string ciudad = ven_ciudad.Text;
            string colonia = ven_colonia.Text;
            string calle = ven_calle.Text;
            string calle_num = ven_num.Text;
            string calle_num_int = ven_num_int.Text;
            string lada_pais = ven_lada_pais.Text;
            string lada_ciudad = ven_lada_ciudad.Text;
            string telefono = ven_telefono.Text;
            string extension = ven_extension.Text;
            string res = obj.update_basicos(id_usuario,nombre,apellido_p,apellido_m,rfc,empresa,pais_id,estado_id,ciudad,colonia,calle,calle_num,calle_num_int,lada_pais,lada_ciudad,telefono,extension);

            if (res == "1")
            {
                Session.Clear();
                // Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Session["usuario"] = obj.usuario_actualizado(id_usuario);
                Session["valido"] = true;
                cargar_datos();
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                //Response.Redirect(Server.MapPath("vendedor_perfil.aspx"));
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('"+res+"')", true);
                }
        }

        //JSONS
        public List<paises_json> lectura(string path) //paises
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<paises_json> paises_json_data = JsonConvert.DeserializeObject<List<paises_json>>(file);
            
            r.Close();
            return paises_json_data;
            //termina lectura de json
        }

        public List<region_json> lecturasub(string path) //estados
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<region_json> estados_json = JsonConvert.DeserializeObject<List<region_json>>(file);
           
            r.Close();
            return estados_json;
            //termina lectura de json
        }

        public void creacion_json(string path, string estadospath) //cuando no existe, lo crea , lo cierra y escribe en el
        {

            paises_cl obj = new paises_cl();
            var paises = obj.paises();
            var json = JsonConvert.SerializeObject(paises);
            StreamWriter files = File.CreateText(path);
            files.Close();
            File.WriteAllText(path, json);

            //string cat=lectura(path);

            categorias_menu objs = new categorias_menu();
            var estados = obj.estados();
            var jsonestados = JsonConvert.SerializeObject(estados);
            StreamWriter filesub = File.CreateText(estadospath);
            filesub.Close();
            File.WriteAllText(estadospath, jsonestados);

            //  p.InnerText = cat+" creacion";
            files.Close();
        }

        public void resultado(List<prueba_json> cats, List<sub_json> subs)
        {
           

        }
    }
}