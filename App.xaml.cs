using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Inicia a aplicação utilizando o AppShell para gerenciar a navegação e o menu de páginas:
            var window = new Window(new AppShell());

            // Configuração das dimensões da janela no Windows (estilo smartphone vertical):
            window.Width = 480;
            window.Height = 720;

            // Limites mínimos de redimensionamento:
            window.MinimumWidth = 400;
            window.MinimumHeight = 600;

            return window;
        }
    }
}