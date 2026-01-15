using ImcCalculator.ViewModels;

namespace ImcCalculator.Views;

public partial class ImcView : ContentPage
{
	public ImcView()
	{
		InitializeComponent();
		BindingContext = new IMCViewModel();
    }
}