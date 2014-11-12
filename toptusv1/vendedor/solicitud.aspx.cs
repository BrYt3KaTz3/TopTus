using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1.vendedor
{
    public partial class solicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_enviar_solicitud_Click(object sender, EventArgs e)
        {
            vendedor obj = new vendedor();


            try
            {
                string nombre = sol_nombre.Text;
                string apellidop = sol_apellidop.Text;
                string apellidom = sol_apellidom.Text;
                string email = sol_email.Text;
                var existe = obj.existe_vendedor(email);//verifica si hay un email registrado
                DateTime fechasol = DateTime.Today;
                if (existe.Rows.Count==0)
                {
                    string res = obj.insertar_solicitud(nombre, apellidop, apellidom, email, fechasol);
                    if (res == "1")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "confirmacion_solicitud()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_solicitud()", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "mail_ya_registrado()", true);
                }
              
            }
            catch (Exception error)
            {
                
                throw error;
            }
        }
    }
}