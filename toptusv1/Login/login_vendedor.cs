using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1.Login
{
    public class login_vendedor
    {

        private DBManager conexion;
        public DataTable dt_login;

        public login_vendedor()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
    
        }

        public DataTable validar_usuario(string usuario, string pass) //vendedor , verificar cuando sean tipo 4 y redireccionar a "prospecto"
        {
            try
            {
                conexion.Open();
                dt_login = conexion.ExecuteDataSet(CommandType.Text, "select * from Vendedor where email='" + usuario + "' and pass='"+pass+"'").Tables[0];
                string a;
                conexion.Close();
                return dt_login;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }
    }
}