using AmazonClone.Domain.Entities;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IShipmentService
    {
        void Create(Shipment shipment);
    }
}
