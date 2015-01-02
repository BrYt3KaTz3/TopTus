using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace toptusv1
{
    public partial class json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cat;
            string filejson = HttpContext.Current.Server.MapPath("~/json/json.json"); //ruta
            if (File.Exists(filejson))
            {
                string si;
                cat = lectura(filejson);
                p.InnerText = cat + " ta existe";
            }
            else
            {
                string no;
                creacion_json(filejson);
            }
           
               
           
           
           
            string a;
        }

        public string lectura(string path) //exista o no
        {
            //pa leer desde archivo
            StreamReader r = new StreamReader(path);

            string file = r.ReadToEnd();
            List<prueba_json> categorias_json = JsonConvert.DeserializeObject<List<prueba_json>>(file);
            string cat = categorias_json[0].categoria_descr;
            r.Close();
            return cat;
            //termina lectura de json
        }

        public void creacion_json(string path) //cuando no existe, lo crea , lo cierra y escribe en el
        {
            categorias_menu obj = new categorias_menu();
            var categorias = obj.categorias();
            var json = JsonConvert.SerializeObject(categorias);


            StreamWriter files = File.CreateText(path);
            files.Close();

            File.WriteAllText(path, json);
            string cat=lectura(path);
            p.InnerText = cat+" creacion";
            files.Close();
        }
    }
}