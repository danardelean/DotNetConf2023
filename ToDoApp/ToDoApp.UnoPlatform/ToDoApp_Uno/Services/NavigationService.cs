
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp_Uno.Services;

public class NavigationService : INavigationService
{
    public INavigator Navigator { get; set; }
    public NavigationService()
    {
      
    }
    public async Task GoBackAsync()
    {
        await Navigator.GoBack(this);
    }

    public Task NavigateAsync(string name)
    {
        return Navigator.NavigateRouteAsync(this, $"{name}");
    }

    public async Task NavigateAsync(string name, IDictionary<string, object> parameters)
    {
        await Navigator.NavigateRouteAsync(this, name,data:parameters);
    }
}

