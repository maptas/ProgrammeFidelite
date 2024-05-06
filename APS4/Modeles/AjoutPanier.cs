using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class AjoutPanier
    {
        #region Attributs

        private int _idCommander;
        private int _userId;
        private int _panierId;
        private int _produitId;
        private int _quantite;
        private readonly GestionApi _apiServices = new GestionApi();

        #endregion

        #region Constructeur
        public AjoutPanier(int panier, int produit, int quantite = 1)
        {
            this._userId = Constantes.CurrentUser.Id;
            this._panierId = panier;
            this._produitId = produit;
            this._quantite = quantite;
        }

        #endregion

        #region Getter/Setter

        public int IdCommander { get => _idCommander; set => _idCommander = value; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserId { get => _userId; set => _userId = value; }

        [JsonProperty(PropertyName = "laCommande")]
        public int Panier { get => _panierId; set => _panierId = value; }

        [JsonProperty(PropertyName = "leProduit")]
        public int Produits { get => _produitId; set => _produitId = value; }

        [JsonProperty(PropertyName = "quantite")]
        public int Quantite { get => _quantite; set => _quantite = value; }

        #endregion

        #region Methodes

        public async Task<bool> AddCommander()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                AjoutPanier resultat = await _apiServices.GetOneAsync<AjoutPanier>("api/mobile/creerCommander", this);

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
                Console.WriteLine($"An error occurred while getting produit research: {ex.Message}");
            }

            return false;
        }

        #endregion
    }
}
