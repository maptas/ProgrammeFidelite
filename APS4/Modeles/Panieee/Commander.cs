using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles.Panieee
{
    public class Commander
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quantite")]
        public int Quantite { get; set; }

        [JsonProperty("leProduit")]
        public Produit LeProduit { get; set; }
        public string LeNomProduit { get { return this.LeProduit.NomProduit; } }

        public string ImageUrl { get { return this.LeProduit.ImageUrl; } }
    }
}
