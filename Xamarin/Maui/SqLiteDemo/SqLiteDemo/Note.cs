using SQLite;

namespace SqLiteDemo
{
    public class Note
    {
        // define record, set id as autoincrementing primary key
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public DateTime dataNota { get; set; }
        public DateTime dataAgg { get; set; }
    }
}
