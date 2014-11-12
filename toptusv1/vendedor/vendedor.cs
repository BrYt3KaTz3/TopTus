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

        public string insertar_solicitud(string nombre,  string apellidop,string apellidom, string email, DateTime fechasolicitud)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection("Data Source=GHIA\\FERSQL;Initial Catalog=TopTusDB;User ID=feri;Password=feri"))
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
                     string a = "hola";
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

        #endregion

    }
   
}