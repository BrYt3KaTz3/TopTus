using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using toptusv1.Login;

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
                   var validar = obj.validar_usuario(mail, pass); //vendedor

                   if (validar.Rows.Count == 0)
                   {
                       ClientScript.RegisterStartupScript(GetType(), "mensaje", "wrong_user()", true);
                   }
                   else
                   {
                       //inicializar session
                       ArrayList usuario = new ArrayList();
                      
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(0));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(1));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(2));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(3));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(4));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(5));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(6));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(7));
                       usuario.Add(validar.Rows[0].ItemArray.ElementAt(8));
                       Session["valido"] = true;
                       Session["usuario"] = usuario;
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