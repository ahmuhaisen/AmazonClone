using AmazonClone.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(Expression<Func<Product, bool>> filter);

        void Create(Product Product);
        void Update(Product Product);
        void Remove(Product Product);
        IEnumerable<Product> GetAllByCategoryId(int categoryId);


        string UpsertProductImage(string ImageUrl, IFormFile? file, string wwwRootPath);


    }
}
