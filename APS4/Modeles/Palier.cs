using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class Palier
    {
        private int _id;
        private string _nom;
        private int _palierBas;
        private int _palierHaut;
        private readonly GestionApi _apiServices = new GestionApi();
        private int _userId;

        public Palier(string nom = null, int palierBas = 0, int palierHaut = 0)
        {
            this._nom = nom;
            this._palierBas = palierBas;
            this._palierHaut = palierHaut;
            this._userId = Constantes.AdminId;
        }

        public int Id { get => _id; set => _id = value; }

        [JsonProperty(PropertyName = "nomPalier")]
        public string Nom { get => _nom; set => _nom = value; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserId { get => _userId; set => _userId = value; }

        [JsonProperty(PropertyName = "palierBas")]
        public int PalierBas { get => _palierBas; set => _palierBas = value; }

        [JsonProperty(PropertyName = "palierHaut")]
        public int PalierHaut { get => _palierHaut; set => _palierHaut = value; }

        public async Task<bool> AddPalier()
        {
            try
            {
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Palier resultat = await _apiServices.GetOneAsync<Palier>("api/mobile/creerPalier", this);

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
