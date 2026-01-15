using ImcCalculator.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ImcCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new ImcView());
        }
    }
}