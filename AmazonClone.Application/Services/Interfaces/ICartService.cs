using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface ICartService
    {
        void Add(CartItem item);


        IEnumerable<CartItem> GetAll();
        CartItem Get(Expression<Func<CartItem, bool>> filter);
        public IEnumerable<CartItem> GetCustomerCartItems(string userId);


        void Update(CartItem item);


        void Remove(CartItem item);



        bool IsProductInCustomerCart(string userId, int productId);
    }
}
