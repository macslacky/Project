namespace SqLiteDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        // navigate through the pages of the application
        Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
	}
}
