using System;
namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerCartCheckoutViewModel
    {
        public double SubTotal { get; set; }
        public double Delivery { get; set; }
        public double TaxRate { get; set; }
        public double SubTotalTax { get; set; }
        public double Total { get; set; }
    }
}
