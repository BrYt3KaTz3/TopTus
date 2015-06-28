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
        public DataTable dt_calificado;

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
                conexion.CreateParameters(2);
                conexion.AddParameters(0, "@cat", cate);
                conexion.AddParameters(1, "@sub", sub);
                string query = "Select p.producto_id , producto , producto_descr,p.vendedor_id,precio,img_principal,pc.producto_id, pc.categoria_id, pc.subcategoria_id ,v.vendedor_id, v.nombre,v.tipovendedor_id,v.nick from Vendedor v join Producto p on v.vendedor_id=p.vendedor_id join prod_cate pc on p.producto_id = pc.producto_id  where pc.categoria_id =@cat and pc.subcategoria_id=@sub";
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, query).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable productos_destacados(int categoria)
        {
            try
            {
                conexion.Open();
                conexion.CreateParameters(2);
                conexion.AddParameters(0, "@uno", 1);
                conexion.AddParameters(1, "@cat", categoria);
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "Select * from producto where destacado = @uno and cat_destacado=@cat").Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable productos_lista_busqueda(string q) // el que es al dar una busqueda en la barra
        {
            try
            {
                conexion.Open();
                conexion.CreateParameters(1);
                conexion.AddParameters(0, "@q", "%"+q+"%");
                string query = "Select distinct p.producto_id , producto , producto_descr,p.vendedor_id,precio,img_principal,pc.producto_id, v.vendedor_id, v.nombre,v.tipovendedor_id,v.nick from Vendedor v join Producto p on v.vendedor_id=p.vendedor_id join prod_cate pc on p.producto_id = pc.producto_id  where producto LIKE @q or producto_descr LIKE @q";
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, query).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }


        public DataTable detalle_producto(int id) // datos del producto X
        {
            try
            {
                conexion.Open();
                conexion.CreateParameters(1);
                conexion.AddParameters(0, "@id", id);
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "Select * from Producto where producto_id=@id").Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        //productos por vendedor
        public DataTable productos_vendedor(int id) // prodcutos que vende x vendedor
        {
            try
            {
                conexion.Open();
                conexion.CreateParameters(1);
                conexion.AddParameters(0, "@id", id);
                
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from Producto where vendedor_id =@id").Tables[0];
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


            using (SqlConnection conn = new SqlConnection("Data Source=198.38.94.104;Initial Catalog=ferchoMF_TopTusDBuno;User ID=ferchoMF_fer;Password=ferchodc1"))
            {
                conn.Open();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction();
                
             
                try
                {
                   string sql = @"insert into Producto(producto,producto_descr,vendedor_id,precio,img_principal)" +
                                  " values (@producto,@descr_producto,@vendedor_id,@precio,@img_principal);" +
                                  "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@producto", nombre_producto);
                    cmd.Parameters.AddWithValue("@descr_producto", descr_producto);
                    cmd.Parameters.AddWithValue("@vendedor_id", id);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@img_principal", img_principal);

                    string id_insertado = cmd.ExecuteScalar().ToString();
                    transaction.Commit();
                    conn.Close();
                    return id_insertado;
                }
                catch (Exception e)
                {

                    transaction.Rollback();
                    conn.Close();
                    return e.Message;
                }
            }

           
        }

        //modificar producto

        public string modificar_producto(int id, string nombre, string descripcion, string precio)
        {//update producto set producto = 'Sitios Web', producto_descr='Los mejores sitios web', precio='5000' where producto_id=63
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.CreateParameters(4);
                conexion.AddParameters(0, "@id", id);
                conexion.AddParameters(1, "@nombre", nombre);
                conexion.AddParameters(2, "@descripcion", descripcion);
                conexion.AddParameters(3, "@precio", precio);
                conexion.ExecuteNonQuery(CommandType.Text, "update producto set producto=@nombre , producto_descr=@descripcion,precio=@precio where producto_id=@id");
                conexion.CommitTransaction();      
                conexion.Close();
                return "1";
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
                throw;
            }
        }


        public DataTable fotos_por_producto(int id)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from producto p join img_prod_detail ip on p.producto_id=ip.producto_id where ip.producto_id=" + id).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable fotos_principal_producto(int id)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from producto p join img_prod_detail ip on p.producto_id=ip.producto_id where principal=1 and ip.producto_id=" + id).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }
        public DataTable fotos_principal_producto_lista(int id)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from img_prod_detail where  principal =1 and producto_id=" + id).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable datos_producto(int id)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from producto p left join img_prod_detail ip on p.producto_id = ip.producto_id where p.producto_id=" + id).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable fotos_por_producto_guardadas(int idusuario,int idproducto)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "select * from  img_prod_detail  where producto_id=" + idproducto +" and vendedor_id="+idusuario).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        //insertar foto por producto
        public string instertar_foto_producto(int id_producto, int id_vendedor, string ruta, string titulo_foto, string desc_foto,int principal)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.CreateParameters(6);
                conexion.AddParameters(0,"@id_producto",id_producto);
                conexion.AddParameters(1,"@id_vendedor",id_vendedor);
                conexion.AddParameters(2,"@ruta",ruta);
                conexion.AddParameters(3,"@titulo_foto",titulo_foto);
                conexion.AddParameters(4,"@desc_foto",desc_foto);
                conexion.AddParameters(5,"@principal",principal);
                conexion.ExecuteNonQuery(CommandType.Text, "insert into img_prod_detail values(@id_producto,@id_vendedor,@ruta,@titulo_foto,@desc_foto,@principal) ");
              string res="1";
              conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        public string eliminar_foto_producto(int foto_id)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.ExecuteNonQuery(CommandType.Text, "delete from img_prod_detail where img_prod_detail_id = "+foto_id);
                string res = "1";
                conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        public string update_foto_principal(int id_producto,string ruta)
        {
            conexion.Open();
            conexion.BeginTransaction();
            conexion.CreateParameters(2);
            conexion.AddParameters(0, "@id_producto", id_producto);
            conexion.AddParameters(1, "@ruta", ruta);
            try
            {
                conexion.ExecuteNonQuery(CommandType.Text, "update producto set img_principal =@ruta where producto_id=@id_producto");
                string res = "1";
                conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        } //no se usa

        #region comentarios por producto
        public string instertar_comentario_producto(string comentario, int id_prod , int id_vend)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.CreateParameters(3);
                conexion.AddParameters(0,"@comentario",comentario);
                conexion.AddParameters(1,"@id_prod",id_prod);
                conexion.AddParameters(2,"@id_vend",id_vend);
                conexion.ExecuteNonQuery(CommandType.Text, "insert into Comentarios values (@comentario,@id_prod,@id_vend) ");
                string res = "1";
                conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        public string insertar_respuesta_comentario(string respuesta,int id_comentario, int id_vendedor)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.CreateParameters(3);
                conexion.AddParameters(0,"@respuesta",respuesta);
                conexion.AddParameters(1,"@id_comentario",id_comentario);
                conexion.AddParameters(2,"@id_vendedor",id_vendedor);
                conexion.ExecuteNonQuery(CommandType.Text, "insert into Respuestas values (@respuesta,@id_comentario,@id_vendedor) ");
                string res = "1";
                conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        public DataTable comentarios_por_producto(int idproducto)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "SELECT *  FROM Comentarios c join Vendedor v on c.vendedor_id=v.vendedor_id where c.producto_id="+idproducto).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable respuestas_por_comentario(int idcomentario)
        {
            try
            {
                conexion.Open();
                dt_productos = conexion.ExecuteDataSet(CommandType.Text, "SELECT *  FROM Respuestas r join Vendedor v on r.vendedor_id=v.vendedor_id join Comentarios c on c.comentario_id=r.comentario_id where r.comentario_id=" + idcomentario).Tables[0];
                conexion.Close();
                return dt_productos;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }


        #endregion

        #region eliminar producto

        public string eliminar_producto(int prod)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                conexion.ExecuteNonQuery(CommandType.Text, "delete from producto where producto_id = " + prod);
                string res = "1";
                conexion.CommitTransaction();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        #endregion

        #region calificaciones
        public DataTable calificacion_usuario(int calificado_id)
        {
            try
            {
                conexion.Open();
                dt_calificado = conexion.ExecuteDataSet(CommandType.Text, "SELECT *  FROM calificaciones where calificado_id="+calificado_id).Tables[0];
                conexion.Close();
                return dt_calificado;

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public string instertar_calificacion(int calificacion, int calificado_id, int califica_id,int accion)
        {
            conexion.Open();
            conexion.BeginTransaction();
            try
            {
                 string res;
                conexion.CreateParameters(3);
                conexion.AddParameters(0, "@calificacion", calificacion);
                conexion.AddParameters(1, "@calificado_id", calificado_id);
                conexion.AddParameters(2, "@califica_id", califica_id);
                if (accion == 1) // 1 = primer calificacion, insert
                {
                    conexion.ExecuteNonQuery(CommandType.Text, "Insert into calificaciones values(@calificacion,@calificado_id,@califica_id)");
                    res = "1";
                    conexion.CommitTransaction();
                    conexion.Close();
                }
                else if (accion == 2) //update
                {
                    conexion.ExecuteNonQuery(CommandType.Text, "update calificaciones set calificacion=@calificacion,calificado_id=@calificado_id,califica_id=@califica_id where calificado_id=@calificado_id and califica_id=@califica_id");
                    res = "2";
                    conexion.CommitTransaction();
                    conexion.Close();
                }
                else { res = "0"; } //si no se recibe acción por algún motivo
                

                return res;
            }
            catch (Exception e)
            {
                conexion.RollBackTransaction();
                conexion.Close();
                return e.Message;
            }
        }

        public string ya_calificado(int calificado_id, int califica_id) //regresa el número de calificaciones que hay de un usuario a otro
        {
            try
            {
                conexion.Open();
                conexion.CreateParameters(2);
                conexion.AddParameters(0, "@calificado_id", calificado_id);
                conexion.AddParameters(1, "@califica_id", califica_id);
                string res = conexion.ExecuteScalar(CommandType.Text, "Select count (calificado_id) from calificaciones where calificado_id=@calificado_id and califica_id=@califica_id").ToString();
                conexion.Close();
                return res;

            }
            catch (Exception e)
            {
                
                conexion.Close();
                return e.Message;
            }
        }
        #endregion
    }
}