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

        public IEnumerable<Product> GetCustomerWishlist(string customerId)
        {
            var productIds = _db.Wishlist.Where(x => x.UserId == customerId).Select(x => x.ProductId);
            var result = _db.Products.Include(x => x.Category).Where(x => productIds.Contains(x.Id));
            var queryString = result.ToQueryString();
            return result.ToList();
        }

        public bool IsProductInCustomerWishlist(string customerId, int productId)
        {
            return _db.Wishlist.Any(x => x.ProductId == productId && x.UserId == customerId);
        }
    }
}
