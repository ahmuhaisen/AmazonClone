using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        int Count();
        IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter);
        int GetSalesVolume();
    }
}
