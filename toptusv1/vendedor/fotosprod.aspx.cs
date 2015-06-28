using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace toptusv1.vendedor
{
    public partial class fotosprod : System.Web.UI.Page
    {
        public string producto;
        public int id_prodd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["valido"] == null)
                {
                    Response.Redirect("../login.aspx");
                }
                //else.... usuario válido
                else
                {


                    cargar_datos();
                    DataBind();


                }
            }
        }

        public void cargar_datos()
        {
            vendedor obj = new vendedor();
            productos_clase obj_prod = new productos_clase();

            int id_prod = int.Parse(desencriptar());
            id_prodd = id_prod;
            var producto_datos = obj_prod.datos_producto(id_prod);
            if (producto_datos.Rows.Count > 0)
            {
                producto = producto_datos.Rows[0]["producto"].ToString();
            }

            cargar_fotos_producto(id_prod);
          
            

        }


        public string desencriptar()
        {
            string ID = Request.QueryString["prod"].ToString();
            string des = seguridad.DesEncriptar(ID);
            return des;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            productos_clase obj = new productos_clase();
            //idproducto
            int id_prod = int.Parse(desencriptar());
            //id usuario
            int id_user=id_usuario();



            #region carga_foto
            if (FileUpload1.HasFile)//true
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower(); //obtener la extensión del archivo


                //insertar el nombre en la bd
                string fotonombre = txtNombreFoto.Text;
                //aquí poner el diccionario de x fotos por producto
                var size = FileUpload1.PostedFile.ContentLength;
                if (size <= 524288)
                {

                    #region ext
                    if ( extension == ".jpg" || extension==".jpeg" || extension==".bmp" || extension==".png")
                    {

                        #region insercionfotoproducto
                        string foto = FileUpload1.FileName;
                        string ruta = "vendedor/prod_fotos/" + id_user + "/" + id_prod + "/" + foto;
                        string prod_album = Server.MapPath("prod_fotos/") + id_user + "/" + id_prod; //se asigna la dirección ya con el nuevo id para verificar después

                        #region insercion fotosxproducto y verifica si es la primer foto
                        vendedor obj_dic = new vendedor();
                        int tipo = tipo_vendedor(); //tipo de vendedor
                        var restantes = obj_dic.valores_tipo_vendedor(tipo);
                        var fotos_guardadas = obj.fotos_por_producto_guardadas(id_user, id_prod);
                        int fotos_restantes =int.Parse(restantes.Rows[0]["img_prod"].ToString());
                        if (fotos_guardadas.Rows.Count < fotos_restantes)
                        {
                            //aún puedes agregar fotos, pregutar ahora si es la primera
                            if( fotos_guardadas.Rows.Count==0)//preguntar si es la primera, si no , solo seagrega, si si, se agrega y se update producto
                            {
                               
                                string ruta_principal="prod_fotos/"+id_prod+extension;
                                //string resfotoprincipal = obj.update_foto_principal(id_prod, ruta_principal);
                                
                                if ("1" == "1") // si se guard´bien el nombre de la foto principal, se puso 1=1 por un error desconocido xD
                                {
                                    string res = obj.instertar_foto_producto(id_prod, id_user, ruta, txtNombreFoto.Text, txtDescripcionFoto.Text,1); // se inserta en la bd los datos de la nueva foto img_prod_detail
                                    if (res == "1")
                                    {
                                        string rutaraiz = Server.MapPath("prod_fotos/");
                                        FileUpload1.PostedFile.SaveAs(rutaraiz + +id_prod + extension);
                                        bool existe_folder = System.IO.Directory.Exists(prod_album); //se pregunta si existe el folder

                                        if (!existe_folder) //si no existe el folder (lo más seguro) se crea dentro del if
                                        {
                                            System.IO.Directory.CreateDirectory(prod_album);
                                            FileUpload1.PostedFile.SaveAs(prod_album + "/" + foto);
                                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                                        }

                                        else
                                        {

                                            FileUpload1.PostedFile.SaveAs(prod_album + "/" + foto);
                                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                                        }
                                    }
                                    else
                                    {
                                        string error_por_foto = "Ocurrio un error al guardar la foto";
                                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + error_por_foto + "')", true);
                                    }
                                    
                                }
                                else
                                { //error al guardar el update de la foto principal
                                   // string error_principal = "Ocurrio un error al guardar la foto principal";
                                    //ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + error_principal + "')", true);
                                }
                                
                            }
                            else
                            { // no es la primer foto
                               
                                string res = obj.instertar_foto_producto(id_prod, id_user, ruta, txtNombreFoto.Text, txtDescripcionFoto.Text,1); // se inserta en la bd los datos de la nueva foto img_prod_detail

                                if (res == "1")
                                {
                                  
                                    bool existe_folder = System.IO.Directory.Exists(prod_album); //se pregunta si existe el folder

                                    if (!existe_folder) //si no existe el folder (lo más seguro) se crea dentro del if
                                    {
                                        System.IO.Directory.CreateDirectory(prod_album);
                                        FileUpload1.PostedFile.SaveAs(prod_album + "/" + foto);
                                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                                        
                                    }

                                    else
                                    {

                                        FileUpload1.PostedFile.SaveAs(prod_album + "/" + foto);
                                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_insertar()", true);
                                    }
                                }
                                else
                                {
                                    string error_por_foto = "Ocurrio un error al guardar la foto";
                                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + error_por_foto + "')", true);
                                }
                            }
                        }
                        else//
                        {
                            string restante = "Has llegado al límite de fotos de tu cuenta";
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + restante + "')", true);
                        }


                            

                    #endregion





                        #endregion
                    }

                    else
                    {
                        string res = "Extensión no válida, solo .jpg .png o .bmp";
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar('" + res + "')", true);
                    }
                    #endregion
                }
                else {
                    string res = "Tamaño de fotografía excedido, máximo 512kb por foto";
                    ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar_foto('" + res + "')", true);
                }

            }//fin primer if hasfile
            else
            {
                string res = "No has elegido ninguna fotografía";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar_foto('" + res + "')", true);

            }
            #endregion
        }

        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

        public int tipo_vendedor() //obtener el tipo de vendedor
        {
            var sesion = HttpContext.Current.Session["usuario"];

            DataTable usuario = (DataTable)sesion;
            int id_tipo_vendedor = int.Parse(usuario.Rows[0]["tipovendedor_id"].ToString());
            return id_tipo_vendedor;
        }

        public void cargar_fotos_producto(int id)
        {
            productos_clase obj = new productos_clase();
            var fotos = obj.fotos_por_producto(id);
            if (fotos.Rows.Count > 0)
            {

                rptFotoProducto.DataSource = fotos;
                rptFotoProducto.DataBind();
            }
            else
            {
                nofotos.Text = "<h4>No hay fotos para este producto.</h4>";
            }
        }

        protected void btnEliminarFoto_Command(object sender, CommandEventArgs e)
        {
          
            
            
            string args = e.CommandArgument.ToString();
            string[] parametros = args.Split(';');
            int id_foto = int.Parse(parametros[0].ToString());
            string ruta_foto = parametros[1].ToString();
            string ruta = Server.MapPath("../"+ruta_foto);
            string a = "2" ;
            
            if (e.CommandName == "eliminar_foto")
            {

                try
                {
                  

                    productos_clase obj = new productos_clase();

                    string res = obj.eliminar_foto_producto(id_foto); //eliminar registro
                    if (res == "1")
                    {
                        //eliminar del server
                        System.IO.File.Delete(ruta);
                        
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "success_eliminar_foto()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "error_insertar(" + res + ")", true);
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
               

            }
                
           
        }

        public string encriptar_url(string id_producto)
        {
            string encriptado = seguridad.Encriptar(id_producto);
            return encriptado;
        }

    }
}