using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace AmazonClone.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishlistService(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
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

        public IEnumerable<Product> GetCustomerWishlistProducts(string userId)
        {
            return _unitOfWork.Wishlist.GetCustomerWishlist(userId);
        }



        public void Remove(WishlistItem item)
        {
            _unitOfWork.Wishlist.Remove(item);
            _unitOfWork.Save();
        }

        
        
        
        public bool IsProductInCustomerWishlist(string userId, int productId)
        {
            if (string.IsNullOrEmpty(userId) || productId == 0)
                return true;

            return _unitOfWork.Wishlist.IsProductInCustomerWishlist(userId, productId);
        }

    }
}
