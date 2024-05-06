using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class Categorie
    {
        private int _id;
        private string _nom;
        private string urlImage;
        private readonly GestionApi _apiServices = new GestionApi();
        private int _userId;

        public Categorie(string nom = null, string urlImage = null)
        {
            _nom = nom;
            this.urlImage = urlImage;
            this._userId = Constantes.AdminId;
        }

        public int Id { get => _id; set => _id = value; }

        [JsonProperty(PropertyName = "nomCategorie")]
        public string Nom { get => _nom; set => _nom = value; }

        [JsonProperty(PropertyName = "urlImage")]
        public string UrlImage { get => urlImage; set => urlImage = value; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserId { get => _userId; set => _userId = value; }

        public async Task<bool> AddCategorie()
        {
            try
            {
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Categorie resultat = await _apiServices.GetOneAsync<Categorie>("api/mobile/creerCategorie", this);

                if (resultat != null)
                {
                    return true;
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Gestion spécifique des exceptions liées aux requêtes HTTP
                Console.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Gestion générale des erreurs
                Console.WriteLine($"An error occurred while getting produit creation: {ex.Message}");
            }

            return false;
        }
    }
}
