using APS4.Modeles;
using System.Collections.ObjectModel;

namespace APS4.Vues;

public partial class MiniJeuxVue : ContentPage
{
    private ObservableCollection<Carte> jeu = new ObservableCollection<Carte>();
    private ObservableCollection<Carte> jeuDeSortie;
    private Carte carte = new Carte();
	public MiniJeuxVue()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        this.carte.AddCollection(this.jeu);
        this.carte.Melanger(this.jeu);
        this.jeuDeSortie = this.carte.Sortir(jeu);

        maListeCartes.ItemsSource = this.jeuDeSortie;
    }

    private async void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); //reviens à la page précédente.
        //await Navigation.PushAsync(new AccueilVue());
    }
}