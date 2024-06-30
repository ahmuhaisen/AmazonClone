using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface ICartService
    {
        void Add(CartItem item);


        IEnumerable<CartItem> GetAll();
        CartItem Get(Expression<Func<CartItem, bool>> filter);
        public IEnumerable<CartItem> GetCustomerCartItems(string userId);
        public IEnumerable<CustomerCartItemViewModel> GetCustomerCartItemsAsModel(IEnumerable<CartItem> items);


        void Update(CartItem item);


        void Remove(CartItem item);



        bool IsProductInCustomerCart(string userId, int productId);
    }
}
