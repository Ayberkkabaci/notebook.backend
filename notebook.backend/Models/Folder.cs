using System;
using System.Collections.Generic;

namespace notebook.backend.Models
{
    public partial class Folder
    {
        public Folder()
        {
            Pages = new HashSet<Pages>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Users User { get; set; }
        public ICollection<Pages> Pages { get; set; }
    }
}
