using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category{ get; set; }
        public IProductRepository Product { get; set; }
        public IWishlistRepository Wishlist { get; set; }
        public ICartItemRepository Cart { get; set; }
        public IShipmentRepository Shipment { get; set; }
        public IPaymentRepository Payment { get; set; }
        public IOrderItemRepository OrderItem { get; set; }
        public IOrderRepository Order { get; set; }


        void Save();
    }
}
