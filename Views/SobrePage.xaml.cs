namespace MauiAppHotel.Views;

public partial class SobrePage : ContentPage
{
    public SobrePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Fecha a tela Sobre e volta para a tela anterior
        await Navigation.PopAsync();
    }
}