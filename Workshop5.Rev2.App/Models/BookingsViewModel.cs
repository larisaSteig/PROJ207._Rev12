using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop5.Rev2.App.Models
{
    public class BookingsViewModel
    {
        public int BookingId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingNo { get; set; }
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        public string TripTypeId { get; set; }
        public int? PackageId { get; set; }

        public virtual string Customer { get; set; }
        public virtual string Package { get; set; }
        public virtual string TripType { get; set; }
        public virtual string BookingDetails { get; set; }
    }
}
