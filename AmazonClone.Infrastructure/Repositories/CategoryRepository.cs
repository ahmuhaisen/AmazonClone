using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmazonClone.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db) : base(db) 
        {
            _db = db;
        }

        public IEnumerable<Category> GetMostPopular()
        {
            var result = _db.Categories
                .Include(c => c.Products)
                .AsNoTracking()
                .OrderByDescending(c => c.Products.Count())
                .Take(4);
            return result;
        }



        public void Update(Category entity)
        {
            _db.Update(entity);
        }
    }
}