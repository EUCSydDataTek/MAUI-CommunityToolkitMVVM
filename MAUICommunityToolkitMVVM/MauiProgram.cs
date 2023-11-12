using MAUICommunityToolkitMVVM.ViewModels;
using MAUICommunityToolkitMVVM.Views;
using Microsoft.Extensions.Logging;

namespace MAUICommunityToolkitMVVM;
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton(typeof(MainPageViewModel));
        builder.Services.AddSingleton(typeof(MainPage));

        return builder.Build();
    }
}
