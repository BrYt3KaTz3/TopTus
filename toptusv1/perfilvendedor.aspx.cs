using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1
{
    public partial class perfilvendedor : System.Web.UI.Page
    {
        public string nombre, nick, imagen, empresa, pais, estado, email, tipov,fb,tw,lk,gg,ins,ingreso;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
            {

                int id = int.Parse(Request.QueryString["vendedor"]);
                
                cargar_datos_vendedor(id);
                
                DataBind();
               

            } //fin de , si hay parámetros
            else
            {
                //cuando no hay parámetros, cargar toooodooooooooooooos los productos
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
                empresa = datos.Rows[0]["empresa"].ToString();
                pais = datos.Rows[0]["pais"].ToString();
                estado = datos.Rows[0]["estado"].ToString();
                email = datos.Rows[0]["email"].ToString();
                ingreso = DateTime.Parse(datos.Rows[0]["fecha_solicitud"].ToString()).ToShortDateString();
                tipov = datos.Rows[0]["tipovendedor_descr"].ToString();
            }
            var redes = obj.redes_sociales(id);
            if (redes.Rows.Count == 1)
            {
                fb = redes.Rows[0]["facebook"].ToString();
                tw = redes.Rows[0]["twitter"].ToString();
                gg = redes.Rows[0]["googleplus"].ToString();
                ins = redes.Rows[0]["instagram"].ToString();
                lk = redes.Rows[0]["linkedin"].ToString();
            }
            else
            {
                fb = "";
                tw = "";
                gg = "";
                ins = "";
                lk = "";
            }

            var productos = obj.productos_por_vendedor(id);
            {
                if (productos.Rows.Count == 0)
                {
                    nohay.Text = "<h5>No hay más productos de este vendedor</h5>";
                }
                else { 
                if (productos.Rows.Count > 0)
                {
                    rpt_mas_productos.DataSource = productos;
                    rpt_mas_productos.DataBind();
                }
                else
                {
                    nohay.Text = "<h5>Error al cargar la información.</h5>";
                }
                }
            }
        }
    }
}