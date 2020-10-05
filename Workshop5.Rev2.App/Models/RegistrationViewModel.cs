using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Workshop5.Rev2.App.Models
{
   
    public class RegistrationViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        [Display(Name = "Street Address")]
        public string CustAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Your City")]
        [Display(Name = "City")]
        public string CustCity { get; set; }

        [Required(ErrorMessage = "Please Enter Your Province")]
        [Display(Name = "Province")]
        public string CustProv { get; set; }

        [Required(ErrorMessage = "Please Enter Your Postal Code")]
        [Display(Name = "Postal Code")]
        public string CustPostal { get; set; }

        [Required(ErrorMessage = "Please Enter Your Home Phone")]
        [Display(Name = "Home Phone:")]
        public string CustHomePhone { get; set; }

        [Required(ErrorMessage = "Please Enter Your Business Phone")]
        [Display(Name = "Business Phone")]
        public string CustBusPhone { get; set; }

        [Display(Name = "Email:")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "Please Enter a User Name")]
        [Display(Name = "User Name:")]
        public string CustUserName { get; set; }

        [Required(ErrorMessage = "Please Enter a Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string CustPassword { get; set; }

        [NotMapped]
        [DataType(DataType.Password), Compare(nameof(CustPassword))]
        public string ConfirmPassword { get; set; }
    }
}
