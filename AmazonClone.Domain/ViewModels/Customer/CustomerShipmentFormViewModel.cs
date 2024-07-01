using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Domain.ViewModels.Customer
{
    
    public class CustomerShipmentFormViewModel
    {
        [BindProperty]
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }

        [MinLength(4)]
        public string Country { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Contact Number")]
        [MinLength(10)]
        public string ContactNumber { get; set; }

        [MaxLength(4)]
        public string PinCode { get; set; }
    }
}
