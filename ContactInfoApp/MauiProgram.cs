using ContactInfoApp.Services;
using ContactInfoApp.ViewModels;
using ContactInfoApp.Views;
using Microsoft.Extensions.Logging;

namespace ContactInfoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<UsersListViewModel>();
            builder.Services.AddTransient<UserDetailsViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<UserDetailsPage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
