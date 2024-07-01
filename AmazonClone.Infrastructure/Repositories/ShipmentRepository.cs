using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;

namespace AmazonClone.Infrastructure.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        private readonly AppDbContext _db;

        public ShipmentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
