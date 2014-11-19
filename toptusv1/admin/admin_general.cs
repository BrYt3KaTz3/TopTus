using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1.admin
{
    public class admin_general
    {
        private DBManager conexion;
        public DataTable dt_solicitud;

        public admin_general()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }
        public DataTable solicitudes() //cargar grdi solicitudes
        {
            try
            {
                conexion.Open();
                dt_solicitud = conexion.ExecuteDataSet(CommandType.Text, "select * from Vendedor where tipovendedor_id=4").Tables[0];
                return dt_solicitud;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}