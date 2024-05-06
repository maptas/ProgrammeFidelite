using APS4.Modeles;

namespace APS4.Vues;

public partial class AccueilAdminVue : ContentPage
{
	public AccueilAdminVue()
	{
		InitializeComponent();
	}

    private async void BlasonButton_Clicked(object sender, EventArgs e)
    {
        var nomBlason = NomBlason.Text;
        var montant = 0.0;
        if (MontantAtteindre.Text != null)
            { montant = double.Parse(MontantAtteindre.Text); }

        Blason B = new Blason(nomBlason, montant);

        //bool existe = await B.GetBlason();
        bool existe = false;
        if (existe)
        {
            await DisplayAlert("Erreur", "Le blason existe déjà.", "OK");
        }
        else
        {
            bool res = await B.AddBlason();

            if (res)
            {
                await Navigation.PushAsync(new AccueilAdminVue());
            }
            else
            {
                await DisplayAlert("Erreur", "Problème lors de la création du blason.", "OK");
            }
        }
    }

    private async void ProduitButton_Clicked(object sender, EventArgs e)
    {
        var nomProduit = NomProduit.Text;
        var prix = 0.0;
        var ptFidelite = 0;
        var categorieId = 0;
        if (PrixProduit.Text != null)
            { prix = float.Parse(PrixProduit.Text); }
        if (PointFidelite.Text != null)
            { ptFidelite = int.Parse(PointFidelite.Text); }
        if (CategorieIdProduit.Text != null)
            { categorieId = int.Parse(CategorieIdProduit.Text); }

        Produits P = new Produits(nomProduit, prix, ptFidelite, categorieId);

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

    private async void RecompenseButton_Clicked(object sender, EventArgs e)
    {
        var nomRecompense = NomRecompenseEntry.Text;
        var ptsNecessaire = 0;
        var produitId = 0;
        if(PointsNecessaireEntry.Text != null)
            {ptsNecessaire = int.Parse(PointsNecessaireEntry.Text);}
        if(ProduitIdEntry.Text != null)
            {produitId = int.Parse(ProduitIdEntry.Text);}

        Recompense R = new Recompense(nomRecompense, ptsNecessaire, produitId);

        bool res = await R.AddRecompense();

        if (res)
        {
            await Navigation.PushAsync(new AccueilAdminVue());
        }
        else
        {
            await DisplayAlert("Erreur", "Problème lors de la création de la récompense.", "OK");
        }
    }

    private async void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); //reviens à la page précédente.
    }

    private async void CategorieButton_Clicked(object sender, EventArgs e)
    {
        var nomCategorie = NomCategorieEntry.Text;
        var urlImageCategorie = UrlImageEntry.Text;

        Categorie C = new Categorie(nomCategorie, urlImageCategorie);

        bool res = await C.AddCategorie();

        if (res)
        {
            await Navigation.PushAsync(new AccueilAdminVue());
        }
        else
        {
            await DisplayAlert("Erreur", "Problème lors de la création de la catégorie.", "OK");
        }
    }

    private async void PalierButton_Clicked(object sender, EventArgs e)
    {
        var nomPalier = NomPalierEntry.Text;
        var palierBas = 0;
        var palierHaut = 0;
        if (PalierBasEntry.Text != null)
        { palierBas = int.Parse(PalierBasEntry.Text); }
        if (PalierBasEntry.Text != null)
            { palierBas = int.Parse(PalierHautEntry.Text); }

        Palier P = new Palier(nomPalier, palierBas, palierHaut);

        bool res = await P.AddPalier();

        if (res)
        {
            await Navigation.PushAsync(new AccueilAdminVue());
        }
        else
        {
            await DisplayAlert("Erreur", "Problème lors de la création du palier.", "OK");
        }
    }
}