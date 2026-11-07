namespace MauiAppHotel.Views;

public class Sobre : ContentPage
{
    public Sobre()
    {
        Title = "Sobre o Aplicativo";
        BackgroundColor = Color.FromArgb("#F4F6F9");

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Spacing = 16,
                Padding = new Thickness(20),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                MaximumWidthRequest = 420,

                Children =
                {
                    // ========================================================
                    // 1. CAMPO INDEPENDENTE 1: APENAS A IMAGEM / BANNER (ACIMA)
                    // ========================================================
                    new Border
                    {
                        Stroke = Color.FromArgb("#D1D5DB"),
                        StrokeThickness = 1,
                        StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 14 },
                        BackgroundColor = Colors.White,
                        HeightRequest = 100,
                        Padding = 3,
                        Content = new Image
                        {
                            Source = "dotnet_bot.png", // Imagem nativa do .NET MAUI
                            HeightRequest = 800,
                            WidthRequest = 200,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center
                        }
                    },

                    // ========================================================
                    // 2. CAMPO INDEPENDENTE 2: APENAS O TÍTULO (ABAIXO DA IMAGEM)
                    // ========================================================
                    new Border
                    {
                        Stroke = Color.FromArgb("goldenrod"),
                        StrokeThickness = 1,
                        StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 14 },
                        BackgroundColor = Color.FromArgb("#1E3A8A"), // Fundo azul marinho
                        Padding = new Thickness(16, 14),
                        Content = new VerticalStackLayout
                        {
                            Spacing = 4,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Children =
                            {
                                new Label
                                {
                                    Text = "App Hotel",
                                    FontSize = 20,
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Colors.White,
                                    HorizontalTextAlignment = TextAlignment.Center
                                },
                                new Label
                                {
                                    Text = "Sistema de Gestão de Hospedagem",
                                    FontSize = 13,
                                    TextColor = Color.FromArgb("#DBEAFE"),
                                    HorizontalTextAlignment = TextAlignment.Center
                                }
                            }
                        }
                    },

                    // ========================================================
                    // 3. CAMPO INDEPENDENTE 3: DADOS DO DESENVOLVEDOR (AGENDA 13)
                    // ========================================================
                    new Border
                    {
                        Stroke = Color.FromArgb("#D1D5DB"),
                        StrokeThickness = 1,
                        StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 14 },
                        BackgroundColor = Colors.White,
                        Padding = 20,
                        Content = new VerticalStackLayout
                        {
                            Spacing = 12,
                            Children =
                            {
                                new Label
                                {
                                    Text = "Informações do Projeto",
                                    FontSize = 18,
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Color.FromArgb("#111827")
                                },
                                new BoxView
                                {
                                    HeightRequest = 1,
                                    Color = Color.FromArgb("#E5E7EB"),
                                    Margin = new Thickness(0, 2)
                                },

                                new Label
                                {
                                    Text = "Desenvolvedor:",
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Color.FromArgb("#374151")
                                },
                                new Label
                                {
                                    Text = "Marcos Paulo Correa",
                                    FontSize = 16,
                                    TextColor = Color.FromArgb("#1F2937")
                                },

                                new Label
                                {
                                    Text = "Ano de Desenvolvimento:",
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Color.FromArgb("#374151")
                                },
                                new Label
                                {
                                    Text = "2026",
                                    FontSize = 16,
                                    TextColor = Color.FromArgb("#1F2937")
                                },

                                new Label
                                {
                                    Text = "Componente Curricular:",
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Color.FromArgb("#374151")
                                },
                                new Label
                                {
                                    Text = "Desenvolvimento de Sistemas - Agenda 13",
                                    FontSize = 14,
                                    TextColor = Color.FromArgb("#4B5563")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}