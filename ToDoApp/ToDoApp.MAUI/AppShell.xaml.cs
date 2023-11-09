using ToDoApp.Views;

namespace ToDoApp
{
    public partial class AppShell 
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ItemDetails", typeof(ItemDetailPage));
            Routing.RegisterRoute("AddItem", typeof(NewItemPage));
        }

    }
}
