namespace ToDoApp.MAUI;

public partial class App : Application
{
    ToDoApplication _toDoApplication;

    public App(ToDoApplication toDoApplication)
	{
		InitializeComponent();

        _toDoApplication=toDoApplication?? throw new NullReferenceException("ToDoApplication service is null");

        MainPage = new NavigationPage(new ContentPage());
	}

    protected override async void OnStart()
    {
        await _toDoApplication.OnStart();
    }
    protected override async void OnSleep()
    {
        await _toDoApplication.OnSleep();
    }
    protected override async void OnResume()
    {
        await _toDoApplication.OnResume();
    }
}

