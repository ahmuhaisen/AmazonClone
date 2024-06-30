using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.Domain.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }


        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }



        public IEnumerable<WishlistItem> Wishlist { get; set; }
        public IEnumerable<CartItem> Cart { get; set; }
        public List<OrderItem> OrderItems { get; set; }


        [ValidateNever]
        [NotMapped]
        public double ActualPrice =>
            Math.Round(Price - Price * (DiscountPercentage / 100), 2);
    }
}
