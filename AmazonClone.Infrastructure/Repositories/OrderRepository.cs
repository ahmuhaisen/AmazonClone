using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmazonClone.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Orders.Count();
        }

        public IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter)
        {
            return _db.Orders.Where(filter).AsNoTracking();
        }

        public int GetSalesVolume()
        {
            return (int)_db.Orders.Sum(x => x.TotalPrice);
        }
    }
}
