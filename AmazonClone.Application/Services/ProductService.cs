using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Product Product)
        {
            _unitOfWork.Product.Create(Product);
            _unitOfWork.Save();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _unitOfWork.Product.Get(filter);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Product.GetAll();
        }

        public IEnumerable<Product> GetAllWithFilter()
        {
            return _unitOfWork.Product.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {

            var result = _unitOfWork.Product.GetAllByCategoryID(categoryId);
            return result;

        }

        public void Remove(Product Product)
        {
            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();
        }

        public void Update(Product Product)
        {
            _unitOfWork.Product.Update(Product);
            _unitOfWork.Save();
        }

        public string UpsertProductImage(string ImageUrl, IFormFile? file, string wwwRootPath)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Combine(wwwRootPath, @"images\product");

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                // Delete the old image
                string oldImagePath =
                    Path.Combine(wwwRootPath, ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return @"\images\product\" + fileName;
        }


    
    }
}
