namespace ToDoApp.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    IPlatformService _platformService;
    public AboutViewModel(IPlatformService platformService)
    {
        Title = "About";
        _platformService = platformService ?? throw new NullReferenceException("Platform service is null");
    }

    [RelayCommand(AllowConcurrentExecutions =false)]
    Task OpenWebAsync()
    {
        return _platformService.OpenBrowserAsync("https://aka.ms/xamarin-quickstart");
    }
}