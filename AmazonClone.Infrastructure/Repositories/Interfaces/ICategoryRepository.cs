using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        void Update(Category entity);
    }
}