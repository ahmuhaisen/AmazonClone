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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the top 4 popular categories, "Popular": The categories with most assigned products</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Category> GetMostPopular()
        {
            var result = _db.Categories
                .Include(c => c.Products)
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