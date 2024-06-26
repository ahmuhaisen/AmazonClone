namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerDetailsProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool HasSize { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double ActualPrice =>
                Math.Round(Price - Price * (DiscountPercentage / 100), 2);


       
    }
}
