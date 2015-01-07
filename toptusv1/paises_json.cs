using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace toptusv1
{
    //propiedads para caché
    public class paises_json
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string FIPS104 { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public string ISON { get; set; }
        public string Internet { get; set; }
        public string Capital { get; set; }
        public string MapReference { get; set; }
        public string NationalitySingular { get; set; }
        public string NationalityPlural { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string Population { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
    //fin propiedades

    public class region_json
    {
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public string Region { get; set; }
        public string Code { get; set; }
        public string ADM1Code { get; set; }
    }
}