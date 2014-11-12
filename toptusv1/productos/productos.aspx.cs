using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;


namespace toptusv1.productos
{
    public partial class productos : System.Web.UI.Page
    {
        private DBManager conexion;
        public DataTable dt_prod;
        

        public productos()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
          string  prod = productos_consulta();
            // escribe unjson con un objeto deserializado o serializado
           //File.WriteAllText(@"..\..\Users\FER\Desktop\tecnopreur\mis proyectos\toptus\visual\toptusv1\toptusv1\productos\jsproductosjson.json",prod);
          
            //el de abajo es para crear un archivo json  
            // File.Create(@"..\..\Users\FER\Desktop\tecnopreur\mis proyectos\toptus\visual\toptusv1\toptusv1\productos\json.json");

         
            

           
            
        }

        #region consultas
        public String productos_consulta()
        {
            conexion.Open();
            productos obj_prod = new productos();
            dt_prod = conexion.ExecuteDataSet(CommandType.Text, "Select * from Producto").Tables[0];
            string json = JsonConvert.SerializeObject(dt_prod);
            string jsondes = JsonConvert.DeserializeObject(json).ToString();


            return jsondes;
        }
        #endregion
        
    }
}