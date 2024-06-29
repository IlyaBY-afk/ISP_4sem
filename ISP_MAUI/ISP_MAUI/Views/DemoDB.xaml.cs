using ISP_MAUI.ViewModels;
using ISP_MAUI.Entities;
using System.Collections.ObjectModel;

namespace ISP_MAUI.Views;

public partial class DemoDb
{
    private readonly DemoDBViewModel _viewModel;

    public DemoDb(DemoDBViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetCocktails();
    }
    
    private async void OnSelectedCocktail(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Cocktail selectedItem = (Cocktail)picker.SelectedItem;
        
        _viewModel.Ingredients = new ObservableCollection<Ingredient>(
            await _viewModel.Service.GetCocktailIngredients(selectedItem.Id)
            );
    }
}