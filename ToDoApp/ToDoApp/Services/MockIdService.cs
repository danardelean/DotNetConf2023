namespace ToDoApp.Services;

public class MockIdService : IIdService
{
    public bool IsUserLoggedIn { get; private set; } = false ;

    public Task<bool> LoginAsync(string username, string password)
    {
        IsUserLoggedIn = true;
        return Task.FromResult(true);
    }
}

