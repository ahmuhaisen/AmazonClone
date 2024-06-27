using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IWishlistRepository : IGenericRepository<WishlistItem>
    {
        IEnumerable<Product> GetCustomerWishlist(string userId);


        bool IsProductInCustomerWishlist(string userId, int productId);
    }
}
