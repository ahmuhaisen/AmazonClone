using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;


namespace AmazonClone.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _db;
        public ICategoryRepository Category { get; set; }
        public IProductRepository Product { get; set; }
        public IWishlistRepository Wishlist { get; set; }
        public ICartItemRepository Cart { get; set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Wishlist = new WishlistItemRepository(_db);
            Cart = new CartItemRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
