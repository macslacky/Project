namespace LoginDemo.Page;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	bool IsCredentialCorrect(string username, string password)
	{
		return Username.Text == "admin" && Password.Text == "1234";
	}

	private async void LoginButton_Clicked(object sender, EventArgs e)
	{
		if (IsCredentialCorrect(Username.Text, Password.Text))
		{
            // securely store simple key/value pairs
            await SecureStorage.SetAsync("hasAuth", "true");
			await Shell.Current.GoToAsync("//home");
		}
		else
		{
			await DisplayAlert("Login failed", "Username or password if invalid", "Try again");
		}
	}
}