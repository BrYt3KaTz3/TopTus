using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


namespace toptusv1.vendedor
{
    public partial class modificar_producto : System.Web.UI.Page
    {
        public string producto;
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
                    DataBind();


                }
            }
        }

        public void cargar_datos()
        {
          
            productos_clase obj_prod = new productos_clase();
            int id_prod = int.Parse(desencriptar());
            producto = id_prod.ToString();//para encriptar en asp html
            var producto_datos = obj_prod.detalle_producto(id_prod);
            if (producto_datos.Rows.Count > 0)
            {
                txtNombre.Text = producto_datos.Rows[0]["producto"].ToString();
                txtPrecio.Text = producto_datos.Rows[0]["precio"].ToString();
                txtDescripcion.Text = producto_datos.Rows[0]["producto_descr"].ToString();
            }

            //Categorías
            vendedor obj = new vendedor();
            DataTable existe_cate = obj.prod_cat_produco(id_prod);
            if (existe_cate.Rows.Count == 0)
            {
                repeater_status.Text = "Aún no has agregado categoría para este producto";
            }
            else
            {
                rptCategorias_Subcategorias.DataSource = existe_cate;
                rptCategorias_Subcategorias.DataBind();

            }

           //fotos
            var fotos = obj_prod.fotos_por_producto(id_prod);
            if (fotos.Rows.Count > 0)
            {

                rptFotoProducto.DataSource = fotos;
                rptFotoProducto.DataBind();
            }
            else
            {
                nofotos.Text = "<h4>No hay fotos para este producto.</h4>";
            }


        }

        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

        public string desencriptar()
        {
            string ID = Request.QueryString["prod"].ToString();
            string des = seguridad.DesEncriptar(ID);
            return des;
        }

        protected void btnModificarProducto_Click(object sender, EventArgs e)
        {
            productos_clase obj = new productos_clase();
            int id_prod = int.Parse(desencriptar());
            string nombre = txtNombre.Text;
            string des = txtDescripcion.Text;
            string precio = txtPrecio.Text;

            try
            {
                string res = obj.modificar_producto(id_prod, nombre, des, precio);
                if (res == "1")
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_modificar_producto()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + res + "')", true);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string encriptar_url(string id_producto)
        {
            string encriptado = seguridad.Encriptar(id_producto);
            return encriptado;
        }

        protected void delete_cat_Click(object sender, CommandEventArgs e)
        {
            int id_prod = int.Parse(desencriptar());
            
            if (e.CommandName == "eliminar")
            {

                string args = e.CommandArgument.ToString();
                string[] parametros = args.Split(';');
                int cat = int.Parse(parametros[0].ToString());
                int sub = int.Parse(parametros[1].ToString());

                vendedor obj = new vendedor();
                try
                {
                    string res = obj.eliminar_categoria(cat, sub,id_prod);

                    if (res == "1")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_eliminar_categoria(" + id_prod + ")", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar(" + res + ")", true);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        protected void btnEliminarFoto_Command(object sender, CommandEventArgs e)
        {

            string args = e.CommandArgument.ToString();
            string[] parametros = args.Split(';');
            int id_foto = int.Parse(parametros[0].ToString());
            string ruta_foto = parametros[1].ToString();
            string ruta = Server.MapPath("../" + ruta_foto);
            string a = "2";

            if (e.CommandName == "eliminar_foto")
            {

                try
                {


                    productos_clase obj = new productos_clase();

                    string res = obj.eliminar_foto_producto(id_foto); //eliminar registro
                    if (res == "1")
                    {
                        //eliminar del server
                        System.IO.File.Delete(ruta);
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_eliminar_foto()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar(" + res + ")", true);
                    }
                }
                catch (Exception)
                {

                    throw;
                }



            }
        }

        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            productos_clase obj = new productos_clase();
            int id_prod = int.Parse(desencriptar());
            int usuario = id_usuario();
            string ruta = Server.MapPath("../vendedor/prod_fotos/"+usuario+"/"+id_prod);
            try
            {
                string res = obj.eliminar_producto(id_prod);
                if (res == "1")
                { //eliminamos folder de fotos
                    //eliminar del server
                    //System.IO.File.Delete(ruta);
                    System.IO.DirectoryInfo archivos = new DirectoryInfo(ruta);

                    foreach (FileInfo file in archivos.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in archivos.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_eliminar_producto()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar(" + res + ")", true);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

       
    }
}