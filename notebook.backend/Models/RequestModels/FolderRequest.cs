using System;

namespace notebook.backend.Models.RequestModels
{
    public class FolderRequest
    {
        public long userId { get; set; }
        public string name { get; set; }
        public string newName { get; set; }
        public long id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
       // public string oldName { get; set; }
    }
}