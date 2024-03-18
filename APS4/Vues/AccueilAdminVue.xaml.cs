using APS4.Modeles;

namespace APS4.Vues;

public partial class AccueilAdminVue : ContentPage
{
	public AccueilAdminVue()
	{
		InitializeComponent();
	}

    private void BlasonButton_Clicked(object sender, EventArgs e)
    {
        var nomBlason = NomBlason.Text;
        var montant = float.Parse(MontantAtteindre.Text);

        Blason B = new Blason(nomBlason, montant);
    }

    private async void ProduitButton_Clicked(object sender, EventArgs e)
    {
        var nomProduit = NomProduit.Text;
        var prix = float.Parse(PrixProduit.Text);
        var ptFidelite = int.Parse(PointFidelite.Text);

        Produits P = new Produits(nomProduit, prix, ptFidelite);

        bool existe = await P.GetProduit();
        if(existe)
        {
            await DisplayAlert("Erreur", "Le produit existe déjà.", "OK");
        }
        else
        {
            bool res = await P.AddProduit();

            if (res)
            {
                await Navigation.PushAsync(new AccueilAdminVue());
            }
            else
            {
                await DisplayAlert("Erreur", "Problème lors de la création du produit.", "OK");
            }
        }
    }
}