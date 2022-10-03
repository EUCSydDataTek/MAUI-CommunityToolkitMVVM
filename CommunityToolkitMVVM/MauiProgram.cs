using CommunityToolkitMVVM.ViewModels;
using CommunityToolkitMVVM.Views;

namespace CommunityToolkitMVVM;

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

		builder.Services.AddTransient(typeof(ObservablePropertyVM));
        builder.Services.AddTransient(typeof(ObservablePropertyPage));

        return builder.Build();
	}
}
