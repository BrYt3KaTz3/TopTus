﻿using System;
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
                conexion.Close();
                return dt_vendedor;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        //insertar solicitud
        public string insertar_solicitud(string nombre,  string apellidop,string apellidom, string email, DateTime fechasolicitud,string pass)
        {
            try
            {

              //  Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno
               // using (SqlConnection conn = new SqlConnection("Data Source=GHIA\\FERSQL;Initial Catalog=TopTusDB;User ID=feri;Password=feri"))
                using (SqlConnection conn = new SqlConnection("Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno;User ID=ferchoMF_fer;Password=ferchodc1"))
                {

                    string sql = @"insert into Vendedor (nombre, apellido_p,apellido_m,email,pass, fecha_solicitud, tipovendedor_id,pais_id,estado_id) 
						values (@nombre,@apellido_p,@apellido_m, @email,@pass, @fecha_solicitud, @id,1,1)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido_p", apellidop);
                    cmd.Parameters.AddWithValue("@apellido_m", apellidom);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@fecha_solicitud", fechasolicitud);
                    cmd.Parameters.AddWithValue("@id", 2);

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

         public DataTable datos_vendedor(int id) // recibimos el id del vendedor
        {
            conexion.Open();
            dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "SELECT *  FROM Vendedor v join TipoVendedor tv on v.tipovendedor_id=tv.tipovendedor_id where vendedor_id=" + id).Tables[0];
            conexion.Close();
            return dt_vendedor;
          
        }

         public DataTable productos_por_vendedor(int id)
         {
             conexion.Open();
             dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "select distinct p.producto_id,p.producto   from producto p join prod_cate pc on pc.producto_id=p.producto_id where vendedor_id=" + id).Tables[0];
             conexion.Close();
             return dt_vendedor;
         }

        public String verificar_nick(int id,string nick)
        {
            conexion.Open();
            dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "select nick from vendedor where nick='"+nick+"' and vendedor_id !=" + id).Tables[0];
            conexion.Close();
            if (dt_vendedor.Rows.Count == 0)
            {
                string res = "1";
                return res;
            }
            else
            {
                string res = "0";
                return res;
            }
            

        }
           
       
        #endregion


      

        #region inserciones_updates
        public string update_basicos(int id,string nombre, string nick,string apellido_p, string apellido_m,string rfc, string empresa, int pais_id, int estado_ed ,string pais, string estado, string ciudad , string colonia, string calle, string calle_num, string calle_num_int , string lada_pais,string lada_ciudad, string telefono , string extension)
        {
            try
            {

                //  Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno
                // using (SqlConnection conn = new SqlConnection("Data Source=GHIA\\FERSQL;Initial Catalog=TopTusDB;User ID=feri;Password=feri"))
                using (SqlConnection conn = new SqlConnection("Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno;User ID=ferchoMF_fer;Password=ferchodc1"))
                {

                    string sql = @"update Vendedor set nombre = @nombre,nick = @nick, apellido_p = @apellido_p,apellido_m=@apellido_m , rfc=@rfc,empresa=@empresa, pais_id=@pais_id , estado_id=@estado_id,pais=@pais, estado=@estado ,ciudad=@ciudad, colonia=@colonia,calle=@calle, calle_num=@calle_num,calle_num_int=@calle_num_int,lada_pais=@lada_pais,lada_ciudad=@lada_ciudad, telefono=@telefono, extension=@extension where vendedor_id=" + id;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@nick", nick);
                    cmd.Parameters.AddWithValue("@apellido_p", apellido_p);
                    cmd.Parameters.AddWithValue("@apellido_m", apellido_m);
                    cmd.Parameters.AddWithValue("@rfc", rfc);
                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@pais_id", pais_id);
                    cmd.Parameters.AddWithValue("@estado_id", estado_ed);
                    cmd.Parameters.AddWithValue("@pais", pais);
                    cmd.Parameters.AddWithValue("@estado", estado);
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
                conexion.Close();
                return "1";
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }
        
        #endregion

        #region redes sociales

        public DataTable redes_sociales(int id)
        {
            try
            {
            conexion.Open();
            dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "Select * from Redes_Sociales where vendedor_id="+id).Tables[0];
            conexion.Close();
            return dt_vendedor;
            
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
            

        }

        public string insert_redes_sociales(int id,string face, string tw, string gg , string ins, string lk,string accion)
        {
            try
            {
                conexion.Open();

                if (accion == "insertar")
                {
                    conexion.ExecuteNonQuery(CommandType.Text, "insert into Redes_Sociales (vendedor_id,facebook,twitter,googleplus,instagram,linkedin) values (" + id + ",'" + face + "','" + tw + "','" + gg + "','" + ins + "','" + lk + "')");
                    conexion.Close();
                    return "1";
                }
                else
                {
                    conexion.ExecuteNonQuery(CommandType.Text, "update Redes_Sociales set facebook='" + face + "' , twitter='" + tw + "', googleplus='" + gg + "',instagram='" + ins + "',linkedin='" + lk + "' where vendedor_id=" + id);
                    conexion.Close();
                    return "1";
                }


            }
            catch (Exception e)
            {
                conexion.Close();
                return e.Message;

            }
            finally { conexion.Close(); } //cerrra la conexión pase lo que pase
        }

        #endregion

        #region prod_cat

        public DataTable prod_cat_produco(int id_prod)
        {
            try
            {
                conexion.Open();
                dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "select * from v_prod_cate where producto_id =" + id_prod).Tables[0];
                conexion.Close();
                return dt_vendedor;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public string insert_prod_cat(int id_prod, int id_cat, int id_subcat)
        {
            try
            {
                conexion.Open();
                //verificar si existe
                var existe=conexion.ExecuteDataSet(CommandType.Text, "select * from prod_cate where producto_id = "+id_prod+" and categoria_id ="+id_cat+" and subcategoria_id="+id_subcat+"").Tables[0];
                if (existe.Rows.Count >= 1)
                {
                    conexion.Close();
                    return "ya has agregado esta subcategoría";
                }
                else // si no existe
                {
                    conexion.ExecuteNonQuery(CommandType.Text, "insert into prod_cate (producto_id,categoria_id,subcategoria_id) values (" + id_prod + "," + id_cat + "," + id_subcat + ")");
                    conexion.Close();
                    return "1";
                }
                
               


            }
            catch (Exception e)
            {

                return e.Message;

            }
            finally { conexion.Close(); } //cerrra la conexión pase lo que pase
        }
        #endregion

        #region diccionario_restantoes
        //obtener valores por tipo de vendedor
        public DataTable valores_tipo_vendedor(int id_tipo)
        {
            try
            {
                conexion.Open();
                dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "select * from tipoVendedor where tipovendedor_id =" + id_tipo).Tables[0];
                conexion.Close();
                return dt_vendedor;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }


        }
        #endregion

    }

    #region codigoprueba_select
    
    /*
     public DataTable redes_sociales(int id)
         {
             try
             {
             conexion.Open();
             dt_vendedor = conexion.ExecuteDataSet(CommandType.Text, "Select * from Redes_Sociales where vendedor_id="+id).Tables[0];
            
             return dt_vendedor;
            
             }
             catch (Exception)
             {
                
                 throw;
             }
            

         }
     */
    #endregion
}