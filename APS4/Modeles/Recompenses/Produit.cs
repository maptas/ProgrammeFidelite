using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles.Recompenses
{
    public class Produit
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nomProduit")]
        public string NomProduit { get; set; }

        [JsonProperty("prixProduit")]
        public double PrixProduit { get; set; }

        [JsonProperty("pointsFidelite")]
        public int PointsFidelite { get; set; }

        [JsonProperty("laCategorie")]
        public Categorie LaCategorie { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
