using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1
{
    public partial class confirmacion : System.Web.UI.Page
    {
        public string correo;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }

        public void cargar_datos()
        {
            int status =int.Parse( Request.QueryString["status"].ToString());
            correo =  desencriptar();
            DataBind();
            if(status==1)
            {
                nomail.Visible = false;
            }
            else if (status == 2)
            {
                simail.Visible = false;
            }
        }

        public string desencriptar()
        {
            string ID = Request.QueryString["usr"].ToString();
            string des = vendedor.seguridad.DesEncriptar(ID);
            
            return des;
        }

    }
}