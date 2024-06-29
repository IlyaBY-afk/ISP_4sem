using ISP_MAUI.ViewModels;
using ISP_MAUI.Views;
using Microsoft.Extensions.Logging;
using ProgressBar = ISP_MAUI.Views.ProgressBar;
using ISP_MAUI.Services;
using CommunityToolkit.Maui;
using ISP_MAUI.Interfaces;

namespace ISP_MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Logging.AddDebug();
        
        builder.Services.AddSingleton<IDbService, SQLiteService>();
        builder.Services.AddSingleton<IRateService, RateService>();
        
        builder.Services.AddTransient<CalculatorViewModel>();
        builder.Services.AddTransient<CalculatorView>();
        
        builder.Services.AddTransient<ProgressBarViewModel>();
        builder.Services.AddTransient<ProgressBar>();
        
        builder.Services.AddTransient<DemoDBViewModel>();
        builder.Services.AddTransient<DemoDb>();

        builder.Services.AddTransient<CurrencyViewModel>();
        builder.Services.AddTransient<Currency>();

        return builder.Build();
    }
}