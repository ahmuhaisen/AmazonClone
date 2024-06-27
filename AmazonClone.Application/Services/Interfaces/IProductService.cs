using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IProductService
    {
        void Create(Product Product);



        Product Get(Expression<Func<Product, bool>> filter);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        IEnumerable<CustomerHomeProductViewModel> GetHomeProductsList(int? categoryId = null);



        void Update(Product Product);
        string UpsertProductImage(string ImageUrl, IFormFile? file, string wwwRootPath);




        void Remove(Product Product);




        CustomerHomeProductViewModel ConvertProductToViewModel(Product product);
    }
}
