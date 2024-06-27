using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IWishlistService
    {
        void Add(WishlistItem item);

        WishlistItem Get(Expression<Func<WishlistItem, bool>> filter);
        IEnumerable<Product> GetCustomerWishlistProducts(string userId);


        void Remove(WishlistItem item);




        bool IsProductInCustomerWishlist(string userId, int productId);
    }
}
