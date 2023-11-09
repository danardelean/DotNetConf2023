namespace ToDoApp_Uno.Presentation
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await pageAbout.OnLoaded();
            await pageItems.OnLoaded();
        }
    }
}