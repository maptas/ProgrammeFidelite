using APS4.Apis;
using APS4.Modeles;
using APS4.Vues;

namespace APS4.Vues;

public partial class EchangePointsVue : ContentPage
{
    private readonly GestionApi _apiServices = new GestionApi();
    private User U = Constantes.CurrentUser;
    public EchangePointsVue()
	{
		InitializeComponent();
	}

    private async void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccueilVue());
    }

    private async void DonnerPointsButton_Clicked(object sender, EventArgs e)
    {
        var email = mailEntry.Text;
        User uTmp = new User(email);
        var nbPts = 0;
        if(nbPointEntry != null)
        {
            nbPts = int.Parse(nbPointEntry.Text);
        }
        User UserQuiRecoit = await _apiServices.GetOneAsync<User>("api/mobile/GetFindUserByEmail", uTmp);
        var ptsRestant = U.StockPointsFidelite - nbPts;

        if (U.StockPointsFidelite <  nbPts)
        {
            await DisplayAlert("Erreur", "Erreur, vous ne disposer pas assez de points pour réaliser cette action.", "OK");
        }
        else if(nbPts > 0)
        {
            var response = await DisplayAlert("Validation", "Voulez-vous vraiment envoyer " 
                + nbPts + " points à votre ami(e) " 
                + UserQuiRecoit.Prenom + " " 
                + UserQuiRecoit.Nom + " ?\n" 
                + "Il vous restera ensuite " 
                + ptsRestant 
                + " points.", "Oui", "Non");

            if (response)
            {
                UserQuiRecoit.StockPointsFidelite += nbPts;
                await _apiServices.GetOneAsync<User>("api/mobile/updateUser", UserQuiRecoit);

                U.StockPointsFidelite -= nbPts;
                await _apiServices.GetOneAsync<User>("api/mobile/updateUser", U);

                await DisplayAlert("Confirmation", "Echange effectué !", "OK");
            }
        }        
    }
}