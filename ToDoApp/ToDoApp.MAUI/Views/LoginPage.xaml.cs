using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class LoginPage 
    {
        public LoginPage(LoginViewModel loginViewModel)
        {
            BindingContext = loginViewModel;
            InitializeComponent();
        }
       
    }
}