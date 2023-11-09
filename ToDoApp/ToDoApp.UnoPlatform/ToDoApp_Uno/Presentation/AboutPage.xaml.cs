using ToDoApp.ViewModels;

namespace ToDoApp_Uno.Presentation
{
    public sealed partial class AboutPage 
    {
        AboutViewModel _vm;
        public AboutPage()
        {
            this.DataContext = _vm= (Application.Current as App).Host.Services.GetService<AboutViewModel>();
            this.InitializeComponent();
        }

        public async Task OnLoaded()
        {
            await _vm.OnNavigatedTo(null);
        }
        
    }
}