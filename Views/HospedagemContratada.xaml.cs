namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        // Retorna para a tela de contratação para fazer uma nova simulação
        await Navigation.PopAsync();
    }
}