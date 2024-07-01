using AmazonClone.Domain.Entities;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        int Count();

        IEnumerable<Product> GetAllByCategoryID(int categoryId);
        
        void Update(Product product);
    }
}
