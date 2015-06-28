using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace toptusv1
{
    public partial class activacion : System.Web.UI.Page
    {
        public string correo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_datos();
            }
        }

        public void cargar_datos()
        {
            correo = desencriptar();
            DataBind();
            vendedor.vendedor obj = new vendedor.vendedor();
            var res= obj.existe_vendedor(correo);

            if (res.Rows.Count == 1)
            {
                //verificar si es tipo 4 para mostrarle el boton
                int tipo_vendedor= int.Parse(res.Rows[0]["tipovendedor_id"].ToString());
                if (tipo_vendedor == 4)
                {
                    noactivada.Visible = true;
                    activada.Visible = false;
                }
                else if (tipo_vendedor == 2)
                {
                    noactivada.Visible = false;
                    activada.Visible = true;
                }
            }

           
        }

        public string desencriptar()
        {
            string ID = Request.QueryString["usr"].ToString();
            string des = vendedor.seguridad.DesEncriptar(ID);

            return des;
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            correo = desencriptar();
            DataBind();
            vendedor.vendedor obj = new vendedor.vendedor();
            string res = obj.update_solicitud(correo);
            if (res == "1")
            {
                string msj = "Tu cuenta ha sido activada, Bienvenido a Toptus";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", " mensaje_activacion('" + msj + "','login.aspx')", true);
            }
            else
            {

                string msj = "Ocurrio un error, envíanos un comentario o escribe a soporte@toptus.com";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", " mensaje_activacion('" + msj + "','comentarios.aspx')", true);

            }

        }
    }
}