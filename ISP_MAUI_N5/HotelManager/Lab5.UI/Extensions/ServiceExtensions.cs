using Lab5.UI.Pages.TaskPages;
using Lab5.UI.ViewModels;
using Lab5.UI;

namespace Lab5.UI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddSingleton<ViewCategory>()
                .AddTransient<ViewRoom>()
                .AddTransient<AddOrEditCategory>()
                .AddTransient<AddOrEditRoom>();

            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<ViewCategoryViewModel>()
                .AddTransient<ViewRoomViewModel>()
                .AddTransient<AddOrEditCategoryViewModel>()
                .AddTransient<AddOrEditRoomViewModel>();
            return services;
        }
    }
}
