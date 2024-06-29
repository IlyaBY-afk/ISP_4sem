using ISP_MAUI.ViewModels;

namespace ISP_MAUI.Views;

public partial class Currency
{
    private readonly CurrencyViewModel _viewModel;
    
    public Currency(CurrencyViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetRates();
    }
}