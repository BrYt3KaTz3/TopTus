using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace toptusv1
{
    public partial class perfilvendedor : System.Web.UI.Page
    {
        public string nombre, nick, imagen, empresa, pais, estado, email, tipov, fb, tw, lk, gg, ins, ingreso, ide,foto_cali;
        public int cero = 0, dos = 0, cuatro = 0, seis = 0, ocho = 0, diez = 0, cali_general = 0,registros;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "") // cuando si hay parámetros, sea 1 o 2
            {

                int id = int.Parse(Request.QueryString["vendedor"]);
                hdid.Value = id.ToString();
                cargar_datos_vendedor(id);
                cargar_calificaciones(id);
                
                DataBind();
               

            } //fin de , si hay parámetros
            else
            {
                //cuando no hay parámetros, cargar toooodooooooooooooos los productos
            }
        }

        public void cargar_datos_vendedor(int id)
        {
            vendedor.vendedor obj = new vendedor.vendedor();
            var datos = obj.datos_vendedor(id);
            if (datos.Rows.Count == 1)
            {
                ide = datos.Rows[0]["vendedor_id"].ToString();
               
                nombre = datos.Rows[0]["nombre"].ToString();
                nick = datos.Rows[0]["nick"].ToString();
                imagen = datos.Rows[0]["imagen"].ToString();
                empresa = datos.Rows[0]["empresa"].ToString();
                pais = datos.Rows[0]["pais"].ToString();
                estado = datos.Rows[0]["estado"].ToString();
                email = datos.Rows[0]["email"].ToString();
                ingreso = DateTime.Parse(datos.Rows[0]["fecha_solicitud"].ToString()).ToShortDateString();
                tipov = datos.Rows[0]["tipovendedor_descr"].ToString();
            }
            var redes = obj.redes_sociales(id);
            if (redes.Rows.Count == 1)
            {
                fb = redes.Rows[0]["facebook"].ToString();
                tw = redes.Rows[0]["twitter"].ToString();
                gg = redes.Rows[0]["googleplus"].ToString();
                ins = redes.Rows[0]["instagram"].ToString();
                lk = redes.Rows[0]["linkedin"].ToString();
            }
            else
            {
                fb = "";
                tw = "";
                gg = "";
                ins = "";
                lk = "";
            }

            var productos = obj.productos_por_vendedor(id);
            {
                if (productos.Rows.Count == 0)
                {
                    nohay.Text = "<h5>No hay más productos de este vendedor</h5>";
                }
                else { 
                if (productos.Rows.Count > 0)
                {
                    rpt_mas_productos.DataSource = productos;
                    rpt_mas_productos.DataBind();
                }
                else
                {
                    nohay.Text = "<h5>Error al cargar la información.</h5>";
                }
                }
            }
        }

        public void cargar_calificaciones(int id)
        {
            productos_clase obj = new productos_clase();
            var calificaciones = obj.calificacion_usuario(id);
             registros = calificaciones.Rows.Count;
             if (registros == 0)
             {
                 cali_general = 0;
                 foto_cali = "0";
                 //valores en porcentaje de cada calificación
                 cero = 0;
                 dos = 0;
                 cuatro = 0;
                 seis = 0;
                 ocho = 0;
                 diez = 0;
             }
             else
             {
                 #region sihaycalis
                 for (int i = 0; i < registros; i++)
                 {
                     int cal = int.Parse(calificaciones.Rows[i]["calificacion"].ToString());
                     switch (cal)
                     {
                         case 0:
                             cero = cero + 1;
                             cali_general = cali_general + cal;
                             break;
                         case 20:
                             dos = dos + 1;
                             cali_general = cali_general + cal;
                             break;
                         case 40:
                             cuatro = cuatro + 1;
                             cali_general = cali_general + cal;
                             break;
                         case 60:
                             seis = seis + 1;
                             cali_general = cali_general + cal;
                             break;
                         case 80:
                             ocho = ocho + 1;
                             cali_general = cali_general + cal;
                             break;
                         case 100:
                             diez = diez + 1;
                             cali_general = cali_general + cal;
                             break;
                         default:
                             cero = cero + 1;
                             cali_general = cali_general + cal;
                             break;
                     }


                 } //for contadores de calificaciones
                 cali_general = cali_general / registros;
                 if (cali_general == 0)
                 {
                     foto_cali = "0"; 
                 }
                 if (cali_general > 0 && cali_general <= 20)
                 {
                     foto_cali = "20";
                 }
                 if (cali_general > 20 && cali_general <= 40)
                 {
                     foto_cali = "40";
                 }
                 if (cali_general > 40 && cali_general <= 60)
                 {
                     foto_cali = "60";
                 }
                 if (cali_general > 60 && cali_general <= 80)
                 {
                     foto_cali = "80";
                 }
                 if (cali_general > 80 && cali_general <= 100)
                 {
                     foto_cali = "100";
                 }
                 //valores en porcentaje de cada calificación
                 cero = regla_3(cero, registros);
                 dos = regla_3(dos, registros);
                 cuatro = regla_3(cuatro, registros);
                 seis = regla_3(seis, registros);
                 ocho = regla_3(ocho, registros);
                 diez = regla_3(diez, registros);
                 #endregion
             }
            
        }

        public int regla_3(int op1, int dividendo) //dividendo debe ser el total de registros
        {
            int res = (100 * op1) / dividendo;
            return res;
        
        }
        protected void btnCalificar_Click(object sender, EventArgs e)
        {
            if (Session["valido"] == null)
            {
                //no puede comentar 
                string error = "Debes estar logeado para poder calificar.";
                ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('" + error + "')", true);
            }
            else { 
            
                string cali =ratings.Value.ToString();
                int calificacion;

                switch(cali)
                {
                    case "1" :
                        calificacion = 20;
                        break;
                    case "2":
                        calificacion = 40;
                        break;
                    case "3":
                        calificacion = 60;
                        break;
                    case "4":
                        calificacion = 80;
                        break;
                    case "5":
                        calificacion = 100;
                        break;

                    default:
                        calificacion = 0;
                        break;    
                } //switch
                //usuario que califica
                int usuario_califica = id_usuario();
                //usuario a calificar
                int usuario_a_calificar = int.Parse(ide);
                //verificar si ya calificaron
                productos_clase obj = new productos_clase();


                


                    string yacalificado = obj.ya_calificado(usuario_a_calificar, usuario_califica);
                    if (yacalificado == "1") //si ya calificaron antes, actualiza
                    {
                        string res = obj.instertar_calificacion(calificacion, usuario_a_calificar, usuario_califica, 2);
                        if (res == "2")
                        {
                            
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('Calificación actualizada correctamente')", true);
                        }
                        else
                        {
                            
                            
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('Error; " + res + "')", true);
                        }
                    }
                    else if (yacalificado == "0") //nueva inserción(calificaione)
                    {
                        string res = obj.instertar_calificacion(calificacion, usuario_a_calificar, usuario_califica, 1);
                        if (res == "1")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('Calificación asignada correctamente')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('Error; "+res+"')", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mensaje", "mensaje_general('Error:" + yacalificado + "')", true);
                    }

               

                    
            }//else sesión
        }


        public int id_usuario() //método para obtener id del usuario actual
        {
            var sesion = HttpContext.Current.Session["usuario"];
            DataTable usuario = (DataTable)sesion;
            int id_usuario = int.Parse(usuario.Rows[0]["vendedor_id"].ToString());
            return id_usuario;
        }

    }
}