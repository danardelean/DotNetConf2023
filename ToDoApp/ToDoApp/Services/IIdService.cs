using System;
namespace ToDoApp.Services
{
	public interface IIdService
	{
		bool IsUserLoggedIn { get; }
		Task<bool> LoginAsync(string username, string password);
	}
}

