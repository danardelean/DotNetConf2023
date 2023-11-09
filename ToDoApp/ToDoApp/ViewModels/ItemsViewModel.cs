namespace ToDoApp.ViewModels;

public partial class ItemsViewModel : BaseViewModel
{
    [ObservableProperty]
    private Item _selectedItem;

    [ObservableProperty]
    ObservableCollection<Item> _items;

    IDataStore<Item> _dataStore;
    INavigationService _navigationService;


    public ItemsViewModel(IDataStore<Item> dataStore,INavigationService navigationService)
    {
        _dataStore = dataStore ?? throw new NullReferenceException("DataStore service is null");
        _navigationService = navigationService ?? throw new NullReferenceException("NavigationService service is null");

        Title = "Browse";
        Items = new ObservableCollection<Item>();
    }

    public override async Task OnNavigatedTo(IDictionary<string, object> parameters)
    {
        await base.OnNavigatedTo(parameters);
        IsBusy = true;
        await LoadItemsAsync();
        IsBusy = false;
    }

    [RelayCommand(AllowConcurrentExecutions = false)]
    async Task LoadItemsAsync()
    {
        IsBusy = true;

        try
        {
            Items.Clear();
            var items = await _dataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand(AllowConcurrentExecutions =false)]
    private Task AddItemAsync()
    {
        return _navigationService.NavigateAsync("AddItem");
    }

    [RelayCommand(AllowConcurrentExecutions = false)]
    Task ItemSelected(Item item)
    {
        if (item == null)
            return Task.CompletedTask;

        // This will push the ItemDetailPage onto the navigation stack
        return _navigationService.NavigateAsync("ItemDetails",new Dictionary<string, object> { { "Id", item.Id } });
    }
}