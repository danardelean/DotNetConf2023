using ToDoApp.Services;
using Windows.System;

namespace ToDoApp_Uno.Services;

public class PlatformService : IPlatformService
{

    public async Task<bool> OpenBrowserAsync(string Uri)
    {
        var result=await Launcher.LaunchUriAsync(new Uri(Uri));
        return result;
    }
}

