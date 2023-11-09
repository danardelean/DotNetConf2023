using ToDoApp.ViewModels;

namespace ToDoApp.Views;

public partial class NewItemPage 
{
    public NewItemPage(NewItemViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}