using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using toptusv1.Login;
using System.Data;

namespace toptusv1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valido"] != null)
            {
               //cuando ya están en sesión, preguntar que tipoi de usuario es nada mas
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //boton submit
        {
            login_vendedor obj = new login_vendedor();

            try
            {
                string mail = log_usuario.Text;
                string pass = log_password.Text;
               int tipovendedor =int.Parse(radiovendedor.SelectedValue);

               if (tipovendedor == 1)
               {
                   #region vendedor
                   DataTable validar = obj.validar_usuario(mail, pass); //vendedor

                   if (validar.Rows.Count == 0)
                   {
                       ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);
                   }
                   else
                   {
                       //inicializar session 
                       Session["valido"] = true;
                       Session["usuario"] = validar;
                       Response.Redirect("vendedor/vendedor_perfil.aspx");
                   }//fin else
                   #endregion
               }
               else 
               {
                #region Comprador
                //si es comprador se valida aquí
                   ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);
                #endregion
               }
               

               
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    
        
    
    }


}


//Response.Redirect("vendedor/vendedor_perfil.aspx");