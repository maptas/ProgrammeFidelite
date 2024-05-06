using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles.Recompenses
{
    public class Categorie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nomCategorie")]
        public string NomCategorie { get; set; }

        [JsonProperty("urlImage")]
        public string UrlImage { get; set; }
    }
}
