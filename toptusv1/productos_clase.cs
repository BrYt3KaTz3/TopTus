using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1
{
    public class productos_clase
    {
        private DBManager conexion;
        public DataTable dt_productos;

        public productos_clase()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }

        public DataTable productos_lista(int cate, int sub) // el que es al dar click a una subcategoría
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from productos_lista where categoria_id ="+cate+"  and subcategoria_id ="+sub+" ").Tables[0];
                return dt_productos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //productos por vendedor
        public DataTable productos_vendedor(int id) // el que es al dar click a una subcategoría
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from Producto where vendedor_id =" + id).Tables[0];
                return dt_productos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //insertar producto
        public string instertar_producto_vendedor(int id, string nombre_producto, string descr_producto,string precio, string img_principal)
        {
            conexion.Open();
            try
            {
                conexion.ExecuteNonQuery(CommandType.Text, "insert into Producto (producto,producto_descr,vendedor_id,precio,img_principal) values ('"+nombre_producto+"','"+descr_producto+"','"+id+"','"+precio+"','"+img_principal+"')");
                return "1";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}