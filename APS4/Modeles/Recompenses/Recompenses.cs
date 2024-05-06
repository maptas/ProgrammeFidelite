using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles.Recompenses
{
    public class Recompenses
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nomRecompense")]
        public string NomRecompense { get; set; }

        [JsonProperty(PropertyName = "pointsNecessaires")]
        public int PointNecessaire { get; set; }
        public int ProduitsId { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserID { get; set; }

        [JsonProperty(PropertyName = "leProduit")]
        public Produit Produits { get; set; }

        public string LeNomProduit { get { return this.Produits.NomProduit; } }

        public string UrlImage { get {  return this.Produits.ImageUrl; } }
    }
}
