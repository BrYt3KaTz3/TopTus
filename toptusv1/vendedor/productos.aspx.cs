using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace toptusv1.vendedor
{
    public partial class products : System.Web.UI.Page
    {
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
        int usuario = id_usuario();
        productos_clase obj = new productos_clase();
        rptProductos.DataSource = obj.productos_vendedor(usuario);
        rptProductos.DataBind();
    }


    public int id_usuario() //método para obtener id del usuario actual
    {
        var sesion = HttpContext.Current.Session["usuario"];
        DataTable usuario = (DataTable)sesion;
        int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
        return id_usuario;
    }

    protected void btnAgregarProducto_Click(object sender, EventArgs e)
    {
        productos_clase obj = new productos_clase();
         int usuario = id_usuario();
        string nombre_producto = prod_nombre.Text;
        string descr_producto = prod_descr.Text;
        string precio_producto = prod_precio.Text;
        string img_producto = "prod_fotos/default.png";

        var res = obj.instertar_producto_vendedor(usuario, nombre_producto, descr_producto, precio_producto, img_producto);
        string a;
        if (res!= "error")
        {
           string id_producto = encriptar_url(res);
           Response.Redirect("catprod.aspx?prod="+id_producto);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar_foto('" + res + "');", true);
                           
        }
    }

        
    public string encriptar_url(string id_producto)
    {
        string encriptado = seguridad.Encriptar(id_producto);
        return encriptado;
    }

    protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var hidden = e.Item.FindControl("hidden_product") as HiddenField;
        var subc = lecturasub(HttpContext.Current.Server.MapPath("~/json/subcategorias.json"));
        Repeater r = e.Item.FindControl("rptcatsub") as Repeater;

        int id_prod = int.Parse(hidden.Value);
        vendedor obj = new vendedor();
        if (r != null)
        {
            var listacatsub = obj.prod_cat_produco(id_prod); 
            r.DataSource = listacatsub;
            r.DataBind();


        }
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

    }
}