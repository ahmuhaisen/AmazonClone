
using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IOrderItemService
    {
        void AddRange(IEnumerable<OrderItem> orderItems);
        public IEnumerable<OrderItem> GetAllBy(Expression<Func<OrderItem, bool>> filter);

    }
}
