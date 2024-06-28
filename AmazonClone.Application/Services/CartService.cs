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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public void Add(CartItem item)
        {
            _unitOfWork.Cart.Create(item);
            _unitOfWork.Save();
        }



        public IEnumerable<CartItem> GetAll()
        {
            return _unitOfWork.Cart.GetAll();
        }
        public CartItem Get(Expression<Func<CartItem, bool>> filter)
        {
            return _unitOfWork.Cart.Get(filter);
        }
        public IEnumerable<CartItem> GetCustomerCartItems(string userId)
        {
            return _unitOfWork.Cart.GetCustomerCartItems(userId);
        }



        public void Remove(CartItem item)
        {
            _unitOfWork.Cart.Remove(item);
            _unitOfWork.Save();

        }



        public void Update(CartItem item)
        {
            _unitOfWork.Cart.Update(item);
            _unitOfWork.Save();
        }

        

        public bool IsProductInCustomerCart(string userId, int productId)
        {
            return Get(x => x.UserId == userId && x.ProductId == productId) is not null;
        }
    }
}
