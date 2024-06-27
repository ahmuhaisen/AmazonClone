using AmazonClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IWishlistService
    {
        void Add(WishlistItem item);
        void Remove(WishlistItem item);



        WishlistItem Get(Expression<Func<WishlistItem, bool>> filter);
        IEnumerable<Product> GetCustomerWishlist(string customerId);

        bool IsProductInCustomerWishlist(string customerId, int productId);
    }
}
