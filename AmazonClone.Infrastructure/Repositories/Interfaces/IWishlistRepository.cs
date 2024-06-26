using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IWishlistRepository : IGenericRepository<WishlistItem>
    {
        IEnumerable<WishlistItem> GetCustomerWishlist(string customerId); 
    }
}
