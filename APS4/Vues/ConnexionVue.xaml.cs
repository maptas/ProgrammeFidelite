using APS4.Modeles;
using APS4.Apis;
using Microsoft.Maui.Controls;
using System;
/*using CommunityToolkit.Maui.Views;*/


namespace APS4.Vues;


public partial class ConnexionVue : ContentPage
{
	public ConnexionVue()
	{
		InitializeComponent();
	}

    private async void UserButton_Clicked(object sender, EventArgs e)
    {
		var email = EmailEntry.Text;
		var password = MdpEntry.Text;

		//User U1 = new User(email, password);
        User U1 = new User("mpochot@gmail.com", "Btssio2017");
        //User U1 = new User("mpochotAdmin@gmail.com", "Btssio2017");
        bool res = await U1.GetUserRegistration();

        if (res)
        {
            // La requ�te API est la m�me dans les deux cas, donc on la d�place hors du if
            // var result = await _apiServices.GetAllAsyncByID<User>("api/mobile/GetAllUsers", "Id", U1.Id);

            if (U1.Email == "mpochotAdmin@gmail.com")
            {
                await Navigation.PushAsync(new AccueilAdminVue());
            }
            else
            {
                // Redirection vers la page Accueil
                await Navigation.PushAsync(new AccueilVue());
            }
        }
        else
        {
            // G�rer le cas o� GetUserRegistration retourne false (si n�cessaire)
            // Exemple : Afficher un message d'erreur
            await DisplayAlert("Erreur", "Email ou mot de passe invalide.", "OK");
        }
    }

    private void UserPasswordButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void CreateUserButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InscriptionVue());
    }
}