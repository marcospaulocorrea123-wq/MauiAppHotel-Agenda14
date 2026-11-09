namespace MauiAppHotel.Models;

public class Hospedagem
{
    // Associacao com a Suite selecionada
    public Suite QuartoSelecionado { get; set; }

    // Contadores de hospedes
    public int QntAdultos { get; set; }
    public int QntCriancas { get; set; }

    // Periodo selecionado
    public DateTime DataCheckin { get; set; }
    public DateTime DataCheckout { get; set; }

    // Propriedade calculada: retorna a quantidade de dias
    public int Estadia
    {
        get
        {
            int dias = (DataCheckout - DataCheckin).Days;
            return dias > 0 ? dias : 1; // Garante no minimo 1 diaria
        }
    }

    // Propriedade calculada: formula financeira encapsulada
    public double ValorTotal
    {
        get
        {
            if (QuartoSelecionado == null) return 0;

            double subtotalAdultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
            double subtotalCriancas = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;

            return (subtotalAdultos + subtotalCriancas) * Estadia;
        }
    }
}
