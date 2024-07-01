using AmazonClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        int Count();
        IEnumerable<Product> GetAllByCategoryID(int categoryId);
        
        void Update(Product product);
    }
}
