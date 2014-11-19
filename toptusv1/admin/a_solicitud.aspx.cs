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
            cargar_solicitudes();
        }

        public DataTable cargar_solicitudes()
        {
            dtsolicitud = obj.solicitudes();
            gv_solicitudes.DataSource = dtsolicitud;
            gv_solicitudes.DataBind();
            return dtsolicitud;

        }
    }
}