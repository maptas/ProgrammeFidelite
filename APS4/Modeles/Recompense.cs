using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;
using APS4.Modeles.Recompenses;

namespace APS4.Modeles
{
    public class Recompense
    {
        #region Attributs

        private int _id;
        private string _nomRecompense;
        private int _pointsNecessaire;
        private int _produitID;
        private int _userID;
        private Produits _produits;
        private readonly GestionApi _apiServices = new GestionApi();

        #endregion

        #region Getter/Setter

        public int Id { get => _id; set => _id = value; }

        [JsonProperty(PropertyName = "nomRecompense")]
        public string NomRecompense { get => _nomRecompense; set => _nomRecompense = value; }

        [JsonProperty(PropertyName = "pointsNecessaires")]
        public int PointsNecessaire { get => _pointsNecessaire; set => _pointsNecessaire = value; }

        [JsonProperty(PropertyName = "leProduit")]
        public int ProduitsId { get => _produitID; set => _produitID = value; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserID { get => _userID; set => _userID = value; }
        public Produits Produits { get => _produits; set => _produits = value; }
        public string leNomProduit()
        {
            return this._produits.Nom;
        }

        #endregion
        #region Constructeurs

        public Recompense(string nomRecompense = null, int pointsNecessaire = 10, int produits = 0)
        {
            this._nomRecompense = nomRecompense;
            this._pointsNecessaire = pointsNecessaire;
            this._produitID = produits;
            this._userID = Constantes.AdminId;
        }

        #endregion

        #region Méthodes

        public async Task<bool> GetRecompense()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Recompense resultat = await _apiServices.GetOneAsync<Recompense>("api/mobile/GetOneProduit", this);

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

        public async Task<ObservableCollection<Recompense>> GetAllRecompenses()
        {
            ObservableCollection<Recompense> resultat;
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                //resultat = await _apiServices.GetOneAsync<List<Produits>>("api/mobile/GetAllProduits", Constantes.CurrentUser.Id);
                resultat = await _apiServices.GetAllAsyncByID<Recompense>("api/mobile/GetAllProduits", "userId", Constantes.CurrentUser.Id);


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

        public async Task<bool> AddRecompense()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Recompense resultat = await _apiServices.GetOneAsync<Recompense>("api/mobile/creerRecompense", this);

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
    }
}
