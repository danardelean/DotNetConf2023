namespace ToDoApp.Services;

public interface INavigationAware
{
    Task OnNavigatedTo(IDictionary<string, object> parameters);
    Task OnNavigatedFrom(IDictionary<string, object> parameters);
}

