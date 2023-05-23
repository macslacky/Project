namespace SqLiteDemo;

public partial class NotesPage : ContentPage
{
	public NotesPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
        // customize the behavior just before the page object becomes visible
        base.OnAppearing();
        // read the data from the table
        collectionView.ItemsSource = await App.Database.GetNotesAsync();
	}

	async void OnAddClicked(object sender, EventArgs e)
	{
        // switches asynchronously to NoteEntryPage
        await Shell.Current.GoToAsync(nameof(NoteEntryPage));
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection != null)
		{
			// returns the first element 
			Note note = (Note)e.CurrentSelection.FirstOrDefault();
            // switches asynchronously to NoteEntryPage 
            await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.Id.ToString()}");
		}
	}
}
