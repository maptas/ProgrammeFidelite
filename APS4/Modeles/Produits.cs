using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class Produits
    {
        #region Attributs

        private string _nom;
        private double _prix;
        private int _pointParAchat;
        private readonly GestionApi _apiServices = new GestionApi();
        private int _userId;
        private int _categorieId;

        #endregion

        #region Constructeurs

        public Produits(string nom, double prix, int pointParAchat = 0)
        {
            this._nom = nom;
            this._prix = prix;
            this.PointParAchat = pointParAchat;
            this._userId = Constantes.CurrentUser.Id;
            this._categorieId = 1;
        }

        #endregion

        #region Methodes

        public async Task<bool> GetProduit()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Produits resultat = await _apiServices.GetOneAsync<Produits>("api/mobile/GetOneProduit", this);

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

        public async Task<ObservableCollection<Produits>> GetAllProduits()
        {
            ObservableCollection<Produits> resultat;
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                //resultat = await _apiServices.GetOneAsync<List<Produits>>("api/mobile/GetAllProduits", Constantes.CurrentUser.Id);
                resultat = await _apiServices.GetAllAsyncByID<Produits>("api/mobile/GetAllProduits", "userId", Constantes.CurrentUser.Id);

                
            }
            catch (HttpRequestException httpEx)
            {
                resultat = null;
                // Gestion spécifique des exceptions liées aux requêtes HTTP
                Console.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                resultat = null;
                // Gestion générale des erreurs
                Console.WriteLine($"An error occurred while getting produit research: {ex.Message}");
            }
            return resultat;
        }

        public async Task<bool> AddProduit()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Produits resultat = await _apiServices.GetOneAsync<Produits>("api/mobile/creerProduit", this);

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

        #endregion

        #region Getters/Setters

        [JsonProperty(PropertyName = "nomProduit")]
        public string Nom { get => _nom; set => _nom = value; }

        [JsonProperty(PropertyName = "prixProduit")]
        public double Prix { get => _prix; set => _prix = value; }

        [JsonProperty(PropertyName = "pointsFidelite")]
        public int PointParAchat { get => _pointParAchat; set => _pointParAchat = value; }

        [JsonProperty(PropertyName = "Id")]
        public int UserId { get => _userId; set => _userId = value; }

        [JsonProperty(PropertyName = "categorieId")]
        public int CategorieId { get => _categorieId; set => _categorieId = value; }

        #endregion
    }
}
