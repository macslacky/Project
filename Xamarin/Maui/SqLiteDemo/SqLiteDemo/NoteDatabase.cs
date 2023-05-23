using SQLite;

namespace SqLiteDemo
{
    // this class contains the code to create the database, read, write and delete the data
    public class NoteDatabase
    {
        // SQLiteAsyncConnection allows you to access and manipulate data in a local database in a more efficient and scalable way
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            // open the database specified by dbPath
            database = new SQLiteAsyncConnection(dbPath);
            // create table if not exist on the database
            database.CreateTableAsync<Note>().Wait();
        }

        // read the data from the table
        public Task<List<Note>> GetNotesAsync()
        {
            // queries the database and return the result as a List
            return database.Table<Note>().ToListAsync();
        }

        // read the data of the indicated note
        public Task<Note> GetNoteAsync(int id)
        {
            // filter a query based on a predicate, return the first element of this query
            return database.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        // save the data
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                // update
                return database.UpdateAsync(note);
            }
            else
            {
                // insert
                return database.InsertAsync(note);
            }
        }

        // delete the data
        public Task<int> DeleteNoteAsync(Note note)
        {
            // deletes
            return database.DeleteAsync(note);
        }
    }
}
