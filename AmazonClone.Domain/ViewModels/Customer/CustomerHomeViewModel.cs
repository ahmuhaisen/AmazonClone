namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerHomeViewModel
    {
        public IEnumerable<CustomerHomeCategoryViewModel> PopularCategories { get; set; } = Enumerable.Empty<CustomerHomeCategoryViewModel>();
        public IEnumerable<CustomerHomeProductViewModel> Products { get; set; } = Enumerable.Empty<CustomerHomeProductViewModel>();

    }
}
