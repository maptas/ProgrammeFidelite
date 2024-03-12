using APS4.Modeles;
using APS4.Apis;
using Microsoft.Maui.Controls;
using System;

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
		var mdp = MdpEntry.Text;

		User U1 = new User(1, email, mdp);
		bool res = await U1.GetUserRegistration();

        if (res)
        {
            // La requ�te API est la m�me dans les deux cas, donc on la d�place hors du if
            // var result = await _apiServices.GetAllAsyncByID<User>("api/mobile/GetAllUsers", "Id", U1.Id);

            if (U1.Email == "le gall" && U1.Mdp == "thierry")
            {
                await Navigation.PushAsync(new ConnexionVue());
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
        }
    }
}