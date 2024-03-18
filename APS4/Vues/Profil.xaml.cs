using APS4.Modeles;

namespace APS4.Vues;

public partial class Profil : ContentPage
{
	public Profil()
	{
		InitializeComponent();

		User U = Constantes.CurrentUser;
	}
}