namespace ToDoApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    string _userName;

    [ObservableProperty]
    string _password;

    IIdService _idService;
    INavigationService _navigationService;

    public LoginViewModel(IIdService idService,INavigationService navigationService)
    {
        _idService = idService ?? throw new NullReferenceException("IdService service is null");
        _navigationService = navigationService ?? throw new NullReferenceException("NavigationService service is null");
    }

    [RelayCommand]
    private async void OnLogin()
    {
        IsBusy = true;
        if (await _idService.LoginAsync(_userName, _password))
            await _navigationService.NavigateAsync("Main");
        IsBusy = false;
    }

    public override Task OnNavigatedTo(IDictionary<string, object> parameters)
    {
        return base.OnNavigatedTo(parameters);
    }
}
