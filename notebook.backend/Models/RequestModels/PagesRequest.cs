namespace notebook.backend.Models.RequestModels
{
    public class PagesRequest
    {
        public long id { get; set; }
        public string oldName { get; set; }
        public string newName { get; set; }
        public string name { get; set; }
        public long folderId { get; set; }
    }
}