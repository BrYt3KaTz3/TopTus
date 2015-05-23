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
    public partial class general_perfil : System.Web.UI.Page
    {
        public string nombre, nick, imagen, empresa, pais, estado, email, tipov, fb, tw, lk, gg, ins,ingreso;
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
                    int usuario = id_usuario();
                    cargar_datos_vendedor(usuario);
                    DataBind();
                    


                }
            } //postback
        }


        public void cargar_datos_vendedor(int id)
        {
            vendedor obj = new vendedor();
            var datos = obj.datos_vendedor(id);
            if (datos.Rows.Count == 1)
            {
                nombre = datos.Rows[0]["nombre"].ToString();
                nick = datos.Rows[0]["nick"].ToString();
                imagen = datos.Rows[0]["imagen"].ToString();
                empresa = datos.Rows[0]["empresa"].ToString();
                pais = datos.Rows[0]["pais"].ToString();
                estado = datos.Rows[0]["estado"].ToString();
                ingreso = DateTime.Parse(datos.Rows[0]["fecha_solicitud"].ToString()).ToShortDateString();
                email = datos.Rows[0]["email"].ToString();
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
                else
                {
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

        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

    }
}