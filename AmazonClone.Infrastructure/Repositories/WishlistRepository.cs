using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AmazonClone.Infrastructure.Repositories
{
    public class WishlistRepository : GenericRepository<WishlistItem>, IWishlistRepository
    {
        private readonly AppDbContext _db;

        public WishlistRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<WishlistItem> GetCustomerWishlist(string customerId)
        {
            return _db.Wishlist.Include(x => x.Product).Where(x => x.UserId == customerId);
        }
    }
}
