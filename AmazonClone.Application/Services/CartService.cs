using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

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
        public IEnumerable<CustomerCartItemViewModel> GetCustomerCartItemsAsModel(IEnumerable<CartItem> items)
        {
            return items.Select(x =>
                new CustomerCartItemViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name.Length >= 30 ? $"{x.Product.Name.Substring(0, 30)}.." : x.Product.Name,
                    ActualPrice = x.Product.ActualPrice,
                    ImageUrl = x.Product.ImageUrl,
                    Quantity = x.Quantity
                });
        }
     


        public void Remove(CartItem item)
        {
            _unitOfWork.Cart.Remove(item);
            _unitOfWork.Save();
        }
        public void RemoveRange(IEnumerable<CartItem> items)
        {
            _unitOfWork.Cart.RemoveRange(items);
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
