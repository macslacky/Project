namespace LoginDemo.Page;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private async void LogoutButton_Clicked(object sender, EventArgs e)
	{
		if (await DisplayAlert("Are you sure?", "You will bel logged out.", "Yes", "No"))
		{
            // removes all of the stored encrypted key/value pairs
            SecureStorage.RemoveAll();
			await Shell.Current.GoToAsync("///login");
		}
	}
}