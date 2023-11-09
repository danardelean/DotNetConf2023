namespace ToDoApp.ViewModels;

public partial class ItemDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _id;

    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private string _description;

    IDataStore<Item> _dataStore;

    public ItemDetailViewModel(IDataStore<Item> dataStore)
    {
        _dataStore = dataStore ?? throw new NullReferenceException("DataStore service is null");
    }

    public ItemDetailViewModel(IDataStore<Item> dataStore,IDictionary<string,object> parameters)
    {
        //UNO Hack 
        _dataStore = dataStore ?? throw new NullReferenceException("DataStore service is null");
        if (parameters is not null)
            OnNavigatedTo(parameters);
    }
    public override async Task OnNavigatedTo(IDictionary<string, object> parameters)
    {
        await base.OnNavigatedTo(parameters);
        if (parameters.ContainsKey("Id"))
        {
            try
            {
                var item = await _dataStore.GetItemAsync(parameters["Id"] as string);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }

}
