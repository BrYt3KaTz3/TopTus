using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1
{
    public partial class productdetail : System.Web.UI.Page
    {
        public string nombre_producto, precio, descripcion,nombre,nick,imagen;
        public int id_vendedor,id_producto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
            {

                int producto = int.Parse(Request.QueryString["prod"]);
                cargar_detalles_producto(producto);
                cargar_fotos_producto(producto);
             
                DataBind();

            } //fin de , si hay parámetros
            else
            {
                //cuando no hay parámetros, cargar toooodooooooooooooos los productos
            }
        }

        public void cargar_detalles_producto(int idproducto)
        {
            productos_clase obj = new productos_clase();
            var datos = obj.detalle_producto(idproducto);
            if (datos.Rows.Count == 1)
            {
                nombre_producto = datos.Rows[0]["producto"].ToString();
                precio = datos.Rows[0]["precio"].ToString();
                descripcion = datos.Rows[0]["producto_descr"].ToString();
                id_vendedor = int.Parse(datos.Rows[0]["vendedor_id"].ToString());
                id_producto =int.Parse(datos.Rows[0]["producto_id"].ToString());
                cargar_datos_vendedor(id_vendedor);
            }
            else
            {
                nombre_producto = "";
                precio = "";
                descripcion = "Aún no se carga la información de este producto";
            }
        }

        public void cargar_datos_vendedor(int id)
        {
            vendedor.vendedor obj = new vendedor.vendedor();
            var datos = obj.datos_vendedor(id);
            if (datos.Rows.Count == 1)
            {
                nombre = datos.Rows[0]["nombre"].ToString();
                nick = datos.Rows[0]["nick"].ToString();
                imagen = datos.Rows[0]["imagen"].ToString();
                
            }
           
           
            
        }

        public void cargar_fotos_producto(int id)
        { 
            productos_clase obj =new productos_clase();
            var fotos = obj.fotos_por_producto(id);
            if (fotos.Rows.Count > 0)
            {
                rptFotosPorProducto.DataSource = fotos;
                rptFotosPorProducto.DataBind();
            }
            else
            {
                nofotos.Text = "<h4>No hay fotos para este producto.</h4>";
            }
        }
    }
}