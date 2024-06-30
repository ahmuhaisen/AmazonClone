namespace AmazonClone.Domain.Entities
{
    public class Shipment : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumber { get; set; }
        public string PinCode { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
