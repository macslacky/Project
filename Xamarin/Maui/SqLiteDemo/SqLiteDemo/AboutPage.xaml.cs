namespace SqLiteDemo;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	async void OnBtnClicked(object sender, EventArgs e)
	{
		await Launcher.OpenAsync("https://www.ribosoft.info/2023/04/25/archiviare-dati-in-locale-con-sqlite/");
	}
}