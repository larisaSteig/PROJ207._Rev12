using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Workshop5.Rev2.Data.Domain
{
    public partial class Packages
    {
        public Packages()
        {
            Bookings = new HashSet<Bookings>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSuppliers>();
        }
        [Display(Name = "Package ID")]
        public int PackageId { get; set; }
        [Display(Name = "Package Name")]
        public string PkgName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? PkgStartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? PkgEndDate { get; set; }
        [Display(Name = "Description")]
        public string PkgDesc { get; set; }
        [Display(Name = "Price")]
        public decimal PkgBasePrice { get; set; }
        [Display(Name = "Agency Commission")]
        public decimal? PkgAgencyCommission { get; set; }
        public string Photo { get; set; }
        public string AlternativeText { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<PackagesProductsSuppliers> PackagesProductsSuppliers { get; set; }
    }
}
