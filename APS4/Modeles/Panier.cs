using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using APS4.Modeles;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class Panier
    {
        #region Attributs
        private int _idPanier;
        private DateTime _dateCommande;
        private List<Produits> _listProduits;
        private int _userId;
        private readonly GestionApi _apiServices = new GestionApi();
        private string _etat;
        #endregion

        #region Constructeurs
        public Panier(string etat = "en cours", DateTime dateCommande = default)
        {
            this._dateCommande = dateCommande;
            this._userId = Constantes.CurrentUser.Id;
            _listProduits = new List<Produits>();
            this._etat = etat;
        }
        #endregion

        #region Getter/Setter

        [JsonProperty(PropertyName = "Id")]
        public int IdPanier { get => _idPanier; set => _idPanier = value; }
        public DateTime DateCommande { get => _dateCommande; set => _dateCommande = value; }
        public List<Produits> ListProduits { get => _listProduits; set => _listProduits = value; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserId { get => _userId; set => _userId = value; }

        [JsonProperty(PropertyName = "etat")]
        public string Etat { get => _etat; set => _etat = value; }
        #endregion

        #region Methodes

        public async Task<bool> AddCommande()
        {
            try
            {
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Panier resultat = await _apiServices.GetOneAsync<Panier>("api/mobile/creerCommande", this);

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

        public async Task<bool> GetCommande()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Panier resultat = await _apiServices.GetOneAsync<Panier>("api/mobile/GetOneProduit", this);

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

        public async Task<bool> UpdateCommande()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Panier resultat = await _apiServices.GetOneAsync<Panier>("api/mobile/updateCommande", this);

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

        /*Voir :
         * Soit suppression de la commande une fois passé,
         * Soit Ajouter etat de la commande dans la bdd pour savoir lesquelles sont déjà passé ou non
         */
        public async Task<bool> RemoveCommande()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Panier resultat = await _apiServices.GetOneAsync<Panier>("api/mobile/GetOneProduit", this);

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

        public async Task<bool> AddCommander(Produits P, int quantite)
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Panier resultat = await _apiServices.GetOneAsync<Panier>("api/mobile/creerCommander", this);

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
