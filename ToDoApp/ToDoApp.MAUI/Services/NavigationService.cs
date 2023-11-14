using ToDoApp.Services;
using ToDoApp.Views;

namespace ToDoApp.MAUI.Services;

public class NavigationService : INavigationService
{
    IServiceProvider _serviceProvider;
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }

    public Task NavigateAsync(string name)
    {
        return NavigateAsync(name, null);
    }

    public Task NavigateAsync(string name, IDictionary<string, object> parameters)
    {
        switch(name)
        {
            case "Login":
                Application.Current.MainPage = _serviceProvider.GetService<LoginPage>();
                return Task.CompletedTask;
            case "Main":
                Application.Current.MainPage = _serviceProvider.GetService<ToDoApp.AppShell>();
                return Task.CompletedTask;
            default:
                return parameters is null ? Shell.Current.GoToAsync($"/{name}") : Shell.Current.GoToAsync($"/{name}", new ShellNavigationQueryParameters(parameters));
        };
    }
}

