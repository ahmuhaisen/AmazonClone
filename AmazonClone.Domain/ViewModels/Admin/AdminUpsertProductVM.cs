using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminUpsertProductVM
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.1, int.MaxValue)]
        public double Price { get; set; }

        [Display(Name = "Discount Percentage")]
        [Range(0, 100)]
        public double DiscountPercentage { get; set; }

        [Display(Name = "Category")]
        [Range(0, 100)]
        public int CategoryId { get; set; }


        public IFormFile? Image { get; set; }


        public string? ImageUrl { get; set; }


        public IEnumerable<SelectListItem> CategoryList { get; set; } = Enumerable.Empty<SelectListItem>();
        public string OperationType => Id == 0 ? "Create" : "Edit";
    }
}
