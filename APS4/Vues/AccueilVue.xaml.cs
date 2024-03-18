using Microsoft.Maui.Controls;
using APS4.Modeles;
using APS4.Apis;
using System.Collections.ObjectModel;

namespace APS4.Vues;

public partial class AccueilVue : ContentPage
{
    private readonly GestionApi _apiServices = new GestionApi();
    private ObservableCollection<Produits> result = new ObservableCollection<Produits>();
    public AccueilVue()
	{
		InitializeComponent();

        User user = Constantes.CurrentUser;

        this.AddListProduits();

        MalisteProduits.ItemsSource = this.result;
    }
    private async void AddListProduits()
    {
        this.result = await _apiServices.GetAllAsyncByID<Produits>("api/mobile/GetAllProduits", "Id", Constantes.CurrentUser.Id);
        MalisteProduits.ItemsSource = this.result;
    }
}