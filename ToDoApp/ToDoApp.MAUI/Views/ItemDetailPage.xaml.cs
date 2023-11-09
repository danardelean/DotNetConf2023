using ToDoApp.ViewModels;

namespace ToDoApp.Views;

public partial class ItemDetailPage 
{
    public ItemDetailPage(ItemDetailViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}