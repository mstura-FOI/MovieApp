
using Microsoft.Extensions.Logging;
using MovieDB;

namespace MovieApp {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("QwitcherGrypen-Bold.ttf", "QwitchBold");
                    fonts.AddFont("QwitcherGrypen-Regular.ttf", "QwitchRegular");
                });
            builder.Services.AddSingleton<DBService>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
