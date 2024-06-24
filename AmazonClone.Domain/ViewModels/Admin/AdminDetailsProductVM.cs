using AmazonClone.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminDetailsProductVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public Category Category { get; set; }

        public double ActualPrice =>
            Price - Price * (DiscountPercentage / 100);
    }
}
