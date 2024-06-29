using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISP_MAUI.Entities;
using ISP_MAUI.Services;

namespace ISP_MAUI.ViewModels;

public partial class CurrencyViewModel : BaseViewModel
{
    [ObservableProperty] private RateService? _service = new();
    [ObservableProperty] private ObservableCollection<Rate>? _rates = new();
    [ObservableProperty] private DateTime _selectedDate = DateTime.Today;
    
    [RelayCommand]
    public async Task GetRates()
    {
        IsBusy = true;
        
        IEnumerable<Rate> res = await Service!.GetRates(SelectedDate);
        Rates?.Clear();
        foreach (Rate r in res)
        {
            Rates?.Add(r);
        }
        
        IsBusy = false;
    }
}