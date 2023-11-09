namespace ToDoApp.ViewModels;

public abstract partial class BaseViewModel : ObservableObject, INavigationAware
{
    [ObservableProperty]
    bool isBusy = false;

    [ObservableProperty]
    string title = string.Empty;

    public virtual async Task OnNavigatedFrom(IDictionary<string, object> parameters)
    {   
    }

    public virtual async  Task OnNavigatedTo(IDictionary<string, object> parameters)
    {
    }
}
