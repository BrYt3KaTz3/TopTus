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
                DateTime fechasol = DateTime.Today;
               // obj.insertar_solicitud(nombre, apellidop, apellidom, email, fechasol);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}