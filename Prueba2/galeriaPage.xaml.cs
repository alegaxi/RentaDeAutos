namespace Prueba2;

public partial class galeriaPage : ContentPage
{
	public galeriaPage()
	{
		InitializeComponent();
	}

    private void btnJetta_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 0;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnCamry_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 1;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnMustang_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 2;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnWrangler_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 3;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnAudi_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 4;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnKicks_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 5;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnChallenger_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 6;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnTahoe_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 7;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnMazda_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 8;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnBMW_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 9;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }

    private void btnCorvette_Clicked(object sender, EventArgs e)
    {
        registroPage.iNumeroCarro = 10;
        registroPage.iCond = 1;

        var pantalla = (TabbedPage)Application.Current.MainPage;
        pantalla.CurrentPage = pantalla.Children[1];
    }
}