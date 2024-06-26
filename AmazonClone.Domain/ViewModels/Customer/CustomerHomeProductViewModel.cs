namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerHomeProductViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double ActualPrice =>
            Math.Round(Price - Price * (DiscountPercentage / 100), 2);
    }
}
