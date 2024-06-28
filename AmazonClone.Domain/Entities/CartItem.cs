namespace AmazonClone.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int Quantity { get; set; }
    }
}
