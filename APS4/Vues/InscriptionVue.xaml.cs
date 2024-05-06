using APS4.Modeles;

namespace APS4.Vues;

public partial class InscriptionVue : ContentPage
{
	public InscriptionVue()
	{
		InitializeComponent();
	}

    private async void UserButton_Clicked(object sender, EventArgs e)
    {
		var nom = NomEntry.Text;
		var prenom = PrenomEntry.Text;
		var email = EmailEntry.Text;
		var mdp = MdpEntry.Text;
		var tel = TelephoneEntry.Text;
		var dateNaissanceText = DateNaissanceEntry.Text;
		DateTime dateNaissance = DateTime.Now;


        if (dateNaissanceText != null)
		{
            dateNaissance = DateTime.Parse(dateNaissanceText);
        }
		

		User U1 = new User(email, mdp);
		U1.Nom = nom;
		U1.Prenom = prenom;
		U1.Telephone = tel;
		U1.DateNaissance = dateNaissance;
		U1.StockPointsFidelite = 0;
        bool res = await U1.AddUserRegistration();

		if (res)
		{
            await Navigation.PushAsync(new AccueilVue());
        }
		else
		{
            await DisplayAlert("Erreur", "Informations incomplètent, veuillez les renseigner pour continuer.", "OK");
        }

    }

    private async void RetourButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ConnexionVue());
    }
}