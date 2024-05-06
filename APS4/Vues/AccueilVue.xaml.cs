using Microsoft.Maui.Controls;
using APS4.Modeles;
using APS4.Apis;
using System.Collections.ObjectModel;

namespace APS4.Vues;

public partial class AccueilVue : ContentPage
{
    private readonly GestionApi _apiServices = new GestionApi();
    private ObservableCollection<Produits> resultProduit = new ObservableCollection<Produits>();
    private ObservableCollection<Panier> resultPanier = new ObservableCollection<Panier>();
    private Panier panier = null;
    public AccueilVue()
	{
		InitializeComponent();
        try
        {
            User user = Constantes.CurrentUser;
            //user.GetMontantTotalAchat();
            //user.SetBlason();
        }
        catch
        {

        }

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        this.AddListProduits();//Ce bug est peut être dû au fait qu'il y a un async dans le async du changement de page.

      await  GetCurrentCommande();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
    private async void AddListProduits()
    {
        this.resultProduit = await _apiServices.GetAllAsyncByID<Produits>("api/mobile/GetAllProduits", "Id", Constantes.AdminId);

        var listeee = this.resultProduit.OrderBy(e => e.Prix);
        this.resultProduit = new ObservableCollection<Produits>(listeee);

        MalisteProduits.ItemsSource = this.resultProduit;
    }

    private async Task<Panier> GetCurrentCommande()
    {
        this.resultPanier = await _apiServices.GetAllAsyncByID<Panier>("api/mobile/GetAllCommandes", "Id", Constantes.CurrentUser.Id);
        foreach(var item in this.resultPanier)
        {
            //if (item.UserId == Constantes.CurrentUser.Id)
            //{ 
                if(item.Etat == "en cours")
                {
                    this.panier = item;
                } 
            //}
        }
        if (this.panier == null)
        {
            Panier p = new Panier();
            bool res = await p.AddCommande();
            return p;
        }
        return this.panier;
    }

    private async void AjoutPanierButton_Clicked(object sender, EventArgs e)
    {
        Produits P = MalisteProduits.SelectedItem as Produits;
        //Création d'une commande :
        //Dans la bdd, on doit créer une commande (idCommande, idUser, Date)
        bool res = await panier.AddCommande();

        if(res)
        {
            //Ensuite, on doit ajouter cette commande à la table "commander" (id, userId, commandeId, quantite, produitId)
            //Ici, on peut ajouter les produits un par un, avec une quantite
            //await panier.AddCommander(Produits P, int quantite);
        }

    }

    private async void ProduitTapped(object sender, TappedEventArgs e)
    {
        var label = sender as Label;
        string popup = await DisplayPromptAsync("Quantité", "Combien voulez-vous de "+label+" ?", initialValue: "1", maxLength: 2, keyboard: Keyboard.Numeric, accept: "Ajouter au panier", cancel: "Annuler");
        var panier = GetCurrentCommande();

        if (label != null)
        {
            var produit = label.BindingContext as Produits;

            if(popup != null)
            {
                AjoutPanier ajoutP = new AjoutPanier(panier.IdPanier, produit.ProduitId, int.Parse(popup));

                bool res = await ajoutP.AddCommander();
                if (res)
                {

                }
            }
        }

        //Produits P = MalisteProduits.SelectedItem as Produits;

        //Ensuite, on doit ajouter cette commande à la table "commander" (id, userId, commandeId, quantite, produitId)
        //Ici, on peut ajouter les produits un par un, avec une quantite
        //await panier.AddCommander(Produits P, int quantite);
    }

    private async void ChangePage_Magasin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccueilVue());
    }

    private async void ChangePage_PointFidelite_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PointsFidelite());
    }

    private async void ChangePage_MiniJeux_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiniJeuxVue());
    }

    private async void ChangePage_Panier_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PanierVue());
    }

    private async void ChangePage_Profil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profil());
    }

    private async void ChangePage_EchangePts_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EchangePointsVue());
    }
}