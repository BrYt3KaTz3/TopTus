using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1
{

    public class categorias_menu
    {
        private DBManager conexion;
        public DataTable dt_categorias,dt_subcategorias;

        public categorias_menu()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }

        public DataTable categorias()
        {
            try
            {
                conexion.Open();
                dt_categorias = conexion.ExecuteDataSet(CommandType.Text, "Select * from Categoria").Tables[0];
                return dt_categorias;
                    
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable subcategorias(int id)
        {
            try
            {
                conexion.Open();
                dt_subcategorias = conexion.ExecuteDataSet(CommandType.Text, "Select * from SubCategoria where categoria_id=" + id).Tables[0];
                return dt_subcategorias;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}