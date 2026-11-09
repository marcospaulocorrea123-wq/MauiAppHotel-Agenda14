using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    // Coleção dinâmica de objetos da classe Suite
    List<Suite> lista_suites = new List<Suite>();

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // 1. Populando a lista com objetos Suite
        lista_suites.Add(new Suite
        {
            Descricao = "Suíte Super Luxo",
            ValorDiariaAdulto = 150.0,
            ValorDiariaCrianca = 75.0,
            CapacidadeMaxima = 4,
            Beneficios = "Café da manhã, Hidromassagem e Vista para o Mar"
        });

        lista_suites.Add(new Suite
        {
            Descricao = "Suíte Executiva",
            ValorDiariaAdulto = 100.0,
            ValorDiariaCrianca = 50.0,
            CapacidadeMaxima = 3,
            Beneficios = "Café da manhã e Wi-Fi de Alta Velocidade"
        });

        lista_suites.Add(new Suite
        {
            Descricao = "Suíte Standard",
            ValorDiariaAdulto = 60.0,
            ValorDiariaCrianca = 30.0,
            CapacidadeMaxima = 2,
            Beneficios = "Ar-condicionado e Frigobar"
        });

        // 2. Vinculando obrigatoriamente a lista ao controle Picker
        pck_quarto.ItemsSource = lista_suites;

        // 3. Inicialização e limites das datas (tratando DateTime não-nulo)
        DateTime hoje = DateTime.Now;
        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.MaximumDate = hoje.AddMonths(6);
        dtpck_checkin.Date = hoje;

        DateTime dataCheckinInicial = dtpck_checkin.Date ?? hoje;
        dtpck_checkout.MinimumDate = dataCheckinInicial.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckinInicial.AddMonths(6);
        dtpck_checkout.Date = dataCheckinInicial.AddDays(1);
    }

    // Sincronização automática das datas de check-in e check-out
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime novaDataCheckin = e.NewDate ?? DateTime.Now;
        dtpck_checkout.MinimumDate = novaDataCheckin.AddDays(1);
        dtpck_checkout.MaximumDate = novaDataCheckin.AddMonths(6);

        DateTime dataCheckoutAtual = dtpck_checkout.Date ?? novaDataCheckin;
        if (dataCheckoutAtual <= novaDataCheckin)
        {
            dtpck_checkout.Date = novaDataCheckin.AddDays(1);
        }
    }

    // Botão Avançar: validações e instanciação do objeto Hospedagem
    private async void BtnAvancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Suite? suiteSelecionada = pck_quarto.SelectedItem as Suite;

            if (suiteSelecionada == null)
            {
                await DisplayAlert("Atenção", "Por favor, selecione uma acomodação.", "OK");
                return;
            }

            int adultos = Convert.ToInt32(stp_adultos.Value);
            int criancas = Convert.ToInt32(stp_criancas.Value);
            int total = adultos + criancas;

            if (total > suiteSelecionada.CapacidadeMaxima)
            {
                await DisplayAlert("Capacidade Excedida",
                    $"A acomodação '{suiteSelecionada.Descricao}' suporta no máximo {suiteSelecionada.CapacidadeMaxima} pessoas.", "OK");
                return;
            }

            DateTime dataCheckin = dtpck_checkin.Date ?? DateTime.Now;
            DateTime dataCheckout = dtpck_checkout.Date ?? dataCheckin.AddDays(1);

            if (dataCheckout <= dataCheckin)
            {
                await DisplayAlert("Período Inválido",
                    "A data de check-out deve ser posterior ao check-in.", "OK");
                return;
            }

            // Instancia o objeto Hospedagem agregando a Suite escolhida (POO)
            Hospedagem hospedagem = new Hospedagem
            {
                QuartoSelecionado = suiteSelecionada,
                QntAdultos = adultos,
                QntCriancas = criancas,
                DataCheckin = dataCheckin,
                DataCheckout = dataCheckout
            };

            // Envia o objeto para a tela de resumo via BindingContext
            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = hospedagem
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    // Navegação para a nova tela Sobre
    private async void BtnSobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}