using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace toptusv1.vendedor
{

    public class vendedor
    {
        private DBManager conexion;
        public DataTable dt_vendedor;

        public vendedor()
        {
            conexion = new DBManager(DataProvider.SqlServer);
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["toptusv1.Properties.Settings.cnn"].ConnectionString;
        }


        #region solicitudes
        //verificar que no exista solicitud

        public DataTable existe_vendedor(string email)
        {
            try
            {
                conexion.Open();
                dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "select * from Vendedor where email='" + email + "'").Tables[0];
                return dt_vendedor;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //insertar solicitud
        public string insertar_solicitud(string nombre,  string apellidop,string apellidom, string email, DateTime fechasolicitud)
        {
            try
            {

              //  Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno
               // using (SqlConnection conn = new SqlConnection("Data Source=GHIA\\FERSQL;Initial Catalog=TopTusDB;User ID=feri;Password=feri"))
                using (SqlConnection conn = new SqlConnection("Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno;User ID=ferchoMF_fer;Password=ferchodc1"))
                {

                    string sql = @"insert into Vendedor (nombre, apellido_p,apellido_m,email, fecha_solicitud, tipovendedor_id) 
						values (@nombre,@apellido_p,@apellido_m, @email, @fecha_solicitud, @id)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido_p", apellidop);
                    cmd.Parameters.AddWithValue("@apellido_m", apellidom);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", fechasolicitud);
                    cmd.Parameters.AddWithValue("@id", 4);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "1";
                }
            }
            catch (Exception e)
            {
                return e.Message;

            }
            finally { conexion.Close(); }
        }

        public DataTable usuario_actualizado(int id)
        {
            conexion.Open();
            dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "Select * from Vendedor where vendedor_id="+id).Tables[0];
            conexion.Close();
            return dt_vendedor;
          
        }
           
       
        #endregion


      

        #region inserciones_updates
        public string update_basicos(int id,string nombre, string apellido_p, string apellido_m,string rfc, string empresa, int pais_id, int estado_ed , string ciudad , string colonia, string calle, string calle_num, string calle_num_int , string lada_pais,string lada_ciudad, string telefono , string extension)
        {
            try
            {

                //  Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno
                // using (SqlConnection conn = new SqlConnection("Data Source=GHIA\\FERSQL;Initial Catalog=TopTusDB;User ID=feri;Password=feri"))
                using (SqlConnection conn = new SqlConnection("Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno;User ID=ferchoMF_fer;Password=ferchodc1"))
                {

                    string sql = @"update Vendedor set nombre = @nombre, apellido_p = @apellido_p,apellido_m=@apellido_m , rfc=@rfc,empresa=@empresa, pais_id=@pais_id , estado_id=@estado_id, ciudad=@ciudad, colonia=@colonia,calle=@calle, calle_num=@calle_num,calle_num_int=@calle_num_int,lada_pais=@lada_pais,lada_ciudad=@lada_ciudad, telefono=@telefono, extension=@extension where vendedor_id=" + id;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido_p", apellido_p);
                    cmd.Parameters.AddWithValue("@apellido_m", apellido_m);
                    cmd.Parameters.AddWithValue("@rfc", rfc);
                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@pais_id", pais_id);
                    cmd.Parameters.AddWithValue("@estado_id", estado_ed);
                    cmd.Parameters.AddWithValue("@ciudad", ciudad);
                    cmd.Parameters.AddWithValue("@colonia", colonia);
                    cmd.Parameters.AddWithValue("@calle",calle);
                    cmd.Parameters.AddWithValue("@calle_num", calle_num);
                    cmd.Parameters.AddWithValue("@calle_num_int", calle_num_int);
                    cmd.Parameters.AddWithValue("@lada_pais", lada_pais);
                    cmd.Parameters.AddWithValue("@lada_ciudad", lada_ciudad);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@extension", extension);
                    

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "1";
                }
            }
            catch (Exception e)
            {
                return e.Message;

            }
            
        }

        public string insert_foto_perfil(int id, string imagen)
        {
            conexion.Open();
            try
            {
                conexion.ExecuteNonQuery(CommandType.Text, "update Vendedor set imagen='"+imagen+"' where vendedor_id="+id);
                return "1";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        #endregion


    }
   
}