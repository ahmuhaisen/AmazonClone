namespace AmazonClone.Domain.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
