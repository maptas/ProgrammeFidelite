using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS4.Apis;
using APS4.Modeles;
using Newtonsoft.Json;

namespace APS4.Modeles
{
    public class Blason
    {
        #region Attributs

        private int _id;
        private string _nomBlason;
        private double _montantAchat;
        public static List<Blason> listBlason = new List<Blason>();
        private readonly GestionApi _apiServices = new GestionApi();
        private ObservableCollection<Blason> collBlason = new ObservableCollection<Blason>();

        #endregion

        #region Constructeurs
        public Blason(string nomBlason, double montantAchat)
        {
            _nomBlason = nomBlason;
            _montantAchat = montantAchat;
            listBlason.Add(this);
        }
        #endregion

        #region Getter/Setter

        public int Id { get => _id; set => _id = value; }

        [JsonProperty(PropertyName = "nomBlason")]
        public string NomBlason { get => _nomBlason; set => _nomBlason = value; }

        [JsonProperty(PropertyName = "montantAchats")]
        public double MontantAchat { get => _montantAchat; set => _montantAchat = value; }
        public ObservableCollection<Blason> CollBlason { get => collBlason; set => collBlason = value; }

        #endregion

        #region Methodes

        public async Task<bool> GetBlason()
        {
            try
            {
                this.collBlason = await _apiServices.GetAllAsync<Blason>("api/mobile/GetAllBlasons");
            }
            catch (HttpRequestException httpEx)
            {
                // Gestion spécifique des exceptions liées aux requêtes HTTP
                Console.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Gestion générale des erreurs
                Console.WriteLine($"An error occurred while getting blason research: {ex.Message}");
            }
            foreach(Blason blason in this.collBlason)
            {
                if(this.NomBlason == blason.NomBlason && this.MontantAchat == blason.MontantAchat)
                {
                    return true;
                }
            }
            return false;
        }

        public async void GetAllBlason()
        {
            try
            {
                this.collBlason = await _apiServices.GetAllAsync<Blason>("api/mobile/GetAllBlasons");
            }
            catch (HttpRequestException httpEx)
            {
                // Gestion spécifique des exceptions liées aux requêtes HTTP
                Console.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Gestion générale des erreurs
                Console.WriteLine($"An error occurred while getting blason research: {ex.Message}");
            }
        }

        public async Task<bool> AddBlason()
        {
            try
            {
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                Blason resultat = await _apiServices.GetOneAsync<Blason>("api/blason/creerBlason", this);

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
