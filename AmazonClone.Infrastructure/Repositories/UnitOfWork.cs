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
        public IShipmentRepository Shipment { get; set; }
        public IPaymentRepository Payment { get; set; }
        public IOrderItemRepository OrderItem { get; set; }
        public IOrderRepository Order { get; set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Wishlist = new WishlistItemRepository(_db);
            Cart = new CartItemRepository(_db);
            Shipment = new ShipmentRepository(_db);
            Payment = new PaymentRepository(_db);
            OrderItem = new OrderItemRepository(_db);
            Order = new OrderRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
