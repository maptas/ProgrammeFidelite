using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;

namespace APS4.Modeles
{
    public class User
    {
        #region Attributs

        private int _id;
        private string _email;
        private string _mdp;
        private readonly GestionApi _apiServices = new GestionApi();
        public static List<User> CollClasse = new List<User>();

        #endregion

        #region Constructeurs

        public User(int id, string email, string mdp)
        {
            this._id = id;
            this._email = email;
            this._mdp = mdp;
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

        #endregion

        #region Getters/Setters

        public int Id { get => _id; set => _id = value; }
        public string Email { get => _email; set => _email = value; }
        public string Mdp { get => _mdp; set => _mdp = value; }

        #endregion
    }
}
