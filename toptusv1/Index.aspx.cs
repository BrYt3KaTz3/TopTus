using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1
{
    public partial class Index : System.Web.UI.Page
    {
        public string nombre_producto, precio, descripcion, nombre, nick, imagen;
        public int id_vendedor, id_producto;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_productos_hogar();
        }

        public void cargar_productos_hogar()
        {
            productos_clase obj = new productos_clase();
            var datos = obj.productos_destacados(4);
            if (datos.Rows.Count == 0)
            {
              /*aun no hay*/
            }
            else
            {
                rpthogar.DataSource = datos;
                rpthogar.DataBind();
            }

            
            
        }
    }
}