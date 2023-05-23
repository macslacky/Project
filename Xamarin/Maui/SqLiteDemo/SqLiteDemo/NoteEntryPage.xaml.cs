namespace SqLiteDemo;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NoteEntryPage : ContentPage
{

	public string ItemId
	{
		set
		{
			LoadNote(value);
		}
	}
	public NoteEntryPage()
	{
		InitializeComponent();
		BindingContext = new Note();
	}

	async void LoadNote(string itemId)
	{
        try
        {
            int id = Convert.ToInt32(itemId);
            // read the data of the indicated note
            Note note = await App.Database.GetNoteAsync(id);
            // displays previously read data
            BindingContext = note;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to load note");
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // the displayed data is entered into the record
        var note = (Note)BindingContext;
        note.dataAgg = DateTime.UtcNow;
        if (!string.IsNullOrWhiteSpace(note.Titolo))
        {
            // save previously read data
            await App.Database.SaveNoteAsync(note);
        }
        // returns to the note list view
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        // the displayed data is entered into the record
        var note = (Note)BindingContext;
        // delete previously read data
        await App.Database.DeleteNoteAsync(note);
        // returns to the note list view
        await Shell.Current.GoToAsync("..");
    }
}
