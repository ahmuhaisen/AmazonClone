using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmazonClone.Infrastructure.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _db;

        public CartItemRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<CartItem> GetCustomerCartItems(string userId)
        {
            return _db.CartItems
                .AsNoTracking()
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToList();
                
        }



        public void Update(CartItem cartItem)
        {
            _db.CartItems.Update(cartItem);
        }
    }
}
