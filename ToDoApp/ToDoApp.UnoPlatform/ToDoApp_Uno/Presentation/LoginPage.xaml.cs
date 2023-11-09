using ToDoApp.Services;
using ToDoApp_Uno.Services;

namespace ToDoApp_Uno.Presentation
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var navService = (NavigationService)((Application.Current as ToDoApp_Uno.App).Host.Services.GetRequiredService<INavigationService>());
        }
    }
}