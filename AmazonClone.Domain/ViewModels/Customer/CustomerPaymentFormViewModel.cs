using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerPaymentFormViewModel
    {
        public int ShipmentId { get; set; }

        public double TotalAmount { get; set; }

        [Display(Name = "Payment Method")]
        public string SelectedPaymentMethod { get; set; }
    }
}
