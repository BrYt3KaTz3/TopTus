using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace toptusv1
{
    public class prueba_json
    {
        public int categoria_id { get; set; }
        public string categoria_descr { get; set; }
        public int orden { get; set; }
    }

    public class sub_json
    {
        public int subcategoria_id { get; set; }
        public string subcategoria_descr { get; set; }
        public int categoria_id { get; set; }
    }
}