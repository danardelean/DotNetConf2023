using ToDoApp.Services;
namespace ToDoApp.MAUI.Services;

public class PlatformService : IPlatformService
{
    public Task<bool> OpenBrowserAsync(string Uri)
    {
        return Browser.OpenAsync(Uri);
    }
}

