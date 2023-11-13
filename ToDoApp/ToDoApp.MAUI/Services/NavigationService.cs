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
        if (name == "Login")
            Application.Current.MainPage = _serviceProvider.GetService<LoginPage>();
        else if (name=="Main")
            Application.Current.MainPage = _serviceProvider.GetService<ToDoApp.AppShell>();
        else
        {
            return parameters is null? Shell.Current.GoToAsync($"/{name}"): Shell.Current.GoToAsync($"/{name}",new ShellNavigationQueryParameters(parameters));
        }
        throw new Exception("Navigation failed!");
    }
}

