namespace ToDoApp.Services;

public interface IPlatformService
{
	Task<bool> OpenBrowserAsync(string Uri);
}

