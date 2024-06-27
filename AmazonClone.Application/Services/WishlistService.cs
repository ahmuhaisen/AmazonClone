using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishlistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public bool IsProductInCustomerWishlist(string customerId, int productId)
        {
            if(string.IsNullOrEmpty(customerId) || productId == 0)
                return true;

            return _unitOfWork.Wishlist.IsProductInCustomerWishlist(customerId, productId);
        }



        public void Add(WishlistItem item)
        {
            _unitOfWork.Wishlist.Create(item);
            _unitOfWork.Save();
        }

        public WishlistItem Get(Expression<Func<WishlistItem, bool>> filter)
        {
            return _unitOfWork.Wishlist.Get(filter);
        }
        public IEnumerable<Product> GetCustomerWishlist(string customerId)
        {
            return _unitOfWork.Wishlist.GetCustomerWishlist(customerId);
        }

        public void Remove(WishlistItem item)
        {
            _unitOfWork.Wishlist.Remove(item);
            _unitOfWork.Save();
        }

      
    }
}
