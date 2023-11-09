using ToDoApp.ViewModels;

namespace ToDoApp.Views;

public partial class AboutPage 
{
    public AboutPage(AboutViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}