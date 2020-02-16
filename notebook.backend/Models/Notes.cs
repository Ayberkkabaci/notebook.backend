using System;
using System.Collections.Generic;

namespace notebook.backend.Models
{
    public partial class Notes
    {
        public long Id { get; set; }
        public long PageId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? IsPrivate { get; set; }

        public Pages Page { get; set; }
    }
}
