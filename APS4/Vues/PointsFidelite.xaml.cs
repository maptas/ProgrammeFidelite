using APS4.Modeles;
using APS4.Apis;
using APS4.Modeles.Recompenses;
using System.Collections.ObjectModel;

namespace APS4.Vues;

public partial class PointsFidelite : ContentPage
{
    private readonly GestionApi _apiServices = new GestionApi();
    private ObservableCollection<Recompenses> resultRecompense = new ObservableCollection<Recompenses>();
    private ObservableCollection<Panier> resultPanier = new ObservableCollection<Panier>();
    private User U = Constantes.CurrentUser;

    private bool _showSeparator;

    public PointsFidelite()
	{
		InitializeComponent();
        this.nbPointsUser.Text = "Votre nombre de points : "+U.StockPointsFidelite.ToString();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.AddListRecompenses();
    }

    private async void AddListRecompenses()
    {
        this.resultRecompense = await _apiServices.GetAllAsyncByID<Recompenses>("api/mobile/getAllRecompenses", "Id", 610);
        MalisteRecompenses.ItemsSource = this.resultRecompense;
    }

    private void ProduitTapped(object sender, TappedEventArgs e)
    {

    }

    private void ChangePage_Magasin_Clicked(object sender, EventArgs e)
    {

    }

    private void ChangePage_PointFidelite_Clicked(object sender, EventArgs e)
    {

    }

    private void ChangePage_MiniJeux_Clicked(object sender, EventArgs e)
    {

    }

    private void ChangePage_Panier_Clicked(object sender, EventArgs e)
    {

    }

    private void ChangePage_Profil_Clicked(object sender, EventArgs e)
    {

    }

    private async void RecompenseTapped(object sender, TappedEventArgs e)
    {
        var label = sender as Label;
        var recompense = label.BindingContext as Recompenses;

        var pts = recompense.PointNecessaire;
        //var pts = 0;

        

        if (label.Text != null)
        {
            var ptsUser = U.StockPointsFidelite;
            ptsUser -= pts;
            if(ptsUser >= 0)
            {
                U.StockPointsFidelite = ptsUser;
                bool res = await this.U.ModifUser();
                this.nbPointsUser.Text = "Votre nombre de points : " + U.StockPointsFidelite.ToString();
                if (res)
                {
                    await DisplayAlert("Bien Joué", "Bien joué ! Vous venez d'utiliser vos points pour acheter ce produit !", "OK");
                    //await Navigation.PopAsync(); //reviens à la page précédente.
                }
                else
                {
                    await DisplayAlert("Erreur", "Erreur, la transaction n'a pas pu s'effectuer", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Erreur, la transaction n'a pas pu s'effectuer, vous n'avez pas assez de point !", "OK");
            }
        }
    }
}