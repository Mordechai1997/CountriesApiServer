using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApiServer.Models
{
    public class Country
    {
        public string name { get; set; }
        public string[] topLevelDomain { get; set; }
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
        public string[] callingCodes { get; set; }
        public string capital { get; set; }
        public string[] altSpellings { get; set; }
        public string region { get; set; }
        public string Subregion { get; set; }
        public string cioc { get; set; }
        public long population { get; set; }
        public bool independent { get; set; }
        public double [] latlng { get; set; }
        public string demonym { get; set; }
        public double area { get; set; }
        public string nativeName { get; set; }
        public string numericCode { get; set; }
        public Flags flags { get; set; }
        public string flag { get; set; }
        public string [] borders { get; set; }
        public Currencies[] currencies { get; set; }
        public Languages[] languages { get; set; }
    }
    public class Flags
    {
        public string svg { get; set; }
        public string png { get; set; }
    }
    public class Currencies
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }

    }
    public class Languages
    {
        public string iso639_1 { get; set; }
        public string iso639_2 { get; set; }
        public string name { get; set; }
        public string nativeName { get; set; }


    }
}


