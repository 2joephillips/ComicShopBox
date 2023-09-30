namespace ComicShopBox.View;

public partial class LoadingPage 
{
	public LoadingPage()
	{
		InitializeComponent();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (await hasBeenInitialized())
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");

        }
        else
        {
            await Shell.Current.GoToAsync(nameof(StartUpPage));
        }
        base.OnNavigatedTo(args);
    }

    async Task<bool> hasBeenInitialized()
    {
        await Task.Delay(2000);
        var hasInitialized = await SecureStorage.GetAsync("hasInitialized");
        return !(hasInitialized == null);
    }
}