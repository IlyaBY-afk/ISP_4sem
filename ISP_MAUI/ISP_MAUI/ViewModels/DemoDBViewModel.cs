using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISP_MAUI.Entities;
using ISP_MAUI.Services;

namespace ISP_MAUI.ViewModels;

public partial class DemoDBViewModel : BaseViewModel
{
    [ObservableProperty] private ObservableCollection<Cocktail>? _cocktails;
    [ObservableProperty] private ObservableCollection<Ingredient>? _ingredients;
    [ObservableProperty] private Cocktail? _selectedCocktail;
    [ObservableProperty] private SQLiteService _service;

    public DemoDBViewModel()
    {
        _service = new SQLiteService(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ispdb.db3")
        );
        _service.Init();
    }

    [RelayCommand]
    public async Task GetCocktails()
    {
        IsBusy = true;
        Cocktails = new ObservableCollection<Cocktail>(await Service.GetAllCocktails());
        IsBusy = false;
    }
}