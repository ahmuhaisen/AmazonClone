using AmazonClone.Domain.Entities;


namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminIndexProductViewModel
    {
        public Category? Category { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
