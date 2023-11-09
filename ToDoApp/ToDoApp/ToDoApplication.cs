namespace ToDoApp;

public class ToDoApplication
{
    IIdService _idService;
    INavigationService _navigationService;


    public ToDoApplication(IIdService idService, INavigationService navigationService)
    {
        _idService = idService ?? throw new NullReferenceException("IdService service is null");
        _navigationService = navigationService ?? throw new NullReferenceException("NavigationService service is null");
    }


    public async Task OnStart()
    {
        if (_idService.IsUserLoggedIn)
            await _navigationService.NavigateAsync("Main");
        else
            await _navigationService.NavigateAsync("Login");
    }
    public async Task OnSleep()
    {
    }
    public async Task OnResume()
    {
    }
}

