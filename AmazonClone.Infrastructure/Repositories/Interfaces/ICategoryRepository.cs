using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        /// <returns>The most popular categories, "Popular": The categories with most assigned products</returns>
        IEnumerable<Category> GetMostPopular();

        void Update(Category entity);

    }
}