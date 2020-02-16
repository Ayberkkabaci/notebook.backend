using System;
using System.Collections.Generic;

namespace notebook.backend.Models
{
    public partial class Users
    {
        public Users()
        {
            Folder = new HashSet<Folder>();
        }

        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public short? IsActive { get; set; }

        public ICollection<Folder> Folder { get; set; }
    }
}
