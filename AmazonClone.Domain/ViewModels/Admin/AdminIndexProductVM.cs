using AmazonClone.Domain.Entities;


namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminIndexProductVM
    {
        public Category? Category { get; set; }

        // May be IEnumerable<ProductDto> in future
        public IEnumerable<Product> Products { get; set; }
    }
}
