namespace notebook.backend.Models.RequestModels
{
    public class UsersRequest
    {
        public long? id { get; set; }
        public string username { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string password { get; set; }
    }
}