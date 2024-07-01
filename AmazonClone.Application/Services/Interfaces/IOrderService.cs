using AmazonClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter);
        Order Get(int Id);

        void PlaceOrder(int shipmentId, int paymentId, string userId);
    }
}
