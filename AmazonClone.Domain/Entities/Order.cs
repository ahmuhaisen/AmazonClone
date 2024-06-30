namespace AmazonClone.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double TotalPrice { get; set; }


        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; }


        public int PaymentId { get; set; }
        public Payment Payment { get; set; }


        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
