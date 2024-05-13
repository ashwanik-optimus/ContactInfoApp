using ContactInfoApp.Services;
using ContactInfoApp.ViewModels;
using ContactInfoApp.Views;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Biometric;

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

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db2");
            builder.Services.AddSingleton<IUserService>(s => ActivatorUtilities.CreateInstance<UserService>(s, dbPath));

            builder.Services.AddSingleton<IBiometric>(BiometricAuthenticationService.Default);

            builder.Services.AddSingleton<UsersListViewModel>();
            builder.Services.AddSingleton<UserDetailsViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<UserDetailsPage>();
            builder.Services.AddTransient<AddEditViewModel>();
            builder.Services.AddTransient<AddEditUserDetailsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
