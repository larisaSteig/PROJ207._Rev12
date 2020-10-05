using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workshop5.Rev2.App.Models
{

    public class PackageViewModel
    {
        public int PackageId { get; set; }
        [Display(Name = "Chosen Package")]
        public string PkgName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? PkgStartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        [Display(Name = "Price")]
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        public virtual string Bookings { get; set; }
        public virtual string PackagesProductsSuppliers { get; set; }

        public string Photo { get; set; }
    }
}
