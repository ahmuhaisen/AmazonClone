namespace AmazonClone.Domain.ViewModels.Customer
{
    public class CustomerCartItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public double ActualPrice { get; set; }
        public int Quantity { get; set; }
    }
}
