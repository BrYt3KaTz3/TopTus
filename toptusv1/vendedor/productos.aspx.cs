using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

        string res = obj.instertar_producto_vendedor(usuario, nombre_producto, descr_producto, precio_producto, img_producto);
        if (res == "1")
        {
            ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar_foto('" + res + "')", true);
                           
        }
    }

    public string encriptar_url(string id_producto)
    {
        string encriptado = seguridad.Encriptar(id_producto);
        return encriptado;
    }
    
    }
}