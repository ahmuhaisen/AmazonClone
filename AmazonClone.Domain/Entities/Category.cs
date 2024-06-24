namespace AmazonClone.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconString { get; set; }
        public bool HasSize { get; set; }


        public IEnumerable<Product> Products { get; set; }
    }
}
