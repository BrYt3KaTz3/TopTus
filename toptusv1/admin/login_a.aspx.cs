using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptusv1.admin
{
    public partial class login_a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            login_admin obj = new login_admin();
            try
            {
                string usuario = a_usuario.Text;
                string pass = a_password.Text;
                var validar = obj.validar_admin(usuario, pass); // validar super admin
                if (validar.Rows.Count == 0)
                {
                    a_password.Text = string.Empty;
                    a_usuario.Text = string.Empty;

                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);

                }
                else
                {
                    //inicializar session
                    ArrayList a_admin = new ArrayList();
                    for (int i = 0; i < validar.Columns.Count; i++) //regresaría todas las columnas 
                    {
                        a_admin.Add(validar.Rows[0].ItemArray.ElementAt(i));
                    }


                    Session["valido_admin"] = true;
                    Session["usuario_admin"] = a_admin;
                    Response.Redirect("a_info.aspx");
                }//fin else
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}