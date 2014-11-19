using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1.admin
{

    public class login_admin
    {
        private DBManager conexion;
        public DataTable dt_admin;

        public login_admin()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }

        public DataTable validar_admin(string usuario, string pass) //vendedor , verificar cuando sean tipo 4 y redireccionar a "prospecto"
        {
            try
            {
                conexion.Open();
                dt_admin = conexion.ExecuteDataSet(CommandType.Text, "select * from SuperAdmin where usuario='" + usuario + "' and pass='" + pass + "'").Tables[0];
                string a;
                return dt_admin;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}