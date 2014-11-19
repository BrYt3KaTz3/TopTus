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
            
           // cargar_solicitudes();
            cargar_solicitudes_panel();
        }

        public DataTable cargar_solicitudes()
        {
            dtsolicitud = obj.solicitudes();
            gv_solicitudes.DataSource = dtsolicitud;
            gv_solicitudes.DataBind();
            return dtsolicitud;

        }

        public void cargar_solicitudes_panel()
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
    }
}

/*<div class="list-group">
  <a href="#" class="list-group-item active">
    <h4 class="list-group-item-heading">Título del elemento de la lista</h4>
    <p class="list-group-item-text">...</p>
  </a>
</div>*/