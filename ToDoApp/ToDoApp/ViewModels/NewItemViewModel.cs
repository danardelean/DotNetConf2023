using ToDoApp.Services;

namespace ToDoApp.ViewModels;

public partial class NewItemViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string text;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string description;

    IDataStore<Item> _dataStore;
    INavigationService _navigationService;

    public NewItemViewModel(IDataStore<Item> dataStore, INavigationService navigationService)
    {
        _dataStore = dataStore ?? throw new NullReferenceException("DataStore service is null");
        _navigationService = navigationService ?? throw new NullReferenceException("NavigationService service is null");
    }

    private bool ValidateSave()
    {
        return !String.IsNullOrWhiteSpace(text)
            && !String.IsNullOrWhiteSpace(description);
    }

    [RelayCommand]
    private Task Cancel()
    {
        // This will pop the current page off the navigation stack
        return _navigationService.GoBackAsync();
    }

    [RelayCommand(AllowConcurrentExecutions =false, CanExecute = nameof(ValidateSave))]
    private async Task Save()
    {
        Item newItem = new Item()
        {
            Id = Guid.NewGuid().ToString(),
            Text = Text,
            Description = Description
        };

        await _dataStore.AddItemAsync(newItem);

        // This will pop the current page off the navigation stack
        await _navigationService.GoBackAsync();
    }
}
