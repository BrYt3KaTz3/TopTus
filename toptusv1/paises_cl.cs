using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1
{
    public class paises_cl
    {
        private DBManager conexion;
        public DataTable dt_paises, dt_estados;

       

        public paises_cl()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;

        }

        #region consultas
        public DataTable paises()
        {
            try
            {
                conexion.Open();
                dt_paises = conexion.ExecuteDataSet(CommandType.Text, "Select * from paises").Tables[0];
                return dt_paises;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable estados()
        {
            try
            {
                conexion.Open();
                dt_estados = conexion.ExecuteDataSet(CommandType.Text, "Select * from region").Tables[0];
                return dt_estados;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}