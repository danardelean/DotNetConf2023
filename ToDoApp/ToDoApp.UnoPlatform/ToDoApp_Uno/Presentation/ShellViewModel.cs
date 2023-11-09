using ToDoApp;
using ToDoApp.Services;
using ToDoApp_Uno.Services;

namespace ToDoApp_Uno.Presentation
{
    public class ShellViewModel
    {
        private readonly INavigator _navigator;
        private readonly ToDoApplication _toDoApplication;
        public ShellViewModel(
            INavigator navigator,ToDoApplication toDoApplication,INavigationService navigationService)
        {
            ((NavigationService)navigationService).Navigator = navigator;
            _toDoApplication = toDoApplication ?? throw new NullReferenceException("ToDoApplication service is null");
            _ = Start();
        }

        public async Task Start()
        {
            await _toDoApplication.OnStart();
        }
    }
}