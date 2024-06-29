using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ISP_MAUI.ViewModels;

public partial class ProgressBarViewModel : BaseViewModel
{
    private readonly double _step = 0.001;
    private readonly double _a = 0;
    private readonly double _b = 1;

    private delegate double Func(double x);
    private readonly Func _f = Double.Sin;

    [ObservableProperty] private double _progressValue;
    [ObservableProperty] private double _percentage;
    [ObservableProperty] private string _result = "Welcome to .NET MAUI!";

    private readonly ProgressBar _progressBar = new();

    private CancellationTokenSource? _cts;
    private CancellationToken _token;

    [RelayCommand]
    private async Task Integrate()
    {
        _cts = new CancellationTokenSource();
        _token = _cts.Token;
        
        Result = "Calculating...";
        double result = 0;
        
        for (double i = _a; i <= _b; i += _step)
        {
            if (_token.IsCancellationRequested)
                return;
            
            result += _f(i) * _step;
            
            ProgressValue = (i - _a) / (_b - _a);
            Percentage = ProgressValue * 100;
            await _progressBar.ProgressTo(ProgressValue, 0, Easing.Default);
        }
        Result = Convert.ToString(result, CultureInfo.InvariantCulture);
    }

    [RelayCommand]
    private void Cancel()
    {
        _cts?.Cancel();
        Result = "Canceled";
    }
}