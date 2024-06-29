namespace ISP_MAUI.Views;

using ViewModels;

public partial class CalculatorView : ContentPage
{
    public CalculatorView(CalculatorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}