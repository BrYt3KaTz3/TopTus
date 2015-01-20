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
                conexion.Close();
                return dt_solicitud;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable datos_vendedor(int id) //cargar datos de la solicitud x
        {
            try
            {
                conexion.Open();
                dt_solicitud = conexion.ExecuteDataSet(CommandType.Text, "select * from Vendedor where vendedor_id="+id).Tables[0];
                conexion.Close();
                return dt_solicitud;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public string update_solicitud(int id, int paquete)
        {
            try
            {
                conexion.Open();
                conexion.ExecuteNonQuery(CommandType.Text, "update Vendedor set tipovendedor_id="+paquete+" where vendedor_id="+id);
                conexion.Close();
                return "1";
            }
            catch (Exception e)
            {
                conexion.Close();
                return e.Message;
            }
        }
    }
}