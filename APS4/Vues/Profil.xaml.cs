using APS4.Modeles;

namespace APS4.Vues;

public partial class Profil : ContentPage
{
	private User U = Constantes.CurrentUser;
    public Profil()
	{
		InitializeComponent();

		
		NomEntry.Placeholder = U.Nom;
		PrenomEntry.Placeholder = U.Prenom;
		TelEntry.Placeholder = U.Telephone;
		EmailEntry.Placeholder = U.Email;
		DateNaissanceEntry.Placeholder = U.DateNaissance.ToString("dd/mm/yyyy");
        NbPointsEntry.Placeholder = U.StockPointsFidelite.ToString();

    }

    private async void ModifUserButton_Clicked(object sender, EventArgs e)
    {
		U.Nom = NomEntry.Text;
        U.Prenom = PrenomEntry.Text;
        U.Telephone = TelEntry.Text;
		U.Email = EmailEntry.Text;
        

        var date = DateNaissanceEntry.Text;
        var stockPts = NbPointsEntry.Text;

        if (date != null)
        {
            U.DateNaissance = DateTime.Parse(date);
        }
        if(stockPts != null)
        {
            U.StockPointsFidelite = int.Parse(stockPts);
        }

        bool res = await U.ModifUser();

        if (res)
        {
            await Navigation.PushAsync(new AccueilVue());
        }
        else
        {
            await DisplayAlert("Erreur", "Erreur.", "OK");
        }
    }

    private async void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccueilVue());
    }

    private async void EchangePointsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync (new EchangePointsVue());
    }
}