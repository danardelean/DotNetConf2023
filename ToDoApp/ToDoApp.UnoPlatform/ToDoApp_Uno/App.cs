using ToDoApp;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp_Uno.Services;

namespace ToDoApp_Uno
{
    public class App : Application
    {
        protected Window? MainWindow { get; private set; }
        public IHost? Host { get; private set; }


        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var builder = this.CreateBuilder(args)
                .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                    .ConfigureServices((context, services) =>
                    {
                        services.AddSingleton<IPlatformService, PlatformService>();
                        services.AddSingleton<INavigationService, NavigationService>();
                        services.AddSingleton<IDataStore<Item>, MockDataStore>();
                        services.AddSingleton<IIdService, MockIdService>();
                        services.AddSingleton<ToDoApplication>();
                    })
                    .UseNavigation(RegisterRoutes)
                    .UseToolkitNavigation()
                );
            MainWindow = builder.Window;

#if DEBUG
            //  MainWindow.EnableHotReload();
#endif

            Host = await builder.NavigateAsync<Shell>();
        }

        private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
        {
            views.Register(
                new ViewMap(ViewModel: typeof(ShellViewModel)),
                new ViewMap<MainPage, MainViewModel>(),
                new ViewMap<LoginPage, LoginViewModel>(),
                new ViewMap<ItemsPage, ItemsViewModel>(),
                new ViewMap<AboutPage, AboutViewModel>(),
                new DataViewMap<ItemDetailsPage, ItemDetailViewModel,IDictionary<string,object>>()
            );

            routes.Register(
                new RouteMap("", View: views.FindByViewModel<ShellViewModel>(),
                    Nested: new RouteMap[]
                    {
                        new RouteMap("Login", View: views.FindByViewModel<LoginViewModel>()),
                        new RouteMap("Main", View: views.FindByViewModel<MainViewModel>()),
                        new RouteMap("ItemDetails", View: views.FindByViewModel<ItemDetailViewModel>()),
                    }
                )
            );
        }
    }
}