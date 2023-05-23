namespace SqLiteDemo;

public partial class App : Application
{
	static NoteDatabase database;
	public static NoteDatabase Database
	{
		get
		{
			if (database == null)
			{
				database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sqlNotes.db3"));
			}
			return database;
		}
	}
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
