using LoginDemo.Page;

namespace LoginDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("login", typeof(LoginPage));
		Routing.RegisterRoute("home", typeof(HomePage));
		Routing.RegisterRoute("setting", typeof(SettingsPage));
	}
}
