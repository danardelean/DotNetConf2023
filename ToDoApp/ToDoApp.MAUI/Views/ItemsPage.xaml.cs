using ToDoApp.ViewModels;

namespace ToDoApp.Views;

public partial class ItemsPage 
{
    ItemsViewModel _viewModel;

    public ItemsPage(ItemsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();

    }

}