using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IWishlistRepository : IGenericRepository<WishlistItem>
    {
        IEnumerable<Product> GetCustomerWishlist(string customerId);


        bool IsProductInCustomerWishlist(string customerId, int productId);
    }
}
