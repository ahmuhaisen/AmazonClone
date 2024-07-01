using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        public void AddRange(IEnumerable<OrderItem> items);
        public IEnumerable<OrderItem> GetAllBy(Expression<Func<OrderItem, bool>> filter);

    }
}
