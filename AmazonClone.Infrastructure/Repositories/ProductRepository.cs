using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AmazonClone.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Products.Count();
        }

        public new IEnumerable<Product> GetAll()
        {
            var query = _db.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryId);

            return query.ToList();
        }

        public IEnumerable<Product> GetAllByCategoryID(int categoryId)
        {
            var query = _db.Products
                .AsNoTracking()
                .Include(x =>x.Category)
                .Where(x => x.CategoryId == categoryId);

            return query.ToList();
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
