using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AmazonClone.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }


        [Required, MaxLength(100)]
        public string? LastName { get; set; }


        public string? ProfilePictureUrl { get; set; }

        [NotMapped]
        [ValidateNever]
        public string FullName => $"{FirstName} {LastName}";


        public ICollection<WishlistItem> Wishlist { get; set; }
        public ICollection<CartItem> Cart { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
