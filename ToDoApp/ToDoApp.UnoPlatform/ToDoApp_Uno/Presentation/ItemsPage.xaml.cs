using ToDoApp.ViewModels;

namespace ToDoApp_Uno.Presentation
{
    public sealed partial class ItemsPage 
    {
        ItemsViewModel _vm;
        public ItemsPage()
        {
            this.DataContext= _vm=(Application.Current as App).Host.Services.GetService<ItemsViewModel>();
            this.InitializeComponent();
        }

        public async Task OnLoaded()
        {
            await _vm.OnNavigatedTo(null);
        }
    }
}