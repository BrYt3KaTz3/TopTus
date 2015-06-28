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
                conexion.BeginTransaction();
                conexion.CreateParameters(3);
                conexion.AddParameters(0, "@mail", usuario);
                conexion.AddParameters(1,"@pass",pass);
                conexion.AddParameters(2, "@tipo", 2);
                dt_login = conexion.ExecuteDataSet(CommandType.Text, "select * from Vendedor where tipovendedor_id=@tipo and email=@mail and pass=@pass").Tables[0];
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