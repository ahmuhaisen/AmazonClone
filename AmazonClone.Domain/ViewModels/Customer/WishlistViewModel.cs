namespace AmazonClone.Domain.ViewModels.Customer
{
    public class WishlistViewModel
    {
        public IEnumerable<CustomerHomeProductViewModel> Products { get; set; } = Enumerable.Empty<CustomerHomeProductViewModel>();
    }
}
