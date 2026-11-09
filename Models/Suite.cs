namespace MauiAppHotel.Models;

public class Suite
{
    // Propriedades auto-implementadas
    public string Descricao { get; set; }
    public double ValorDiariaAdulto { get; set; }
    public double ValorDiariaCrianca { get; set; }

    // Campos extras de personalizacao para a Agenda 14
    public int CapacidadeMaxima { get; set; }
    public string Beneficios { get; set; }
}
