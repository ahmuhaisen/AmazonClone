using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;


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
            return _db.Wishlist.Where(x => x.UserId == customerId);
        }
    }
}
