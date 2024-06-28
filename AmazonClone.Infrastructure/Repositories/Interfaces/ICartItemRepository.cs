using AmazonClone.Domain.Entities;


namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        public IEnumerable<CartItem> GetCustomerCartItems(string userId);
        public void Update(CartItem cartItem);
    }
}
