using System;
using System.Collections.Generic;

namespace Workshop5.Rev2.Data.Domain
{
    public partial class Classes
    {
        public Classes()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDesc { get; set; }

        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
