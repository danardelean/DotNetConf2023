namespace ToDoApp.Services;

public interface INavigationService
{
    Task GoBackAsync();
    Task NavigateAsync(string name);
    Task NavigateAsync(string name, IDictionary<string,object> parameters);
}

