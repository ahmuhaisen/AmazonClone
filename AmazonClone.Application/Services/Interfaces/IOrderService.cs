using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(int shipmentId, int paymentId, string userId);
    }
}
