namespace notebook.backend.Models.RequestModels
{
    public class NotesRequest
    {
        public string title { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public long pageid { get; set; }
    }
}