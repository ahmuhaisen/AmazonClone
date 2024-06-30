namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerCartViewModel
    {
        public IEnumerable<CustomerCartItemViewModel> CartItems { get; set; } = new List<CustomerCartItemViewModel>();
        public CustomerCartCheckoutViewModel CheckoutSection { get; set; }= new ();
    }
}
