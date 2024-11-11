using BackswingMobileApp.Services;
using Microsoft.Extensions.Logging;

namespace BackswingMobileApp
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
                });

            //builder.Services.AddTransient<MainPage>();
            //builder.Services.AddSingleton<DatabaseHelper>();
            builder.Services.AddSingleton<SessionService>();

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            //register the leaderboard service
            builder.Services.AddSingleton<LeaderboardService>();

            // Register the CourseService
            builder.Services.AddSingleton<CourseService>();

            return builder.Build();
        }
    }
}
