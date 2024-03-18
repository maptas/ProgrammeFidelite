using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class User
    {
        #region Attributs

        private int _id;
        private string _email;
        private string _password;
        private string _prenom;
        private string _nom;
        private string _telephone;
        private DateTime _dateNaissance;
        private int _stockPointsFidelite;
        private Blason _blason;
        //Ajouter Blason une fois la classe faite (regarder exemple Symfony GestionFidelite git prof)
        private readonly GestionApi _apiServices = new GestionApi();
        public static List<User> CollClasse = new List<User>();

        #endregion

        #region Constructeurs

        public User(string email, string password)
        {
            this._email = email;
            this._password = password;
            //this._blason = null;
            CollClasse.Add(this);
        }

        #endregion

        #region Methodes

        public async Task<bool> GetUserRegistration()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                User resultat = await _apiServices.GetOneAsync<User>("api/mobile/GetFindUser", this);

                if (resultat != null)
                {
                    Constantes.CurrentUser = resultat;

                    // Vérifiez si c'est vraiment ce que vous voulez faire.
                    // Si la collection ne doit contenir que l'utilisateur actuel, c'est correct.
                    User.CollClasse.Clear();


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
                Console.WriteLine($"An error occurred while getting user registration: {ex.Message}");
            }

            return false;
        }

        public async Task<bool> AddUserRegistration()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                User resultat = await _apiServices.GetOneAsync<User>("api/mobile/setInscription", this);

                if (resultat != null)
                {
                    Constantes.CurrentUser = resultat;

                    // Vérifiez si c'est vraiment ce que vous voulez faire.
                    // Si la collection ne doit contenir que l'utilisateur actuel, c'est correct.
                    User.CollClasse.Clear();


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
                Console.WriteLine($"An error occurred while getting user registration: {ex.Message}");
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

        #endregion

        #region Getters/Setters

        [JsonProperty(PropertyName = "id")]
        public int Id { get => _id; set => _id = value; }

        [JsonProperty(PropertyName ="email")]
        public string Email { get => _email; set => _email = value; }

        [JsonProperty(PropertyName = "password")] 
        public string Password { get => _password; set => _password = value; }

        [JsonProperty(PropertyName = "prenom")]
        public string Prenom { get => _prenom; set => _prenom = value; }

        [JsonProperty(PropertyName = "nom")]
        public string Nom { get => _nom; set => _nom = value; }

        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get => _telephone; set => _telephone = value; }

        [JsonProperty(PropertyName = "dateNaissance")]
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }

        [JsonProperty(PropertyName = "StockPointsFidelite")]
        public int StockPointsFidelite { get => _stockPointsFidelite; set => _stockPointsFidelite = value; }
        public Blason Blason { get => _blason; set => _blason = value; }

        #endregion
    }
}
