using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PCAssembly
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
                })               
                .Configuration.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "MauiSplashScreen", "Resources/Images/splashscreen.png" }
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
