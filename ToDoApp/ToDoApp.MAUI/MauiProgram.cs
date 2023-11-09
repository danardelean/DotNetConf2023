using Microsoft.Extensions.Logging;
using ToDoApp.MAUI.Services;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.Views;

namespace ToDoApp.MAUI;

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
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
			});

		builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<ItemDetailPage>();
        builder.Services.AddTransient<ItemsPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<NewItemPage>();

		builder.Services.AddTransient<AboutViewModel>();
        builder.Services.AddTransient<ItemDetailViewModel>();
        builder.Services.AddTransient<ItemsViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<NewItemViewModel>();
        builder.Services.AddSingleton<ToDoApplication>();


        builder.Services.AddSingleton<IPlatformService,PlatformService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDataStore<Item>, MockDataStore>();
        builder.Services.AddSingleton<IIdService, MockIdService>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

