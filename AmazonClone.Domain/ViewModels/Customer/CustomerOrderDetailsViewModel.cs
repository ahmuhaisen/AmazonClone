namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerOrderDetailsViewModel
    {
        public CustomerOrderViewModel CurrentOrder { get; set; }
        public IEnumerable<CustomerOrderItemViewModel> OrderItems { get; set; }
    }
}
