using System;
using System.Collections.Generic;

namespace notebook.backend.Models
{
    public partial class Pages
    {
        public Pages()
        {
            Notes = new HashSet<Notes>();
        }

        public long Id { get; set; }
        public long FolderId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Folder Folder { get; set; }
        public ICollection<Notes> Notes { get; set; }
    }
}
