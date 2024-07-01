using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter);

    }
}
