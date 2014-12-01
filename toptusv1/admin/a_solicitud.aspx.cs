using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace toptusv1.admin
{
    public partial class a_solicitud : System.Web.UI.Page
    {
        DataTable dtsolicitud = new DataTable();
        admin_general obj = new admin_general();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.ToString() != "")
            {
                div_datos_solicitud.Visible = true;
                var parametro = Request.QueryString.ToString();
                int id = int.Parse(parametro);
                datos_solicitud(id);
               
            }
            else
            {
                cargar_repeater();
                div_datos_solicitud.Visible = false;
            }
            
        }

       

        public DataTable cargar_repeater()
        {
            dtsolicitud = obj.solicitudes();
            Repeater1.DataSource = dtsolicitud;
            Repeater1.DataBind();
            return dtsolicitud;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName == "ver_detalle")
            {
                var hidden = e.Item.FindControl("hidden_detalle") as HiddenField;
                int parametro =int.Parse(hidden.Value);
                Response.Redirect("a_solicitud.aspx?"+parametro);
            }
        }

        public void datos_solicitud(int id)
        {
            admin_general obj = new admin_general();
            
            DataTable vendedor = obj.datos_vendedor(id);
            if (vendedor.Rows.Count != 0)
            {
                lbl_Nombre_Completo.Text = vendedor.Rows[0]["nombre_completo"].ToString();
                lbl_correo.Text = vendedor.Rows[0]["email"].ToString();
                DateTime fecha =(DateTime) vendedor.Rows[0]["fecha_solicitud"];
                lbl_fecha.Text = fecha.ToShortDateString();
                var id_vendedor =vendedor.Rows[0]["vendedor_id"];
                hd_id.Value = id_vendedor.ToString() ;

            }
           
        }

        protected void btn_aceptar_solicitud_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hd_id.Value);
            admin_general obj = new admin_general();

            //paquete se sacará desde la solicitud
            string res = obj.update_solicitud(id, 1);
            if (res == "1")
            {
                
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "solicitud_aprobada()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "alert('Error:"+res+"')", true);
            }
        }

       

        /* public void cargar_solicitudes_panel()
         {
             admin_general obj = new admin_general();
             var solicitudes = obj.solicitudes();
             panel_solicitudes.Controls.Add(new LiteralControl("<div id='solicitudes'>"));

            
             #region solicitdes

             if (solicitudes.Rows.Count > 0) //si si hay solicitdes
             {
                 for (int i = 0; i < solicitudes.Rows.Count; i++)
                 {
                     int id = (int)solicitudes.Rows[i].ItemArray.ElementAt(0);
                     string nombre_completo = solicitudes.Rows[i].ItemArray.ElementAt(9).ToString();
                     string mail = solicitudes.Rows[i].ItemArray.ElementAt(4).ToString();
                     panel_solicitudes.Controls.Add(new LiteralControl("<div class='list-group'>"));
                       
                         panel_solicitudes.Controls.Add(new LiteralControl("<h4 class='list-group-item'>"+nombre_completo+"</h4>"));
                         panel_solicitudes.Controls.Add(new LiteralControl("<p class='list-group-item-text'>Correo: "+mail+  "<br/>"));
                         panel_solicitudes.Controls.Add(new LiteralControl("<a href='a_solicitud.aspx'>Ver Detalle"));//aquí pasaré parámetro para detalle
                         panel_solicitudes.Controls.Add(new LiteralControl("</a></p>"));//cierra el enlace
                        
                     panel_solicitudes.Controls.Add(new LiteralControl("</div>"));//cierra el list-group
                 }
                

             }
             else {
                 panel_solicitudes.Controls.Add(new LiteralControl("<p>Por el momento no hay nuevas solicitudes.</p>"));
             }
            
             #endregion
            
             panel_solicitudes.Controls.Add(new LiteralControl("</div>"));
         }
     }*/
    }
}

/*<div class="list-group">
  <a href="#" class="list-group-item active">
    <h4 class="list-group-item-heading">Título del elemento de la lista</h4>
    <p class="list-group-item-text">...</p>
  </a>
</div>*/