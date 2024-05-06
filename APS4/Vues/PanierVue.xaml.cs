using APS4.Modeles;
using APS4.Apis;
using APS4.Modeles.Panieee;
using System.Collections.ObjectModel;

namespace APS4.Vues;

public partial class PanierVue : ContentPage
{
    private readonly GestionApi _apiServices = new GestionApi();
    private ObservableCollection<Panier> resultCommande = new ObservableCollection<Panier>();
    private Panier panier;

    ObservableCollection<Commander> commandesSansDoublons;
    private ObservableCollection<Commander> maListeCommander;
    private int laCommande = 0;
    private double prixTotal = 0;
    private User U = Constantes.CurrentUser;

    public PanierVue()
	{
		InitializeComponent();

        User user = Constantes.CurrentUser;



        GetAllCommander2();
    }

    private async void GetAllCommander2()
    {
        this.resultCommande = await _apiServices.GetAllAsyncByID<Panier>("api/mobile/GetAllCommandes", "Id", Constantes.CurrentUser.Id);
        foreach (var commande in this.resultCommande)
        {
            if (commande.Etat == "en cours" && commande.UserId == Constantes.CurrentUser.Id)
            {
                this.laCommande = commande.IdPanier;
            }
        }
        if (this.laCommande == 0)
        {
            //CreateNewPanier
            Panier p = new Panier();
            bool res = await p.AddCommande();
            if (res)
            {
                this.resultCommande = await _apiServices.GetAllAsyncByID<Panier>("api/mobile/GetAllCommandes", "Id", Constantes.CurrentUser.Id);
                foreach (var commande in this.resultCommande)
                {
                    if (commande.Etat == "en cours" && commande.UserId == Constantes.CurrentUser.Id)
                    {
                        this.laCommande = commande.IdPanier;
                    }
                }
            }
        }
        var result = await _apiServices.GetAllAsyncByID<Commander>("api/mobile/GetAllCommander", "Id", this.laCommande);
        this.maListeCommander = result;

        if(this.maListeCommander != null)
        {
            //var commandesAgrégées = maListeCommander
            //    .GroupBy(c => c.LeProduit.NomProduit)
            //    .Select(g => new Commander { LeProduit = new Produit { NomProduit = g.Key }, Quantite = g.Sum(c => c.Quantite) });


            Dictionary<string, Commander> produitsUniques = new Dictionary<string, Commander>();
            foreach (var commande in maListeCommander)
            {
                string nomProduit = commande.LeProduit.NomProduit;
                if (!produitsUniques.ContainsKey(nomProduit))
                {
                    produitsUniques[nomProduit] = commande;
                }
                else
                {
                    produitsUniques[nomProduit].Quantite += commande.Quantite;
                }
            }

            commandesSansDoublons = new ObservableCollection<Commander>(produitsUniques.Values);
            MalisteProduits.ItemsSource = commandesSansDoublons;

            foreach (Commander ma in commandesSansDoublons)
            {
                this.prixTotal += ma.Quantite * ma.LeProduit.PrixProduit;
            }
            PrixTotalLabel.Text = "Prix total : "+this.prixTotal.ToString() + "€";
        }
    }

    private async void PayerPanier_Clicked(object sender, EventArgs e)
    {
        int sommePointsGagnee = 0;
        if(this.commandesSansDoublons != null)
        {
            foreach (var item in this.commandesSansDoublons)
            {
                sommePointsGagnee += item.LeProduit.PointsFidelite * item.Quantite;
            }
        }

        if(sommePointsGagnee > 50)
        {
            sommePointsGagnee *= (int)1.1;
        }
        else if (sommePointsGagnee > 75)
        {
            sommePointsGagnee *= (int)1.3;
        }
        else if (sommePointsGagnee > 100)
        {
            sommePointsGagnee *= (int)1.5;
        }
        this.U.StockPointsFidelite += sommePointsGagnee;

        bool res = await U.ModifUser();

        if (res)
        {
            this.resultCommande = await _apiServices.GetAllAsyncByID<Panier>("api/mobile/GetAllCommandes", "Id", Constantes.CurrentUser.Id);
            foreach (var commande in this.resultCommande)
            {
                if (commande.Etat == "en cours" && commande.UserId == Constantes.CurrentUser.Id)
                {
                    this.panier = commande;
                    this.panier.Etat = "fin";
                }
            }
            Task t2 = panier.UpdateCommande();

            await DisplayAlert("Bravo", "Bravo, vous avez gagné " + sommePointsGagnee + " points !", "OK");

            await Task.WhenAll(t2);
            await Navigation.PushAsync(new AccueilVue());
        }
        else
        {
            await DisplayAlert("Erreur", "Erreur.", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    private async void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); //reviens à la page précédente.
        //await Navigation.PushAsync(new AccueilVue());
    }
}