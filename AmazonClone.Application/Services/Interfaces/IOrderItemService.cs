
using AmazonClone.Domain.Entities;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IOrderItemService
    {
        void AddRange(IEnumerable<OrderItem> orderItems);
    }
}
