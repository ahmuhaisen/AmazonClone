
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;

namespace AmazonClone.Infrastructure.Repositories
{
    internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly AppDbContext _db;

        public OrderItemRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }


        public void AddRange(IEnumerable<OrderItem> items)
        {
            _db.OrderItems.AddRange(items);
        }
    }
}
