using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Lab5.Persistence;
using Lab5.Persistence.Data;
using Lab5.UI.Extensions;
using Persistence;


namespace Lab5.UI
{
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
            var connStr = "Data Source = {0}sqlite.db";
            var dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = string.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connStr).Options;

            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
