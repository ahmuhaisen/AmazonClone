using AmazonClone.Domain.Entities;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Order Get(int Id);
        IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter);
        int GetNoOfOrders();
        int GetSalesVolume();



        void PlaceOrder(int shipmentId, int paymentId, string userId);
    }
}
