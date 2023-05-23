namespace LoginDemo.Page;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if (await isAuthenticated())
		{
			await Shell.Current.GoToAsync("///home");
		}
		else
		{
            await Shell.Current.GoToAsync("login");
        }
	}

	async Task<bool> isAuthenticated()
	{
		await Task.Delay(2000);
        // gets the decrypted value for a given key
        var hasAuth = await SecureStorage.GetAsync("hasAuth");
		return !(hasAuth == null);
	}
}