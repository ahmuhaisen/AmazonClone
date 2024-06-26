using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(WishlistItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WishlistItem> GetCustomerWishlist(string customerId)
        {
            return _unitOfWork.Wishlist.GetCustomerWishlist(customerId);
        }

        public void Remove(WishlistItem item)
        {
            throw new NotImplementedException();
        }
    }
}
